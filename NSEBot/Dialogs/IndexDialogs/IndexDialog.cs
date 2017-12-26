using AdaptiveCards;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using NSEBot.AdaptiveCards;
using NSEBot.Service;
using NSEBot.Service.Enums;
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
        private int bloomberg_code;
        public IndexDialog(string code, int bloomberg_code)
        {

            this.code = code;
            this.bloomberg_code = bloomberg_code;
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

            adaptiveCard.Actions = new List<AdaptiveAction>()
            {
                new AdaptiveSubmitAction()
                {
                    Data = "Show Top Gainers",
                    Title = "Top Gainers"
                },
                new AdaptiveSubmitAction()
                {
                    Data = "Show Top Losers",
                    Title = "Top Losers"
                },
                new AdaptiveSubmitAction()
                {
                    Data = "Go back",
                    Title = "Go back"
                }
            };

            rich_msg.Attachments.Add(new Attachment()
            {
                Content = adaptiveCard,
                ContentType = AdaptiveCard.ContentType
            });

            await context.PostAsync(rich_msg);

            context.Wait(this.OnOptionSelected);

        }

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result as Activity;

            var action = message.Text;
            bool gainer = false;
            switch (action)
            {
                case "Show Top Gainers":
                    gainer = true;
                    //do this
                    break;
                case "Show Top Losers":
                    gainer = false;
                    //show top losers
                    break;
                case "Go back":
                    context.Done("");
                    return;
                default:
                    gainer = true;
                    break;
            }

            await this.ShowTopCharts(context, gainer);

        }

        private async Task ShowTopCharts(IDialogContext context, bool gainer)
        {

            var trend = gainer ? TrendType.Gainer : TrendType.Loser;
            var reply = context.MakeMessage();

            IStockService stockService = new StockService();
            var topCharts = gainer ? await stockService.GetTopGainers(bloomberg_code, "1D") : await stockService.GetTopLosers(bloomberg_code, "1D");

            var adaptiveCard = StockCards.GetTopCharts(topCharts, trend);

            adaptiveCard.Actions = new List<AdaptiveAction>()
            {
                new AdaptiveSubmitAction()
                {
                    Data = "Show Indices",
                    Title = "Show Indices"
                },
                new AdaptiveSubmitAction()
                {
                    Data = "Go to main menu",
                    Title = "Main Menu"
                }
            }; 

            reply.Attachments.Add(new Attachment()
            {
                Content = adaptiveCard,
                ContentType = AdaptiveCard.ContentType
            });

            await context.PostAsync(reply);

            context.Wait(this.OnMenuOptionSelectedAsync);

        }

        private async Task OnMenuOptionSelectedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result as Activity;

            var action = message.Text;
            bool gainer = false;
            switch (action)
            {
                case "Show Indices":
                    context.Done("");
                    break;
                case "Go to main menu":
                    context.Done("Exit");
                    break;
                default:
                    gainer = true;
                    break;
            }
        }
    }
}