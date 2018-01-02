using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEBot.Service.Constants
{
    public class Urls
    {
        public readonly static string BloombergIndexList = "https://www.bloombergquint.com/feapi/markets/indices/indian-indices?duration=1D&tab=all";
        public readonly static string YahooIndexQuote = "https://query1.finance.yahoo.com/v7/finance/quote?formatted=true&crumb=PSoigjtfegE&lang=en-IN&region=IN&symbols=%5E{0}&fields=messageBoardId%2ClongName%2CshortName%2CmarketCap%2CunderlyingSymbol%2CunderlyingExchangeSymbol%2CheadSymbolAsString%2CregularMarketPrice%2CregularMarketChange%2CregularMarketChangePercent%2CregularMarketVolume%2Cuuid%2CregularMarketOpen%2CfiftyTwoWeekLow%2CfiftyTwoWeekHigh&corsDomain=in.finance.yahoo.com";
        public readonly static string YahooStockQuote = "https://query2.finance.yahoo.com/v7/finance/quote?formatted=true&crumb=PSoigjtfegE&lang=en-IN&region=IN&symbols={0}.NS&fields=messageBoardId%2ClongName%2CshortName%2CmarketCap%2CunderlyingSymbol%2CunderlyingExchangeSymbol%2CheadSymbolAsString%2CregularMarketPrice%2CregularMarketChange%2CregularMarketChangePercent%2CregularMarketVolume%2Cuuid%2CregularMarketOpen%2CfiftyTwoWeekLow%2CfiftyTwoWeekHigh&corsDomain=in.finance.yahoo.com";
        public readonly static string BloombergTopCharts = "https://www.bloombergquint.com/feapi/markets/indices/stock-stats?type={0}&filter_key=index&filter_value={1}&duration={2}";
    }
}
