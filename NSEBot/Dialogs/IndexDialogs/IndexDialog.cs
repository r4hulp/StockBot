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

namespace NSEBot.Dialogs.IndexDialogs
{
    [Serializable]

    public class IndexDialog : IDialog<string>
    {
        private string code;
        public IndexDialog( string code)
        {
            this.code = code;
        }

        public async Task StartAsync(IDialogContext context)
        {
            await this.MessageReceivedAsync(context);
        }

        private async Task MessageReceivedAsync(IDialogContext context)
        {

            IStockService nseService = new StockService();

            var data = await nseService.GetIndexQuote(code);

            if (data.QuoteResponse.Result.Count == 0)
            {
                await context.PostAsync("Could not fetch values for selected Index");

                context.Done("Could not fetch values for selected Index");
            }
            var rich_msg = context.MakeMessage();

            var adaptiveCard = StockCards.GetIndexCard(data);

            rich_msg.Attachments.Add(new Attachment()
            {
                Content = adaptiveCard,
                ContentType = AdaptiveCard.ContentType
            });

            var msg = "";
            await context.PostAsync(rich_msg);

            context.Done(msg);

        }
    }
}