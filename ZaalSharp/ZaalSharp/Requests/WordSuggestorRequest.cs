using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ZaalSharp.Requests.Base;

namespace ZaalSharp.Requests
{
    public class WordSuggestorInput
    {
        /// <summary>
        /// Word Input
        /// </summary>
        [JsonProperty("word")]
        public string Word { get; set; }
        [JsonProperty("k-neares")]
        public int KNearest { get; set; }
    }
    public class WordSuggestorRequest : BaseRequest
    {
        [JsonProperty("args")]
        public WordSuggestorInput Data { get; set; }

        public WordSuggestorRequest() : base(Base.Methods.WordSuggester)
        {
        }
    }
}
