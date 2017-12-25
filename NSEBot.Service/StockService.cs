using CsvHelper;
using CsvHelper.Configuration;
using HtmlAgilityPack;
using Newtonsoft.Json;
using NSEBot.Service.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NSEBot.Service
{
    public class StockService : IStockService
    {

        private HttpClient client;

        public StockService()
        {

        }

        public HttpRequestMessage BuildNseHeaders(HttpRequestMessage request)
        {
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            //request.Headers.Add("Host", "nseindia.com");
            //request.Headers.Add("Referer", "http://query1.finance.yahoo.com/v8/finance/chart/INFY.NS?range=1d&includePrePost=false&interval=1h&corsDomain=in.finance.yahoo.com&.tsrc=finance");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:28.0) Gecko/20100101 Firefox/28.0");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");

            return request;
        }


        public string CleanServerResponse(string responseDictionary)
        {
            throw new NotImplementedException();
        }

        public string DownloadBhavCopy(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAdvancesDeclines()
        {
            throw new NotImplementedException();
        }

        public string GetBhavcopyFilename(DateTime d)
        {
            throw new NotImplementedException();
        }

        public string GetBhavcopyUrl(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<string> GetIndexList()
        {
            throw new NotImplementedException();
        }

        public async Task<IndexData> GetIndexQuote(string code)
        {
            //

            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string url = $"https://query1.finance.yahoo.com/v7/finance/quote?formatted=true&crumb=PSoigjtfegE&lang=en-IN&region=IN&symbols=%5E{code}&fields=messageBoardId%2ClongName%2CshortName%2CmarketCap%2CunderlyingSymbol%2CunderlyingExchangeSymbol%2CheadSymbolAsString%2CregularMarketPrice%2CregularMarketChange%2CregularMarketChangePercent%2CregularMarketVolume%2Cuuid%2CregularMarketOpen%2CfiftyTwoWeekLow%2CfiftyTwoWeekHigh&corsDomain=in.finance.yahoo.com";
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                    request = BuildNseHeaders(request);

                    var response = await client.SendAsync(request);

                    var html = await response.Content.ReadAsStringAsync();

                    var parsedData = JsonConvert.DeserializeObject<IndexData>(html);

                    return parsedData;
                };

            }
            catch (Exception ex)
            {

                //log this
            }
            return null;
        }

        public async Task<StockData> GetQuote(string code)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string url = $"https://query2.finance.yahoo.com/v7/finance/quote?formatted=true&crumb=PSoigjtfegE&lang=en-IN&region=IN&symbols={code}.NS&fields=messageBoardId%2ClongName%2CshortName%2CmarketCap%2CunderlyingSymbol%2CunderlyingExchangeSymbol%2CheadSymbolAsString%2CregularMarketPrice%2CregularMarketChange%2CregularMarketChangePercent%2CregularMarketVolume%2Cuuid%2CregularMarketOpen%2CfiftyTwoWeekLow%2CfiftyTwoWeekHigh&corsDomain=in.finance.yahoo.com";
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                    request = BuildNseHeaders(request);

                    var response = await client.SendAsync(request);

                    var html = await response.Content.ReadAsStringAsync();

                    var parsedData = JsonConvert.DeserializeObject<StockData>(html);

                    return parsedData;
                };

            }
            catch (Exception ex)
            {

                //log this
            }
            return null;
        }

        public List<string> GetTopGainers()
        {
            throw new NotImplementedException();
        }

        public List<string> GetTopLosers()
        {
            throw new NotImplementedException();
        }

        public bool IsValidCode(string code)
        {
            throw new NotImplementedException();
        }

        public bool IsValidIndex(string code)
        {
            throw new NotImplementedException();
        }

        public string RenderResponse(string data)
        {
            throw new NotImplementedException();
        }
    }

}
