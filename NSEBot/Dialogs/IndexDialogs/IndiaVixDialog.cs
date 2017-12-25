using AdaptiveCards;
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

    public class IndiaVixDialog : IDialog<string>
    {
        private string code;

        public async Task StartAsync(IDialogContext context)
        {
            this.code = "INDIAVIX";
            context.Wait(this.MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            IStockService nseService = new StockService();

            var resp = await nseService.GetIndexQuote(code);

            var current_price = resp.QuoteResponse.Result.FirstOrDefault().RegularMarketPrice.Fmt;
            var current_change = resp.QuoteResponse.Result.FirstOrDefault().RegularMarketChange.Fmt;

            var rich_msg = context.MakeMessage();

            AdaptiveCards.AdaptiveCard adaptiveCard = new AdaptiveCards.AdaptiveCard
            {
                Type = "AdaptiveCard",
                Version = "1.0"
            };

            string downOrUp = Double.Parse(current_change) > 0 ? "up" : "down";
            adaptiveCard.Speak = $"{code} is trading at {current_price} a share, which is {downOrUp} by {current_change}";

            var body = new List<AdaptiveCards.CardElement>();

            body.Add(new Container()
            {
                Items = new List<CardElement>()
                {
                    new TextBlock()
                    {
                        Text = "Microsoft Corp (NASDAQ: MSFT)",
                        Size = TextSize.Medium,
                        IsSubtle = true
                    },
                    new TextBlock()
                    {
                        Text = "September 19, 4:00 PM EST",
                        IsSubtle = true
                    }
                }
            });

            body.Add(new Container()
            {
                Items = new List<CardElement>()
                {
                    new ColumnSet()
                    {
                        Columns = new List<Column>()
                        {
                            new Column()
                            {
                                Size = ColumnSize.Stretch,
                                Items = new List<CardElement>()
                                {
                                    new TextBlock()
                                    {
                                        Text = "75.30",
                                        Size = TextSize.ExtraLarge
                                    },
                                    new TextBlock()
                                    {
                                        Text = "▼ 0.20 (0.32%)",
                                        Size = TextSize.Small,
                                        Color = TextColor.Attention
                                    },
                                }

                            },
                            new Column()
                            {
                                Size = ColumnSize.Auto,
                                Items = new List<CardElement>()
                                {
                                    new FactSet()
                                    {
                                        Facts = new List<AdaptiveCards.Fact>()
                                        {
                                            new AdaptiveCards.Fact(){
                                                Title = "Open",
                                                Value = "10000"
                                            },
                                            new AdaptiveCards.Fact(){
                                                Title = "High",
                                                Value = "10000"
                                            },
                                            new AdaptiveCards.Fact(){
                                                Title = "Low",
                                                Value = "10000"
                                            }

                                        }
                                    }

                                }


                            }
                        },


                    },
                    new ColumnSet()
                    {

                    }
                }
            });

            adaptiveCard.Body = body;

            rich_msg.Attachments.Add(new Attachment()
            {
                Content = adaptiveCard,
                ContentType = AdaptiveCard.ContentType
            });

            string msg = $"Index {code}. Current value {current_price}. Change from prev close - {current_change}";
            await context.PostAsync(rich_msg);

            context.Done(msg);

        }
    }
}