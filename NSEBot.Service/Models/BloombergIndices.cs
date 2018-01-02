using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEBot.Service.Models
{
    [Serializable]

    public class PriceMovement : BaseSerializableClass
    {

        [JsonProperty("current-price")]
        public double CurrentPrice { get; set; }

        [JsonProperty("chg")]
        public double Chg { get; set; }

        [JsonProperty("chgp")]
        public double Chgp { get; set; }
    }
    [Serializable]

    public class IndicesData : BaseSerializableClass
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sname")]
        public string Sname { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("price-movement")]
        public PriceMovement PriceMovement { get; set; }
    }
    [Serializable]
    public class BloombergIndices : BaseSerializableClass
    {

        [JsonProperty("delayed")]
        public bool Delayed { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public IList<IndicesData> Data { get; set; }

        [JsonProperty("updated-at")]
        public long UpdatedAt { get; set; }
    }

    [Serializable]
    public class BaseSerializableClass
    {

    }
}
