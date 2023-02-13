using System.Collections.Generic;

namespace FinancialConductAuthority.Response
{
    public class Permission
    {
        public string Name { get; set; }
        public List<string> InvestmentTypes { get; set; }
    }

    public class PermissionDatum
    {
        public List<Permission> Permissions { get; set; }
        public string PassportType { get; set; }
        public string PassportDirection { get; set; }
        public string Directive { get; set; }
        public string Country { get; set; }
    }

    public class PermissionResponse
    {
        public string Status { get; set; }
        public ResultInfo ResultInfo { get; set; }
        public string Message { get; set; }
        public List<PermissionDatum> Data { get; set; }
    } 
}
