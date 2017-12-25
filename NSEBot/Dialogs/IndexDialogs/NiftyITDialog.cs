using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using NSEBot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NSEBot.Dialogs.IndexDialogs
{
    [Serializable]

    public class NiftyITDialog : IDialog<string>
    {
        private string code;

        public async Task StartAsync(IDialogContext context)
        {
            this.code = "CNXIT";
            context.Wait(this.MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            IStockService nseService = new StockService();

            var resp = await nseService.GetIndexQuote(code);

            var current_price = resp.QuoteResponse.Result.FirstOrDefault().RegularMarketPrice.Fmt;
            var current_change = resp.QuoteResponse.Result.FirstOrDefault().RegularMarketChange.Fmt;

            string msg = $"Index {code}. Current value {current_price}. Change from prev close - {current_change}";
            await context.PostAsync(msg);

            context.Done(msg);

        }
    }
}