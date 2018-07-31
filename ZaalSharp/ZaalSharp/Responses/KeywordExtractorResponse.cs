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
        [JsonProperty("pay_load", TypeNameHandling = TypeNameHandling.Auto)]
        public Dictionary<string, double> PayLoad { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }  
    }
}
