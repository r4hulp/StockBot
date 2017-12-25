using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using NSEBot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NSEBot.Dialogs
{
    [Serializable]
    public class IndexValueDialog : IDialog<string>
    {
        private readonly string code;
        private string name;
        private int attempts = 3;


        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Enter index code.");

            context.Wait(this.MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            var code = message.Text;

            IStockService nseService = new StockService();

            var resp = await nseService.GetIndexQuote(code);

            var current_price = resp.QuoteResponse.Result.FirstOrDefault().RegularMarketPrice.Fmt;
            var current_change = resp.QuoteResponse.Result.FirstOrDefault().RegularMarketChange.Fmt;


            context.Done($"Index {code}. Current value {current_price}. Change from prev close - {current_change}");

        }
    }
}