using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEBot.Service.Models
{
    public class StockCodes
    {
        public string Symbol { get; set; }
        public string NameOfCompany { get; set; }
        public string Series { get; set; }
        public DateTime DateOfListing { get; set; }
        public double PaidUpValue { get; set; }
        public string ISINNumber { get; set; }
        public string FaceValue { get; set; }
    }

    public class StockCodesMap : ClassMap<StockCodes>
    {
        public StockCodesMap()
        {
            Map(m => m.Symbol).Index(0);
            Map(m => m.NameOfCompany).Index(1);
        }
    }
}
