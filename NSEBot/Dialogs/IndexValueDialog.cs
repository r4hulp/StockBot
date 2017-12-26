using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using NSEBot.Dialogs.IndexDialogs;
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
            //await context.PostAsync("Enter index code.");

            await this.ShowIndicesMessageAsync(context);

        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;


            //show different indices
            await this.ShowIndicesMessageAsync(context);

            //var code = message.Text;

            //IStockService nseService = new StockService();

            //var resp = await nseService.GetIndexQuote(code);

            //var current_price = resp.QuoteResponse.Result.FirstOrDefault().RegularMarketPrice.Fmt;
            //var current_change = resp.QuoteResponse.Result.FirstOrDefault().RegularMarketChange.Fmt;


            //context.Done($"Index {code}. Current value {current_price}. Change from prev close - {current_change}");

        }

        public async Task ShowIndicesMessageAsync(IDialogContext context)
        {
            var reply = context.MakeMessage();


            var options = new[]
            {
                "SENSEX", "NIFTY 50", "NIFTY BANK", "NIFTY IT", "INDIA VIX", "Other", "Go back"
            };
            reply.AddHeroCard("Select Index", options, null);

            await context.PostAsync(reply);

            context.Wait(this.OnOptionSelected);

        }

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            string code = "BSESN";
            if (message.Text == "SENSEX")
            {
                code = "BSESN";
            }
            else if (message.Text == "NIFTY 50")
            {
                code = "NSEI";
            }
            else if (message.Text == "NIFTY IT")
            {
                code = "CNXIT";
            }
            else if (message.Text == "NIFTY BANK")
            {
                code = "NSEBANK";
            }
            else if (message.Text == "INDIA VIX")
            {
                code = "INDIAVIX";
            }
            else if (message.Text == "Other")
            {
                context.Call(new OtherIndexDialog(), this.OtherIndexDialogResumeAfterAsync);
                return;
            }
            else if(message.Text == "Go back")
            {
                context.Done("");
                return;
            }

            context.Call(new IndexDialog(code), this.SensexDialogResumeAfterAsync);

        }

        private async Task OtherIndexDialogResumeAfterAsync(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                var message = await result;
                await this.ShowIndicesMessageAsync(context);
            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I'm having issues understanding you. Let's try again.");

                context.Done("");

            }
        }

        private async Task IndiaVixDialogResumeAfterAsync(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                var message = await result;
                await this.ShowIndicesMessageAsync(context);

            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I'm having issues understanding you. Let's try again.");

                context.Done("");

            }
        }

        private async Task NiftyBankDialogResumeAfterAsync(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                var message = await result;
                await this.ShowIndicesMessageAsync(context);

            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I'm having issues understanding you. Let's try again.");
                context.Done("");

                //await this.SendWelcomeMessageAsync(context);
            }
        }

        private async Task NiftyItDialogResumeAfterAsync(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                var message = await result;
                await this.ShowIndicesMessageAsync(context);

            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I'm having issues understanding you. Let's try again.");
                context.Done("");
                //await this.SendWelcomeMessageAsync(context);
            }
                    }

        private async Task NiftyDialogResumeAfterAsync(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                var message = await result;
                await this.ShowIndicesMessageAsync(context);

            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I'm having issues understanding you. Let's try again.");

                context.Done("");

            }
        }

        private async Task SensexDialogResumeAfterAsync(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                var message = await result;
                await this.ShowIndicesMessageAsync(context);
            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I'm having issues understanding you. Let's try again.");

                context.Done("");

            }
        }
    }
}