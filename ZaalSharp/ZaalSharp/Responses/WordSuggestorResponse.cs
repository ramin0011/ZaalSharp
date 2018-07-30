using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ZaalSharp.Responses
{


    public  class WordSuggestorResponse
    {
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public WordSuggestorResults Results { get; set; }
    }

    public  class WordSuggestorResults
    {
        [JsonProperty("pay_load", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, double> PayLoad { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }

}
