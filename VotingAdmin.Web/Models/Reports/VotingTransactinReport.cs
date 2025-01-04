namespace VotingAdmin.Web.Models.Reports
{
    public class VotingTransactinReport
    {
        public string TxnDateString { get; set; }
        public DateTime? TxnDate { get; set; }
        public string MerchantId { get; set; }
        public string MerchantName { get; set; }
        public long ContestId { get; set; }
        public string ContestName { get; set; }
        public long SubContestId { get; set; }
        public string SubContestName { get; set; }
        public long ContestantId { get; set; }
        public string ContestantName { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public string MemberNumber { get; set; }
        public int FreeVotes { get; set; }
        public int PaidVotes { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethodCode { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentGatewayCode { get; set; }
        public string PaymentGatewayName { get; set; }
        public string StatusCode { get; set; }
        public string Status { get; set; }
    }
}
