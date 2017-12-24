using NSEBot.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NSEBot.Service
{
    public interface INSEService
    {
        bool IsValidCode(string code);

        Task<StockData> GetQuote(string code);



        List<string> GetTopGainers();

        List<string> GetTopLosers();

        List<string> GetAdvancesDeclines();

        List<string> GetIndexList();

        bool IsValidIndex(string code);

        string GetIndexQuote(string code);

        HttpRequestMessage BuildNseHeaders(HttpRequestMessage request);

        string CleanServerResponse(string responseDictionary);

        string RenderResponse(string data);


        string GetBhavcopyUrl(DateTime date);

        string DownloadBhavCopy(DateTime date);

        string GetBhavcopyFilename(DateTime d);

    }
}
