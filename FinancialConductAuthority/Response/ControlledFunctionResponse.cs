using FinancialConductAuthority.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialConductAuthority.Response
{
    public class FCACFFunctionsRequiringQualifications
    {
        [JsonProperty("Customer Engagement Method")]
        public string CustomerEngagementMethod { get; set; }

        [JsonProperty("End Date")]
        public string EndDate { get; set; }

        [JsonProperty("Suspension / Restriction End Date")]
        public string SuspensionRestrictionEndDate { get; set; }

        [JsonProperty("Suspension / Restriction Start Date")]
        public string SuspensionRestrictionStartDate { get; set; }
        public string Restriction { get; set; }

        [JsonProperty("Effective Date")]
        public string EffectiveDate { get; set; }

        [JsonProperty("Firm Name")]
        public string FirmName { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
    }

    public class Previous
    {
        [JsonProperty("1FCACFFunctionsRequiringQualifications")]
        public FCACFFunctionsRequiringQualifications _1FCACFFunctionsRequiringQualifications { get; set; }
    }

    public class ControlledFunctionDatum
    {
        public Previous Previous { get; set; }
    }

    public class ControlledFunctionResponse
    {
        public string Status { get; set; }
        public ResultInfo ResultInfo { get; set; }
        public string Message { get; set; }
        public List<ControlledFunctionDatum> Data { get; set; }
    }

}
 
