using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialConductAuthority.Response
{
    public class CurrentName
    {
        [JsonProperty("Effective From")]
        public string EffectiveFrom { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
    }

    public class Names
    {
        [JsonProperty("Current Names")]
        public List<CurrentName> CurrentNames { get; set; }
    }

    public class OtherNamesResponse
    {
        public string Status { get; set; }
        public ResultInfo ResultInfo { get; set; }
        public string Message { get; set; }
        public List<Names> Data { get; set; }
    }


}
