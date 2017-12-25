using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEBot.Service.Models
{
    public class RawValue
    {

        [JsonProperty("raw")]
        public double Raw { get; set; }

        [JsonProperty("fmt")]
        public string Fmt { get; set; }

        [JsonProperty("longFmt")]
        public string LongFmt { get; set; }
    }


    public class IndexResult
    {

        [JsonProperty("fullExchangeName")]
        public string FullExchangeName { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("fiftyTwoWeekLowChangePercent")]
        public RawValue FiftyTwoWeekLowChangePercent { get; set; }

        [JsonProperty("gmtOffSetMilliseconds")]
        public int GmtOffSetMilliseconds { get; set; }

        [JsonProperty("regularMarketOpen")]
        public RawValue RegularMarketOpen { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("regularMarketTime")]
        public RawValue RegularMarketTime { get; set; }

        [JsonProperty("regularMarketChangePercent")]
        public RawValue RegularMarketChangePercent { get; set; }

        [JsonProperty("quoteType")]
        public string QuoteType { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("fiftyTwoWeekLowChange")]
        public RawValue FiftyTwoWeekLowChange { get; set; }

        [JsonProperty("fiftyTwoWeekHighChangePercent")]
        public RawValue FiftyTwoWeekHighChangePercent { get; set; }

        [JsonProperty("regularMarketDayHigh")]
        public RawValue RegularMarketDayHigh { get; set; }

        [JsonProperty("tradeable")]
        public bool Tradeable { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("fiftyTwoWeekHigh")]
        public RawValue FiftyTwoWeekHigh { get; set; }

        [JsonProperty("regularMarketPreviousClose")]
        public RawValue RegularMarketPreviousClose { get; set; }

        [JsonProperty("exchangeTimezoneName")]
        public string ExchangeTimezoneName { get; set; }

        [JsonProperty("fiftyTwoWeekHighChange")]
        public RawValue FiftyTwoWeekHighChange { get; set; }

        [JsonProperty("regularMarketChange")]
        public RawValue RegularMarketChange { get; set; }

        [JsonProperty("exchangeDataDelayedBy")]
        public int ExchangeDataDelayedBy { get; set; }

        [JsonProperty("exchangeTimezoneShortName")]
        public string ExchangeTimezoneShortName { get; set; }

        [JsonProperty("fiftyTwoWeekLow")]
        public RawValue FiftyTwoWeekLow { get; set; }

        [JsonProperty("marketState")]
        public string MarketState { get; set; }

        [JsonProperty("regularMarketPrice")]
        public RawValue RegularMarketPrice { get; set; }

        [JsonProperty("market")]
        public string Market { get; set; }

        [JsonProperty("regularMarketVolume")]
        public RawValue RegularMarketVolume { get; set; }

        [JsonProperty("messageBoardId")]
        public string MessageBoardId { get; set; }

        [JsonProperty("priceHint")]
        public int PriceHint { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; }

        [JsonProperty("sourceInterval")]
        public int SourceInterval { get; set; }

        [JsonProperty("regularMarketDayLow")]
        public RawValue RegularMarketDayLow { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }
    }

    public class IndexQuoteResponse
    {

        [JsonProperty("result")]
        public IList<IndexResult> Result { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }
    }

    public class IndexData
    {

        [JsonProperty("quoteResponse")]
        public IndexQuoteResponse QuoteResponse { get; set; }
    }
}
