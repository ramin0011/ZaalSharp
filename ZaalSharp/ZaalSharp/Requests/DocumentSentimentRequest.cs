using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ZaalSharp.Requests.Base;

namespace ZaalSharp.Requests
{
    public class DocumentSentimentInputRequest
    {
        public string Document { get; set; }
    }

    public class DocumentSentimentRequest :BaseRequest
    {
        /// <summary>
        /// Data is the same 'args' defined in the api request
        /// </summary>
        [JsonProperty("args")]
        public DocumentSentimentInputRequest Data { get; set; }

        public DocumentSentimentRequest() : base(Base.Methods.SentimentAnalyzer)
        {
        }
    }
}
