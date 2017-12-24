using CsvHelper;
using CsvHelper.Configuration;
using NSEBot.Service.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NSEBot.Service
{
    public class NSEService : INSEService
    {
        private readonly string get_quote_url = "https://www.nseindia.com/live_market/dynaContent/live_watch/get_quote/GetQuote.jsp?";
        private readonly string stocks_csv_url = "http://www.nseindia.com/content/equities/EQUITY_L.csv";
        private readonly string top_gainer_url = "http://www.nseindia.com/live_market/dynaContent/live_analysis/gainers/niftyGainers1.json";
        private readonly string top_loser_url = "http://www.nseindia.com/live_market/dynaContent/live_analysis/losers/niftyLosers1.json";
        private readonly string advances_declines_url = "http://www.nseindia.com/common/json/indicesAdvanceDeclines.json";
        private readonly string index_url = "http://www.nseindia.com/homepage/Indices1.json";
        private readonly string bhavcopy_base_url = "https://www.nseindia.com/content/historical/EQUITIES/%s/%s/cm%s%s%sbhav.csv.zip";
        private readonly string bhavcopy_base_filename = "cm{0}{1}{2}bhav.csv";

        private HttpClient client;

        public NSEService()
        {

        }

        public HttpRequestMessage BuildNseHeaders(HttpRequestMessage request)
        {
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            request.Headers.Add("Host", "nseindia.com");
            request.Headers.Add("Referer", "https://www.nseindia.com/live_market/dynaContent/live_watch/get_quote/GetQuote.jsp?symbol=INFY&illiquid=0&smeFlag=0&itpFlag=0");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:28.0) Gecko/20100101 Firefox/28.0");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");

            return request;
        }

        public string BuildUrlForQuote(string code)
        {
            throw new NotImplementedException();
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

        public string GetIndexQuote(string code)
        {
            throw new NotImplementedException();
        }

        public string GetQuote(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetStockCodes()
        {
            string resp = string.Empty;
            using (HttpClient client = new HttpClient())
            {

                string url = this.stocks_csv_url;
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                request = BuildNseHeaders(request);

                var response = await client.SendAsync(request);

                using (TextReader input = new StreamReader(await response.Content.ReadAsStreamAsync()))
                {
                    var csv = new CsvReader(input);
                    csv.Configuration.RegisterClassMap<StockCodesMap>();
                    // Trim
                    csv.Configuration.PrepareHeaderForMatch = header => header?.Trim();

                    // Remove whitespace
                    csv.Configuration.PrepareHeaderForMatch = header => header.Replace(" ", string.Empty);

                    // Remove underscores
                    csv.Configuration.PrepareHeaderForMatch = header => header.Replace("_", string.Empty);

                    // Ignore case
                    csv.Configuration.PrepareHeaderForMatch = header => header.ToLower();
                    var records = csv.GetRecords<StockCodes>();

                    var count = records.Count();
                }


            };

            return resp;

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
