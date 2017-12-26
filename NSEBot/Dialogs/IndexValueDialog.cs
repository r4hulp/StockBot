using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using NSEBot.Dialogs.IndexDialogs;
using NSEBot.Service;
using NSEBot.Service.Models;
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

        private BloombergIndices indices = null;


        public async Task StartAsync(IDialogContext context)
        {
            //await context.PostAsync("Enter index code.");
            IStockService stockService = new StockService();

            indices = await stockService.GetIndexList();


            await this.ShowIndicesMessageAsync(context);

        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;



            //show different indices
            await this.ShowIndicesMessageAsync(context);


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
            int bloomberg_code = 1;
            if (message.Text == "SENSEX")
            {
                code = "BSESN";
                bloomberg_code = GetIndexCode("SENSEX");
            }
            else if (message.Text == "NIFTY 50")
            {
                code = "NSEI";
                bloomberg_code = GetIndexCode("NIFTY");
            }
            else if (message.Text == "NIFTY IT")
            {
                code = "CNXIT";
                bloomberg_code = GetIndexCode("NIFTYIT");

            }
            else if (message.Text == "NIFTY BANK")
            {
                code = "NSEBANK";
                bloomberg_code = GetIndexCode("BANKNIFTY");
            }
            else if (message.Text == "INDIA VIX")
            {
                code = "INDIAVIX";
                bloomberg_code = GetIndexCode("INDIA VIX");
            }
            else if (message.Text == "Other")
            {
                context.Call(new OtherIndexDialog(), this.OtherIndexDialogResumeAfterAsync);
                return;
            }
            else if (message.Text == "Go back")
            {
                context.Done("");
                return;
            }

            context.Call(new IndexDialog(code, bloomberg_code), this.IndexDialogResumeAfter);

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


        private async Task IndexDialogResumeAfter(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                var message = await result;

                if(message.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                {
                    context.Done("");
                    return;
                }

                await this.ShowIndicesMessageAsync(context);
            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I'm having issues understanding you. Let's try again.");

                context.Done("");

            }
        }

        private int GetIndexCode(string name)
        {
            if (indices.Data.FirstOrDefault(d => d.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)) != null)
                return indices.Data.FirstOrDefault(d => d.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Id;
            else
                return 1;
        }
    }
}