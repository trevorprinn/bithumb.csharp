using Newtonsoft.Json;
using System;
using System.Linq;

namespace XCT.BaseLib.API.Bithumb.User
{
    public class UserBalance {
        private object _data;
        public CurrencyValues[] Balances { get; private set; }
        public string status { get; set; }
        public string message { get; set; }

        public object data {
            get { return _data; }
            set {
                _data = value;
                // Convert to XML as it is easier to parse.
                var doc = JsonConvert.DeserializeXNode(value.ToString(), "balances");
                Balances = doc.Root.Elements().Where(e => e.Name.LocalName.StartsWith("total_") || e.Name.LocalName.StartsWith("available_"))
                    .Select(e => {
                        var part = e.Name.LocalName.Split('_');
                        return new {
                            type = part[0],
                            currency = part[1],
                            value = Convert.ToDecimal(e.Value)
                        };
                    })
                    .GroupBy(e => e.currency)
                    .Select(c => new CurrencyValues { Currency = c.Key, Total = c.Single(e => e.type == "total").value, Available = c.Single(e => e.type == "available").value })
                    .ToArray();
            }
        }

        public class CurrencyValues {
            public string Currency { get; set; }
            public decimal? Total { get; set; }
            public decimal? Available { get; set; }
        }
    }
}