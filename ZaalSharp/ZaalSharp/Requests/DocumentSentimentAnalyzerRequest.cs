using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ZaalSharp.Requests.Base;

namespace ZaalSharp.Requests
{
    public class DocumentSentimentAnalyzerInputRequest
    {
        public string Document { get; set; }
        public string Aspect { get; set; }
    }

    public class DocumentAspectSentimentRequest : BaseRequest
    {
        /// <summary>
        /// Data is the same 'args' defined in the api request
        /// </summary>
        [JsonProperty("args")]
        public DocumentSentimentAnalyzerInputRequest Data { get; set; }

        public DocumentAspectSentimentRequest() : base(Base.Methods.AspectSentimentAnalyzer)
        {
        }
    }
}
