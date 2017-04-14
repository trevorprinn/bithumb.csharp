using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using RestSharp;
using Bithumb.LIB.Configuration;
using Bithumb.LIB.Serialize;

namespace Bithumb.LIB
{
    /// <summary>
    /// 
    /// </summary>
    public class XApiRequest
    {
        private const string __content_type = "application/json";
        private const string __user_agent = "btc-trading/5.2.2017.01";

        /// <summary>
        /// 
        /// </summary>
        public XApiRequest()
        {
            if (ServicePointManager.ServerCertificateValidationCallback == null)
                ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
        }

        private static char[] __to_digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

        protected byte[] EncodeHex(byte[] data)
        {
            int l = data.Length;
            byte[] _result = new byte[l << 1];

            // two characters form the hex value.
            for (int i = 0, j = 0; i < l; i++)
            {
                _result[j++] = (byte)__to_digits[(0xF0 & data[i]) >> 4];
                _result[j++] = (byte)__to_digits[0x0F & data[i]];
            }

            return _result;
        }

        protected string EncodeURIComponent(Dictionary<string, object> rgData)
        {
            string _result = String.Join("&", rgData.Select((x) => String.Format("{0}={1}", x.Key, x.Value)));

            _result = System.Net.WebUtility.UrlEncode(_result)
                        .Replace("+", "%20").Replace("%21", "!")
                        .Replace("%27", "'").Replace("%28", "(")
                        .Replace("%29", ")").Replace("%26", "&")
                        .Replace("%3D", "=").Replace("%7E", "~");

            return _result;
        }

        protected Dictionary<string, object> GetHttpHeaders(string endpoint, Dictionary<string, object> rgData, string apiKey, string apiSecret)
        {
            var _nonce = UnixTime.NowMilli.ToString();
            var _data = EncodeURIComponent(rgData);
            var _message = String.Format("{0};{1};{2}", endpoint, _data, _nonce);

            var _secretKey = Encoding.UTF8.GetBytes(apiSecret);
            var _hmac = new HMACSHA512(_secretKey);
            _hmac.Initialize();

            var _bytes = Encoding.UTF8.GetBytes(_message);
            var _rawHmac = _hmac.ComputeHash(_bytes);

            var _encoded = EncodeHex(_rawHmac);
            var _signature = Convert.ToBase64String(_encoded);

            var _headers = new Dictionary<string, object>();
            {
                _headers.Add("Api-Key", apiKey);
                _headers.Add("Api-Sign", _signature);
                _headers.Add("Api-Nonce", _nonce);
            }

            return _headers;
        }

        protected IRestClient CreateJsonClient(string baseurl)
        {
            var _client = new RestClient(baseurl);
            {
                _client.RemoveHandler(__content_type);
                _client.AddHandler(__content_type, new RestSharpJsonNetDeserializer());
                _client.Timeout = 10 * 1000;
                _client.UserAgent = __user_agent;
            }

            return _client;
        }

        protected IRestRequest CreateJsonRequest(string resource, Method method = Method.GET)
        {
            var _request = new RestRequest(resource, method)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonNetSerializer()
            };

            return _request;
        }
    }
}