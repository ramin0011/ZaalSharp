using Newtonsoft.Json;

namespace ZaalSharp.Responses
{


    public  class DocumentSentimentResponse
    {
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public DocumentSentimentData Results { get; set; }
    }

    public  class DocumentSentimentData
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("pay_load", NullValueHandling = NullValueHandling.Ignore)]
        public DocumentSentimentPayLoad PayLoad { get; set; }
    }

    public  class DocumentSentimentPayLoad
    {
        [JsonProperty("sentiment_score", NullValueHandling = NullValueHandling.Ignore)]
        public double? SentimentScore { get; set; }
    }
}
