using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialConductAuthority.Response
{
    public class AddressDatum
    {
        public string URL { get; set; }

        [JsonProperty("Website Address")]
        public string WebsiteAddress { get; set; }

        [JsonProperty("Phone Number")]
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public string County { get; set; }
        public string Town { get; set; }

        [JsonProperty("Address Line 4")]
        public string AddressLine4 { get; set; }

        [JsonProperty("Address LIne 3")]
        public string AddressLIne3 { get; set; }

        [JsonProperty("Address Line 2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("Address Line 1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("Address Type")]
        public string AddressType { get; set; }
    }

    public class AddressResponse
    {
        public string Status { get; set; }
        public ResultInfo ResultInfo { get; set; }
        public string Message { get; set; }
        public List<AddressDatum> Data { get; set; }
    }

}
