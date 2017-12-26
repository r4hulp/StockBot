using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEBot.Service.Models
{


    public class TopGainersData
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("last-price")]
        public double LastPrice { get; set; }

        [JsonProperty("chg")]
        public double Change { get; set; }

        [JsonProperty("chgp")]
        public double ChangePercent { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("52wk-high")]
        public double FIftyTwoWkHigh { get; set; }

        [JsonProperty("52wk-low")]
        public double FiftyTwoWkLow { get; set; }
    }

    public class TopCharts
    {

        [JsonProperty("delayed")]
        public bool Delayed { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public IList<TopGainersData> Data { get; set; }

        [JsonProperty("updated-at")]
        public long UpdatedAt { get; set; }
    }


}
