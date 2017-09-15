using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownloader.JsonModel
{
    class ImageInfo
    {

        [JsonProperty("cb")]
        public int Cb { get; set; }

        [JsonProperty("cl")]
        public int Cl { get; set; }

        [JsonProperty("cr")]
        public int Cr { get; set; }

        [JsonProperty("ct")]
        public int Ct { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isu")]
        public string Domain { get; set; }

        [JsonProperty("itg")]
        public int Itg { get; set; }

        [JsonProperty("ity")]
        public string Extension { get; set; }

        [JsonProperty("oh")]
        public int Oh { get; set; }

        [JsonProperty("ou")]
        public string Path { get; set; }

        [JsonProperty("ow")]
        public int Ow { get; set; }

        [JsonProperty("pt")]
        public string PhotoTitle { get; set; }

        [JsonProperty("rid")]
        public string Rid { get; set; }

        [JsonProperty("rmt")]
        public int Rmt { get; set; }

        [JsonProperty("rt")]
        public int Rt { get; set; }

        [JsonProperty("ru")]
        public string Page { get; set; }

        [JsonProperty("s")]
        public string S { get; set; }

        [JsonProperty("sc")]
        public int Sc { get; set; }

        [JsonProperty("st")]
        public string SiteTitle { get; set; }

        [JsonProperty("th")]
        public int Th { get; set; }

        [JsonProperty("tu")]
        public string Tu { get; set; }

        [JsonProperty("tw")]
        public int Tw { get; set; }

    }
}
