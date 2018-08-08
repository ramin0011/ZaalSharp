using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ZaalSharp.Connector
{
    internal class HttpHelper 
    {
        public static JsonSerializerSettings GetSerializerSettings()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
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
            var response = await Post(uri, data);
            return JsonConvert.DeserializeObject<TResult>(response, GetSerializerSettings());
        }

        private static async Task<string> Post<TRequest>(string uri, TRequest data)
        {
            //new HttpClient().PostAsync<TRequest>(uri,)

            HttpWebRequest request = HttpWebRequest.CreateHttp(uri);
            request.Method = "POST";

            request.Accept = "*/*";
            var postData = JsonConvert.SerializeObject(data, GetSerializerSettings())+ " ";
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1);Accept-Language:ar";
            request.ContentType = "application/json";
            var response = (HttpWebResponse)( await request.GetResponseAsync());

            using (var stream = new StreamReader(response.GetResponseStream()))
            {
               
                return await stream.ReadToEndAsync();
            }
        }

 
    }
}
