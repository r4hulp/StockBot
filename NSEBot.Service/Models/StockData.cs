using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEBot.Service.Models
{
    //public class FiftyTwoWeekLowChangePercent
    //{
    //    public double raw { get; set; }
    //    public string fmt { get; set; }
    //}

    //public class RegularMarketOpen
    //{
    //    public double raw { get; set; }
    //    public string fmt { get; set; }
    //}

    //public class RegularMarketTime
    //{
    //    public int raw { get; set; }
    //    public string fmt { get; set; }
    //}

    //public class RegularMarketChangePercent
    //{
    //    public double raw { get; set; }
    //    public string fmt { get; set; }
    //}

    //public class FiftyTwoWeekLowChange
    //{
    //    public double raw { get; set; }
    //    public string fmt { get; set; }
    //}

    //public class FiftyTwoWeekHighChangePercent
    //{
    //    public double raw { get; set; }
    //    public string fmt { get; set; }
    //}

    //public class RegularMarketDayHigh
    //{
    //    public double raw { get; set; }
    //    public string fmt { get; set; }
    //}

    //public class SharesOutstanding
    //{
    //    public long raw { get; set; }
    //    public string fmt { get; set; }
    //    public string longFmt { get; set; }
    //}

    //public class FiftyTwoWeekHigh
    //{
    //    public double raw { get; set; }
    //    public string fmt { get; set; }
    //}

    //public class RegularMarketPreviousClose
    //{
    //    public double raw { get; set; }
    //    public string fmt { get; set; }
    //}

    //public class FiftyTwoWeekHighChange
    //{
    //    public double raw { get; set; }
    //    public string fmt { get; set; }
    //}

    //public class MarketCap
    //{
    //    public long raw { get; set; }
    //    public string fmt { get; set; }
    //    public string longFmt { get; set; }
    //}

    //public class RegularMarketChange
    //{
    //    public double raw { get; set; }
    //    public string fmt { get; set; }
    //}

    //public class RegularMarketPrice
    //{
    //    public double raw { get; set; }
    //    public string fmt { get; set; }
    //}

    //public class FiftyTwoWeekLow
    //{
    //    public double raw { get; set; }
    //    public string fmt { get; set; }
    //}

    //public class RegularMarketVolume
    //{
    //    public int raw { get; set; }
    //    public string fmt { get; set; }
    //    public string longFmt { get; set; }
    //}

    //public class RegularMarketDayLow
    //{
    //    public double raw { get; set; }
    //    public string fmt { get; set; }
    //}

    public class Result
    {
        public string fullExchangeName { get; set; }
        public string symbol { get; set; }
        public RawValue fiftyTwoWeekLowChangePercent { get; set; }
        public int gmtOffSetMilliseconds { get; set; }
        public RawValue regularMarketOpen { get; set; }
        public string language { get; set; }
        public RawValue regularMarketTime { get; set; }
        public RawValue regularMarketChangePercent { get; set; }
        public string uuid { get; set; }
        public string quoteType { get; set; }
        public RawValue fiftyTwoWeekLowChange { get; set; }
        public RawValue fiftyTwoWeekHighChangePercent { get; set; }
        public RawValue regularMarketDayHigh { get; set; }
        public bool tradeable { get; set; }
        public string currency { get; set; }
        public RawValue sharesOutstanding { get; set; }
        public RawValue fiftyTwoWeekHigh { get; set; }
        public RawValue regularMarketPreviousClose { get; set; }
        public string exchangeTimezoneName { get; set; }
        public RawValue fiftyTwoWeekHighChange { get; set; }
        public RawValue marketCap { get; set; }
        public RawValue regularMarketChange { get; set; }
        public int exchangeDataDelayedBy { get; set; }
        public string exchangeTimezoneShortName { get; set; }
        public RawValue regularMarketPrice { get; set; }
        public string marketState { get; set; }
        public RawValue fiftyTwoWeekLow { get; set; }
        public RawValue regularMarketVolume { get; set; }
        public string market { get; set; }
        public string messageBoardId { get; set; }
        public int priceHint { get; set; }
        public string exchange { get; set; }
        public int sourceInterval { get; set; }
        public RawValue regularMarketDayLow { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
    }

    public class QuoteResponse
    {
        public List<Result> result { get; set; }
        public object error { get; set; }
    }

    public class StockData
    {

        public StockData()
        {
            Time = DateTime.Now;
        }
        public QuoteResponse quoteResponse { get; set; }
        public DateTime Time { get; set; }
    }



}
