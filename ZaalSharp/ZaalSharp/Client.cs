﻿using System;
using System.Linq;
using System.Threading.Tasks;
using ZaalSharp.Connector;
using ZaalSharp.Responses;

namespace ZaalSharp
{
    public class Client : IClient
    {
        /// <summary>
        /// A document as seen a in news articles can be classified based on different topics it addresses.
        /// Zaal uses a multi-label classification where each document can be assigned to a set of probabilistic scores representing the possibilities of having relations to various classes.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DocumentClassifierResponse> DocumentClassifier(Requests.DocumentClassifierRequest request)
        {
            var res =await HttpHelper.PostAsync<Requests.DocumentClassifierRequest, Responses.DocumentClassifierResponse>(Connector.ZaalSettings.ApiUrl,request);
            return res;
        }
        /// <summary>
        /// This a method is used for retrieving documents sentiment score (bearing emotional and sentimental tonality). 
        /// Given a document in Persian, this method returns a score in a range of [-1, +1] where +1 represents a highly positive opinion and -1 designates a high degree of negativity in the document.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Responses.DocumentSentimentResponse> DocumentSentiment(Requests.DocumentSentimentRequest request)
        {
            var res =await HttpHelper.PostAsync<Requests.DocumentSentimentRequest, Responses.DocumentSentimentResponse>(Connector.ZaalSettings.ApiUrl,request);
            return res;
        }

        /// <summary>
        /// There could be multiple segments of a document where each segment has its own sentiment score.
        /// This happens whenever there are various aspects of an entity or a concept in a document. 
        /// For example a comment about a new Samsung cellphone could contain a complement about its colour and also some complaints about its high price.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Responses.DocumentSentimentResponse> DocumentAspectSentiment(Requests.DocumentAspectSentimentRequest request)
        {
            var res =await HttpHelper.PostAsync<Requests.DocumentAspectSentimentRequest, Responses.DocumentSentimentResponse>(Connector.ZaalSettings.ApiUrl,request);
            return res;
        }

        /// <summary>
        /// One application of NLP is to extract synonyms of a word.
        /// Using this method you could get the k-nearest words similar to your word.
        //  In the early version of Zaal only 1-gram words are supported but we plan to include the support to n-grams.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Responses.WordSuggestorResponse> WordSuggestor(Requests.WordSuggestorRequest request)
        {
            var res =await HttpHelper.PostAsync<Requests.WordSuggestorRequest, Responses.WordSuggestorResponse>(Connector.ZaalSettings.ApiUrl,request);
            return res;
        }

        /// <summary>
        /// Keyword extractor (as the name suggests) extracts the most important words from a given text.
        //  This method extracts keywords and an importance score associated with each keyword from text.
        /// This could be used for tagging your documents for improving document search.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Responses.KeywordExtractorResponse> KeywordExtractor(Requests.KeyWordExtractorRequest request)
        {
            var res =await HttpHelper.PostAsync<Requests.KeyWordExtractorRequest, Responses.KeywordExtractorResponse>(Connector.ZaalSettings.ApiUrl,request);
            return res;
        }
    }
}
