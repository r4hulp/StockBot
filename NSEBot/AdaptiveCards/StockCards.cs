using AdaptiveCards;
using AdaptiveCards.Rendering;
using NSEBot.Service.Enums;
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
                                        Color = stockObject.RegularMarketChange.Raw < 0 ? AdaptiveTextColor.Warning : AdaptiveTextColor.Accent
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
            var stockObject = data.quoteResponse.result.FirstOrDefault();
            var current_price = stockObject.regularMarketPrice.Fmt;
            var current_change = stockObject.regularMarketChange.Fmt;
            var code = stockObject.symbol;

            AdaptiveCard adaptiveCard = new AdaptiveCard
            {
                Type = "AdaptiveCard",
                Version = "1.0"
            };


            string downOrUp = Double.Parse(current_change) > 0 ? "up" : "down";
            adaptiveCard.Speak = $"{code} is trading at {current_price} a share, which is {downOrUp} by {current_change}";

            string up = "▲ ";
            string down = "▼ ";

            string value_change_string = stockObject.regularMarketChange.Raw < 0 ?
                $"{down} {stockObject.regularMarketChange.Fmt} ({stockObject.regularMarketChangePercent.Fmt})" :
                $"{up} {stockObject.regularMarketChange.Fmt} ({stockObject.regularMarketChangePercent.Fmt})";

            var body = new List<AdaptiveElement>
            {
                new AdaptiveContainer()
                {
                    Items = new List<AdaptiveElement>()
                {
                    new AdaptiveTextBlock()
                    {
                        Text = $"{stockObject.shortName} ({stockObject.symbol})",
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
                                        Text = stockObject.regularMarketPrice.Fmt,
                                        Size = AdaptiveTextSize.ExtraLarge
                                    },
                                    new AdaptiveTextBlock()
                                    {
                                        Text = value_change_string,
                                        Size = AdaptiveTextSize.Small,
                                        Color = stockObject.regularMarketChange.Raw < 0 ? AdaptiveTextColor.Warning : AdaptiveTextColor.Accent
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
                                            new AdaptiveFact("Open", stockObject.regularMarketOpen.Fmt),
                                            new AdaptiveFact("High", stockObject.regularMarketDayHigh.Fmt),
                                            new AdaptiveFact("Close", stockObject.regularMarketDayLow.Fmt),

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

        public static AdaptiveCard GetTopCharts(TopCharts chart, TrendType trend)
        {
            AdaptiveCard adaptiveCard = new AdaptiveCard();

            ContainerStylesConfig config = new ContainerStylesConfig();
            config.Default.ForegroundColors.Good = new FontColorConfig("#4caf50", "#8bc34a");

            AdaptiveHostConfig adaptiveHostConfig = new AdaptiveHostConfig();

            var top_charts = trend == TrendType.Gainer ? chart.Data.OrderByDescending(dt => dt.ChangePercent).Take(15) : chart.Data.OrderBy(dt => dt.ChangePercent).Take(15);

            var body = new List<AdaptiveElement>();

            var first_col_items = new List<AdaptiveElement>()
            {
                new AdaptiveTextBlock()
                {
                    Text = "Company",
                    Weight = AdaptiveTextWeight.Bolder,
                    Wrap = false
                }
            };

            foreach (var stock in top_charts)
            {
                first_col_items.Add(new AdaptiveTextBlock()
                {
                    Text = stock.Name,
                    Weight = AdaptiveTextWeight.Lighter,
                    Wrap = false
                });
            };

            var change_col_items = new List<AdaptiveElement>()
            {
                new AdaptiveTextBlock()
                {
                    Text = "Change",
                    Weight = AdaptiveTextWeight.Bolder,
                    Wrap = false
                }
            };


            foreach (var stock in top_charts)
            {
                var upOrDown = stock.Change < 0 ? "▼" : "▲";

                change_col_items.Add(new AdaptiveTextBlock()
                {
                    Text = $"{upOrDown} {stock.ChangePercent.ToString()}",
                    Weight = AdaptiveTextWeight.Bolder,
                    Color = stock.Change < 0 ? AdaptiveTextColor.Warning: AdaptiveTextColor.Accent,
                    Wrap = false
                });
            }

            var second_col_items = new List<AdaptiveElement>()
            {
                new AdaptiveTextBlock()
                {
                    Text = "CMP",
                    Weight = AdaptiveTextWeight.Bolder,
                    Wrap = false
                }
            };

            foreach (var stock in top_charts)
            {
                second_col_items.Add(new AdaptiveTextBlock()
                {
                    Text = stock.LastPrice.ToString(),
                    Weight = AdaptiveTextWeight.Lighter,
                    Wrap = false
                });
            }

            var third_col_items = new List<AdaptiveElement>()
            {
                new AdaptiveTextBlock()
                {
                    Text = "Day High",
                    Weight = AdaptiveTextWeight.Bolder,
                    Wrap = false
                }
            };

            foreach (var stock in top_charts)
            {
                third_col_items.Add(new AdaptiveTextBlock()
                {
                    Text = stock.High.ToString(),
                    Weight = AdaptiveTextWeight.Lighter,
                    Wrap = false
                });
            }

            var fourth_col_items = new List<AdaptiveElement>()
            {
                new AdaptiveTextBlock()
                {
                    Text = "Day Low",
                    Weight = AdaptiveTextWeight.Bolder,
                    Wrap = false
                }
            };

            foreach (var stock in top_charts)
            {
                fourth_col_items.Add(new AdaptiveTextBlock()
                {
                    Text = stock.Low.ToString(),
                    Weight = AdaptiveTextWeight.Lighter,
                    Wrap = false
                });
            }

            body.Add(new AdaptiveContainer()
            {
                Items = new List<AdaptiveElement>()
                {
                    new AdaptiveTextBlock()
                    {
                        Text = trend == TrendType.Gainer ? "Top Gainers" : "Top Losers",
                        Weight = AdaptiveTextWeight.Bolder,
                        Size = AdaptiveTextSize.Medium
                    },
                    new AdaptiveColumnSet()
                    {
                        Columns = new List<AdaptiveColumn>()
                        {
                            new AdaptiveColumn()
                            {
                                Width = AdaptiveColumnWidth.Auto,
                                Items = first_col_items
                            },
                            new AdaptiveColumn()
                            {
                                Width = AdaptiveColumnWidth.Auto,
                                Items = change_col_items
                            },
                            new AdaptiveColumn()
                            {
                                Width = AdaptiveColumnWidth.Auto,
                                Items = second_col_items
                            },
                            new AdaptiveColumn()
                            {
                                Width = AdaptiveColumnWidth.Auto,
                                Items = third_col_items
                            },
                            new AdaptiveColumn()
                            {
                                Width = AdaptiveColumnWidth.Auto,
                                Items = fourth_col_items
                            },
                        }
                    }
                }

            });

            adaptiveCard.Body = body;

            return adaptiveCard;

        }
    }
}