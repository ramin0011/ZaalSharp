using System;
using System.Collections.Generic;
using System.Text;

namespace ZaalSharp.Requests.Base
{
    public class BaseRequest
    {
        public BaseRequest(string method)
        {
            this.Method = method;
        }
        public string Method { get; set; }
    }

    public class Methods
    {
        public const string DocumentClassifier = "document_classifier";
        public const string SentimentAnalyzer = "sentiment_analyzer";
        public const string AspectSentimentAnalyzer = "aspect_sentiment_analyzer";
        public const string WordSuggester = "word_suggester";
        public const string KeywordExtractor = "keyword_extractor";
    }
}
