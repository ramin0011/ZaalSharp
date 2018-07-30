using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ZaalSharp.Requests.Base;

namespace ZaalSharp.Requests
{
    public class KeyWordExtractorRequestInputRequest
    {
        public string Document { get; set; }
    }
    public class KeyWordExtractorRequest :BaseRequest
    {
        /// <summary>
        /// Data is the same 'args' defined in the api request
        /// </summary>
        [JsonProperty("args")]
        public KeyWordExtractorRequestInputRequest Data { get; set; }

        public KeyWordExtractorRequest() : base(Base.Methods.KeywordExtractor)
        {
        }
    }
}
