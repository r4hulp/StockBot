using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.ConnectorEx;
using NSEBot.Service;

namespace NSEBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private string name;
        private int age;

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            /* When MessageReceivedAsync is called, it's passed an IAwaitable<IMessageActivity>. To get the message,
             *  await the result. */
            var message = await result;

            await this.SendWelcomeMessageAsync(context);
        }

        private async Task SendWelcomeMessageAsync(IDialogContext context)
        {
            //await context.PostAsync("Enter Stock codename to get current value.");
            var reply = context.MakeMessage();


            var options = new[]
            {
                "Check Indices", "Check Stock Price"
            };
            reply.AddHeroCard("Select action", options, null);

            await context.PostAsync(reply);

            context.Wait(this.OnOptionSelected);
        }

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            if (message.Text == "Check Indices")
            {
                context.Call(new IndexValueDialog(), this.IndexValueDialogAfter);
            }
            else if (message.Text == "Check Stock Price")
            {
                context.Call(new PriceCheckDialog(), this.PriceCheckDialogResumeAfter);
            }
            else
            {
                //await this.StartOverAsync(context, Resources.RootDialog_Welcome_Error);
            }
        }

        private async Task IndexValueDialogAfter(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                var message = await result;

                await context.PostAsync(message);

                //context.Call(new IndexValueDialog(), this.IndexValueDialogAfter);
            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I'm having issues understanding you. Let's try again.");

                await this.SendWelcomeMessageAsync(context);
            }
        }
        private async Task PriceCheckDialogResumeAfter(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                var message = await result;


                await context.PostAsync(message);
            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I'm having issues understanding you. Let's try again.");

                await this.SendWelcomeMessageAsync(context);
            }
        }

        private async Task StartOverAsync(IDialogContext context, string text)
        {
            var message = context.MakeMessage();
            message.Text = text;
            await this.StartOverAsync(context, message);
        }

        private async Task StartOverAsync(IDialogContext context, IMessageActivity message)
        {
            //await context.PostAsync(message);
            await this.SendWelcomeMessageAsync(context);
        }

    }
}