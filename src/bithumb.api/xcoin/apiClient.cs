using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace XCoin.API.Trader.XCoin
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiClient : WebRequest, IDisposable
    {
        private const string __api_url = "https://api.bithumb.com";

        private string __connect_key;
        private string __secret_key;

        /// <summary>
        /// 
        /// </summary>
        public ApiClient(string connect_key, string secret_key)
            : base()
        {
            __connect_key = connect_key;
            __secret_key = secret_key;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task<T> CallApiAsync<T>(string endpoint, Dictionary<string, object> args = null) where T : new()
        {
            var _request = CreateJsonRequest(endpoint, Method.POST);
            {
                var _params = new Dictionary<string, object>();
                {
                    _params.Add("endpoint", endpoint);
                    if (args != null)
                    {
                        foreach (var a in args)
                            _params.Add(a.Key, a.Value);
                    }
                }

                _request.AddHeader("api-client-type", "2");

                var _headers = GetHttpHeaders(endpoint, _params, __connect_key, __secret_key);
                foreach (var h in _headers)
                    _request.AddHeader(h.Key, h.Value.ToString());

                foreach (var a in _params)
                    _request.AddParameter(a.Key, a.Value);
            }

            var _client = CreateJsonClient(__api_url);
            {
                var tcs = new TaskCompletionSource<T>();
                _client.ExecuteAsync(_request, response =>
                {
                    tcs.SetResult(JsonConvert.DeserializeObject<T>(response.Content));
                });

                return await tcs.Task;
            }
        }

        public async Task<T> CallApiGetAsync<T>(string endpoint, Dictionary<string, object> args = null) where T : new()
        {
            var _request = CreateJsonRequest(endpoint, Method.GET);
            {
                //var _params = new Dictionary<string, object>();
                //{
                //    _params.Add("endpoint", endpoint);
                //    if (args != null)
                //    {
                //        foreach (var a in args)
                //            _params.Add(a.Key, a.Value);
                //    }
                //}

                if (args != null)
                foreach (var a in args)
                    _request.AddParameter(a.Key, a.Value);
            }

            var _client = CreateJsonClient(__api_url);
            {
                var tcs = new TaskCompletionSource<T>();
                _client.ExecuteAsync(_request, response =>
                {
                    tcs.SetResult(JsonConvert.DeserializeObject<T>(response.Content));
                });

                return await tcs.Task;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
        }
    }
}