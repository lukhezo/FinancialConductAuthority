using Newtonsoft.Json;
using System.Collections.Generic;

namespace FinancialConductAuthority.Response
{
    public class Details
    {
        [JsonProperty("Current roles & activities")]
        public string CurrentRolesActivities { get; set; }
        public string IRN { get; set; }

        [JsonProperty("Commonly Used Name")]
        public string CommonlyUsedName { get; set; }
        public string Status { get; set; }

        [JsonProperty("Full Name")]
        public string FullName { get; set; }
    }

    public class InvidualDetailsDatum
    {
        public Details Details { get; set; }
    }

    public class InvidualDetailsResponse
    {
        public string Status { get; set; }
        public ResultInfo ResultInfo { get; set; }
        public string Message { get; set; }
        public List<InvidualDetailsDatum> Data { get; set; }
    }


 
}
