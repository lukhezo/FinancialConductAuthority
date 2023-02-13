using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialConductAuthority.Response
{
    public class FirmInfo
    {
        public string Name { get; set; }
        public string Individuals { get; set; }
        public string Requirements { get; set; }
        public string Permission { get; set; }
        public string Passport { get; set; }
        public string Regulators { get; set; }

        [JsonProperty("Appointed Representative")]
        public string AppointedRepresentative { get; set; }
        public string Address { get; set; }
        public string Waivers { get; set; }
        public string Exclusions { get; set; }
        public string DisciplinaryHistory { get; set; }

        [JsonProperty("System Timestamp")]
        public string SystemTimestamp { get; set; }

        [JsonProperty("Exceptional Info Title")]
        public string ExceptionalInfoTitle { get; set; }

        [JsonProperty("Exceptional Info Body")]
        public string ExceptionalInfoBody { get; set; }

        [JsonProperty("Status Effective Date")]
        public string StatusEffectiveDate { get; set; }

        [JsonProperty("E-Money Agent Status")]
        public string EMoneyAgentStatus { get; set; }

        [JsonProperty("PSD / EMD Effective Date")]
        public string PSDEMDEffectiveDate { get; set; }

        [JsonProperty("Client Money Permission")]
        public string ClientMoneyPermission { get; set; }

        [JsonProperty("Sub Status Effective from")]
        public string SubStatusEffectiveFrom { get; set; }

        [JsonProperty("Sub-Status")]
        public string SubStatus { get; set; }

        [JsonProperty("Mutual Society Number")]
        public string MutualSocietyNumber { get; set; }

        [JsonProperty("Companies House Number")]
        public string CompaniesHouseNumber { get; set; }

        [JsonProperty("MLRs Status Effective Date")]
        public string MLRsStatusEffectiveDate { get; set; }

        [JsonProperty("MLRs Status")]
        public string MLRsStatus { get; set; }

        [JsonProperty("E-Money Agent Effective Date")]
        public string EMoneyAgentEffectiveDate { get; set; }

        [JsonProperty("PSD Agent Effective date")]
        public string PSDAgentEffectiveDate { get; set; }

        [JsonProperty("PSD Agent Status")]
        public string PSDAgentStatus { get; set; }

        [JsonProperty("PSD / EMD Status")]
        public string PSDEMDStatus { get; set; }
        public string Status { get; set; }

        [JsonProperty("Business Type")]
        public string BusinessType { get; set; }

        [JsonProperty("Organisation Name")]
        public string OrganisationName { get; set; }
        public string FRN { get; set; }
    }

    public class FirmResponse
    {
        public string Status { get; set; }
        public ResultInfo ResultInfo { get; set; }
        public string Message { get; set; }
        public List<FirmInfo> Data { get; set; }
    }
}
