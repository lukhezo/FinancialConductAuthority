using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialConductAuthority.Response
{
    public class DisciplinaryHistoryDatum
    {
        public string TypeofDescription { get; set; }
        public string TypeofAction { get; set; }
        public string EnforcementType { get; set; }
        public string ActionEffectiveFrom { get; set; }
    }

    public class DisciplinaryHistoryResponse
    {
        public string Status { get; set; }
        public ResultInfo ResultInfo { get; set; }
        public string Message { get; set; }
        public List<DisciplinaryHistoryDatum> Data { get; set; }
    }


 
}
