using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialConductAuthority.Response
{
    public class RegulatorsDatum
    {
        [JsonProperty("Termination Date")]
        public string TerminationDate { get; set; }

        [JsonProperty("Effective Date")]
        public string EffectiveDate { get; set; }

        [JsonProperty("Regulator Name")]
        public string RegulatorName { get; set; }
    }

    public class RegulatorsResponse
    {
        public string Status { get; set; }
        public ResultInfo ResultInfo { get; set; }
        public string Message { get; set; }
        public List<RegulatorsDatum> Data { get; set; }
    }


}
