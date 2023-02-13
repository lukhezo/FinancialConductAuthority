using System.Collections.Generic;

namespace FinancialConductAuthority.Response
{
    public class WaiversDatum
    {
        public string Waivers_Discretions_URL { get; set; }
        public string Waivers_Discretions { get; set; }
        public List<string> Rule_ArticleNo { get; set; }
    }

    public class WaiversResponse
    {
        public string Status { get; set; }
        public ResultInfo ResultInfo { get; set; }
        public string Message { get; set; }
        public List<WaiversDatum> Data { get; set; }
    }
}
