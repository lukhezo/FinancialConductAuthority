using Newtonsoft.Json;
using System.Collections.Generic;

namespace FinancialConductAuthority.Response
{
    public class CurrentAppointedRepresentative
    {
        public string URL { get; set; }

        [JsonProperty("Record SubType")]
        public string RecordSubType { get; set; }

        [JsonProperty("Principal FRN")]
        public string PrincipalFRN { get; set; }

        [JsonProperty("Principal Firm Name")]
        public string PrincipalFirmName { get; set; }

        [JsonProperty("Effective Date")]
        public string EffectiveDate { get; set; }

        [JsonProperty("EEA Tied Agent")]
        public string EEATiedAgent { get; set; }

        [JsonProperty("Tied Agent")]
        public string TiedAgent { get; set; }

        [JsonProperty("Insurance Distribution")]
        public string InsuranceDistribution { get; set; }
        public string FRN { get; set; }
        public string Name { get; set; }
    }

    public class Data
    {
        public object PreviousAppointedRepresentatives { get; set; }
        public List<CurrentAppointedRepresentative> CurrentAppointedRepresentatives { get; set; }
    }

    public class AppointedRepresentativeResponse
    {
        public string Status { get; set; }
        public ResultInfo ResultInfo { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }

 
}
