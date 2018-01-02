using NSEBot.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NSEBot.Service
{
    public interface IStockService
    {
        bool IsValidCode(string code);

        Task<StockData> GetQuote(string code);

        Task<TopCharts> GetTopGainers(int indexValue, string duration);

        Task<TopCharts> GetTopLosers(int indexValue, string duration);

        List<string> GetAdvancesDeclines();

        Task<BloombergIndices> GetIndexList();

        bool IsValidIndex(string code);

        Task<IndexData> GetIndexQuote(string code);

        HttpRequestMessage BuildNseHeaders(HttpRequestMessage request);

        string CleanServerResponse(string responseDictionary);

        string RenderResponse(string data);


        string GetBhavcopyUrl(DateTime date);

        string DownloadBhavCopy(DateTime date);

        string GetBhavcopyFilename(DateTime d);

    }
}
