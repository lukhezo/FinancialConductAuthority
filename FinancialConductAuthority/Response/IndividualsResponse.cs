using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialConductAuthority.Response
{

    public class IndividualDatum
    {
        public string Status { get; set; }
        public string URL { get; set; }
        public string IRN { get; set; }
        public string Name { get; set; }
    }

    public class IndividualsResponse
    {
        public string Status { get; set; }
        public ResultInfo ResultInfo { get; set; }
        public string Message { get; set; }
        public List<IndividualDatum> Data { get; set; }
    }


}
