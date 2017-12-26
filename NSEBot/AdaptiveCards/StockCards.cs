using AdaptiveCards;
using NSEBot.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSEBot.AdaptiveCards
{
    public static class StockCards
    {
        public static AdaptiveCard GetIndexCard(IndexData data)
        {

            var stockObject = data.QuoteResponse.Result.FirstOrDefault();
            var current_price = stockObject.RegularMarketPrice.Fmt;
            var current_change = stockObject.RegularMarketChange.Fmt;
            var code = stockObject.Symbol;

            AdaptiveCard adaptiveCard = new AdaptiveCard
            {
                Type = "AdaptiveCard",
                Version = "1.0"
            };


            string downOrUp = Double.Parse(current_change) > 0 ? "up" : "down";
            adaptiveCard.Speak = $"{code} is trading at {current_price} a share, which is {downOrUp} by {current_change}";

            string up = "▲ ";
            string down = "▼ ";

            string value_change_string = stockObject.RegularMarketChange.Raw < 0 ?
                $"{down} {stockObject.RegularMarketChange.Fmt} ({stockObject.RegularMarketChangePercent.Fmt})" :
                $"{up} {stockObject.RegularMarketChange.Fmt} ({stockObject.RegularMarketChangePercent.Fmt})";

            var body = new List<AdaptiveElement>
            {
                //new AdaptiveContainer()
                //{
                //    Items = new List<AdaptiveElement>()
                //    {
                //        new AdaptiveTextBlock()
                //        {
                //            Text = stockObject.FullExchangeName,
                //            Size  = AdaptiveTextSize.Medium,
                //            IsSubtle = true
                //        },
                //        new AdaptiveTextBlock()
                //        {
                //            Text = data.Time.ToShortTimeString(),
                //            IsSubtle = true
                //        }
                //    }
                //},


                new AdaptiveContainer()
                {
                    Items = new List<AdaptiveElement>()
                {
                    new AdaptiveTextBlock()
                    {
                        Text = $"{stockObject.ShortName} ({stockObject.Symbol})",
                        Size = AdaptiveTextSize.Medium,
                        IsSubtle = true
                    },
                    new AdaptiveTextBlock()
                    {
                        Text = data.Time.ToShortTimeString(),
                        IsSubtle = true
                    }
                }
                },


                new AdaptiveContainer()
                {
                    Items = new List<AdaptiveElement>()
                {
                    new AdaptiveColumnSet()
                    {
                        Columns = new List<AdaptiveColumn>()
                        {
                            new AdaptiveColumn()
                            {
                                Width = AdaptiveColumnWidth.Stretch,
                                Items = new List<AdaptiveElement>()
                                {
                                    new AdaptiveTextBlock()
                                    {
                                        Text = stockObject.RegularMarketPrice.Fmt,
                                        Size = AdaptiveTextSize.ExtraLarge
                                    },
                                    new AdaptiveTextBlock()
                                    {
                                        Text = value_change_string,
                                        Size = AdaptiveTextSize.Small,
                                        Color = stockObject.RegularMarketChange.Raw < 0 ? AdaptiveTextColor.Warning : AdaptiveTextColor.Good
                                    },
                                }

                            },
                            new AdaptiveColumn()
                            {
                                Width = AdaptiveColumnWidth.Auto,
                                Items = new List<AdaptiveElement>()
                                {
                                    new AdaptiveFactSet()
                                    {
                                        Facts = new List<AdaptiveFact>()
                                        {
                                            new AdaptiveFact("Open", stockObject.RegularMarketOpen.Fmt),
                                            new AdaptiveFact("High", stockObject.RegularMarketDayHigh.Fmt),
                                            new AdaptiveFact("Close", stockObject.RegularMarketDayLow.Fmt),

                                        }
                                    }

                                }


                            }
                        },
                    }
                    //},
                    //new AdaptiveColumnSet()
                    //{

                    //}
                }
                }
            };

            adaptiveCard.Body = body;

            return adaptiveCard;
        }

        public static AdaptiveCard GetStockCard(StockData data)
        {
            return null;
        }
    }
}