using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ZaalSharp;
using ZaalSharp.Requests;

namespace ZaalSharpTest
{
    public class ClientTest
    {
        private Client _client = new Client();
        [Fact]
        public async Task DocumentClassifier()
        {
            var result =await _client.DocumentClassifier(new DocumentClassifierRequest()
            {
               Data = new DocumentClassifierArgsRequest()
               {
                   Document = "باید سهولت های جدیدی در قوانین صدور ویزا و دیگر مشوق ها و تسهیلات به گردشگران خارجی داده شود"
               }
            });
            Assert.NotNull(result.Results.PayLoad);
        }

        [Fact]
        public async Task DocumentSentiment()
        {
            var result = await _client.DocumentSentiment(new DocumentSentimentRequest()
            {
             Data = new DocumentSentimentInputRequest()
             {
                 Document = "گوشی بدرد نخوریه",
             }
            });
            Assert.True(result.Results.PayLoad.SentimentScore >= -1);
        }

        [Fact]
        public async Task DocumentAspectSentiment()
        {
            var result = await _client.DocumentAspectSentiment(new DocumentAspectSentimentRequest()
            {
                Data = new DocumentSentimentAnalyzerInputRequest()
                {
                    Document = "دوربین خیلی خوبی است. تو خریدش شک نکنید",
                    Aspect = "دوربین"
                }
            });
            Assert.True(result.Results.PayLoad.SentimentScore >= -1);
        }

        [Fact]
        public async Task WordSuggestor()
        {
            var result = await _client.WordSuggestor(new WordSuggestorRequest()
            {
             Data = new WordSuggestorInput()
             {
                 KNearest = 10,
                 Word = "ایرانی",
             }
            });
            Assert.True(!string.IsNullOrEmpty(result.Results.PayLoad.FirstOrDefault().Key));
        }

        [Fact]
        public async Task KeywordExtractor()
        {
            var result = await _client.KeywordExtractor(new KeyWordExtractorRequest()
            {
                Data = new KeyWordExtractorRequestInputRequest()
                {
                    Document = "طراح و برنامه‌نویس کسی است که می‌تواند با توجه به نیازمندی‌های روشنی که از تحلیلگر دریافت می‌کند، با استفاده از یک زبان برنامه نویسی، در چارچوب معماری مشخص، برنامه‌ای را تولید، تست و راه‌اندازی کند. این برنامه می‌تواند یک برنامه الگوریتمی و یا یک برنامه کاربردی باشد."
                }
            });
            Assert.NotNull(result.Results.PayLoad);
        }
    }
}
