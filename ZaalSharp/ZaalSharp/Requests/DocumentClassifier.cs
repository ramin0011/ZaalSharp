using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ZaalSharp.Requests.Base;

namespace ZaalSharp.Requests
{
    public class DocumentClassifierArgsRequest
    {
        public string Document { get; set; }
    }

    public class DocumentClassifierRequest :BaseRequest
    {
        /// <summary>
        /// Data is the same 'args' defined in the api request
        /// </summary>
        [JsonProperty("args")]
        public DocumentClassifierArgsRequest Data { get; set; }

        public DocumentClassifierRequest() : base(Base.Methods.DocumentClassifier)
        {
        }
    }
}
