using System.Collections.Generic;

namespace FinancialConductAuthority.Response
{
    public class Passport
    {
        public string PassportDirection { get; set; }
        public string Permissions { get; set; }
        public string Country { get; set; }
    }

    public class PassportDatum
    {
        public List<Passport> Passports { get; set; }
    }

    public class PassportResponse
    {
        public string Status { get; set; }
        public ResultInfo ResultInfo { get; set; }
        public string Message { get; set; }
        public List<PassportDatum> Data { get; set; }
    } 
}
