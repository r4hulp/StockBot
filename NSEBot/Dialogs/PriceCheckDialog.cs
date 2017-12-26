using AdaptiveCards;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using NSEBot.AdaptiveCards;
using NSEBot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NSEBot.Dialogs
{
    [Serializable]
    public class PriceCheckDialog : IDialog<string>
    {
        private int attempts = 3;
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Enter company code.");

            context.Wait(this.MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            IStockService nseService = new StockService();

            var resp = await nseService.GetQuote(message.Text);

            if (resp.quoteResponse.result.Count < 1)
            {
                context.Done("Could not found the company you are looking for");
                return;
            }

            var adaptiveCard = StockCards.GetStockCard(resp);

            adaptiveCard.Actions = new List<AdaptiveAction>()
            {
                new AdaptiveSubmitAction()
                {
                    Data = "Show Top Gainers",
                    Title = "Check another Stock"
                },
                new AdaptiveSubmitAction()
                {
                    Data = "Show Top Gainers",
                    Title = "Top Gainers"
                },
            };

            var msg = context.MakeMessage();
            msg.Attachments.Add(new Attachment()
            {
                Content = adaptiveCard,
                ContentType = AdaptiveCard.ContentType
            });
            await context.PostAsync(msg);

            context.Done("");
        }
    }
}