using Newtonsoft.Json;

namespace ZaalSharp.Responses
{
    public  class DocumentClassifierResponse
    {
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public DocumentClassifierResults Results { get; set; }
    }

    public  class DocumentClassifierResults
    {
        [JsonProperty("pay_load", NullValueHandling = NullValueHandling.Ignore)]
        public DocumentClassifierPayLoad PayLoad { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }

    public  class DocumentClassifierPayLoad
    {
        [JsonProperty("Social_Education", NullValueHandling = NullValueHandling.Ignore)]
        public long? SocialEducation { get; set; }

        [JsonProperty("Sports", NullValueHandling = NullValueHandling.Ignore)]
        public double? Sports { get; set; }

        [JsonProperty("Industry_Insurance", NullValueHandling = NullValueHandling.Ignore)]
        public long? IndustryInsurance { get; set; }

        [JsonProperty("Entertainment", NullValueHandling = NullValueHandling.Ignore)]
        public long? Entertainment { get; set; }

        [JsonProperty("Social_Family", NullValueHandling = NullValueHandling.Ignore)]
        public long? SocialFamily { get; set; }

        [JsonProperty("Medical", NullValueHandling = NullValueHandling.Ignore)]
        public long? Medical { get; set; }

        [JsonProperty("Industry_Transportation", NullValueHandling = NullValueHandling.Ignore)]
        public long? IndustryTransportation { get; set; }

        [JsonProperty("Politics_Foreign", NullValueHandling = NullValueHandling.Ignore)]
        public double? PoliticsForeign { get; set; }

        [JsonProperty("Culture_Art", NullValueHandling = NullValueHandling.Ignore)]
        public long? CultureArt { get; set; }

        [JsonProperty("Industry_Technology", NullValueHandling = NullValueHandling.Ignore)]
        public long? IndustryTechnology { get; set; }

        [JsonProperty("Culture_Tourism", NullValueHandling = NullValueHandling.Ignore)]
        public long? CultureTourism { get; set; }

        [JsonProperty("Politics_Internal", NullValueHandling = NullValueHandling.Ignore)]
        public double? PoliticsInternal { get; set; }

        [JsonProperty("Social_Urban", NullValueHandling = NullValueHandling.Ignore)]
        public long? SocialUrban { get; set; }

        [JsonProperty("Industry_Automoblie Manufacturing", NullValueHandling = NullValueHandling.Ignore)]
        public long? IndustryAutomoblieManufacturing { get; set; }

        [JsonProperty("Industry_Production", NullValueHandling = NullValueHandling.Ignore)]
        public long? IndustryProduction { get; set; }

        [JsonProperty("Industry_Real State", NullValueHandling = NullValueHandling.Ignore)]
        public long? IndustryRealState { get; set; }

        [JsonProperty("Culture_Religion", NullValueHandling = NullValueHandling.Ignore)]
        public double? CultureReligion { get; set; }

        [JsonProperty("Economy", NullValueHandling = NullValueHandling.Ignore)]
        public long? Economy { get; set; }

        [JsonProperty("Industry_Banking", NullValueHandling = NullValueHandling.Ignore)]
        public long? IndustryBanking { get; set; }

        [JsonProperty("Social_Security", NullValueHandling = NullValueHandling.Ignore)]
        public long? SocialSecurity { get; set; }
    }
}
