using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ZaalSharp.Responses
{
    public class KeywordExtractorResponse
    {
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public KeywordExtractortData Results { get; set; }
    }

    public class KeywordExtractortData
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("pay_load", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<double,string> PayLoad { get; set; }
    }
}
