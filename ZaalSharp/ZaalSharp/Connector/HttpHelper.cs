using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ZaalSharp.Connector
{
    public class HttpHelper 
    {
        public static JsonSerializerSettings GetSerializerSettings()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            settings.Converters.Add(new StringEnumConverter());
            return settings;
        }
        public static async Task<TResult> GetAsync<TResult>(string uri, WebHeaderCollection headers=null)
        {
            var serialized = await GetRawAsync(uri, headers);
            TResult result = JsonConvert.DeserializeObject<TResult>(serialized, GetSerializerSettings());
            return result;
        }
        public static async Task<string> GetRawAsync(string uri, WebHeaderCollection headers=null)
        {
            HttpWebRequest webRequest = HttpWebRequest.CreateHttp(uri);
            if(headers!=null)
            webRequest.Headers = headers;
            string serialized = "";
            using (var resp=new StreamReader((await webRequest.GetResponseAsync()).GetResponseStream()))
            {
              serialized= await resp.ReadToEndAsync();
            }
            return serialized;
        }

        public static async Task PostAsync<TResult>(string uri, TResult data)
        {
              await Post(uri, data);
        }

        public static async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data)
        {
            HttpResponseMessage response = await Post(uri, data);
            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(responseData, GetSerializerSettings());
        }

        private static async Task<HttpResponseMessage> Post<TRequest>(string uri, TRequest data)
        {
            var httpClient = CreateHttpClient;
            string serialized = JsonConvert.SerializeObject(data, GetSerializerSettings());
            var response = await httpClient.PostAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"));
            await HandleResponse(response);
            return response;
        }

        public static Task<TResult> PutAsync<TResult>(string uri, TResult data)
        {
            return PutAsync<TResult, TResult>(uri, data);
        }

        public static async Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data)
        {
            var httpClient = CreateHttpClient;
            string serialized =  JsonConvert.SerializeObject(data, GetSerializerSettings());
            var response = await httpClient.PutAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"));
            await HandleResponse(response);
            string responseData = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, GetSerializerSettings()));
        }

        private static HttpClient CreateHttpClient
        {
            get
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return httpClient;
            }
        }

        private static async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                    throw new Exception(content);
                throw new HttpRequestException(content);
            }
        }
    }
}
