namespace VotingAdmin.Web.Models.Reports
{
    public class ReportList
    {
        public string TxnDateString { get; set; }
        public string MerchantName { get; set; }
        public string ContestName { get; set; }
        public string SubContestName { get; set; }
        public string ContestantName { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public string MemberNumber { get; set; }
        public int FreeVotes { get; set; }
        public int PaidVotes { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentGatewayName { get; set; }
        public string Status { get; set; }
    }
}
