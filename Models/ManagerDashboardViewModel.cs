namespace CMCSWebApp.Models
{
    public class ClaimForReview
    {
        public string ClaimId { get; set; }
        public string LecturerName { get; set; }
        public string ClaimPeriod { get; set; }
        public string Status { get; set; }
    }

    public class ManagerDashboardViewModel
    {
        public int PendingClaimsCount { get; set; }
        public int ApprovedClaimsCount { get; set; }
        public int TotalClaimsCount { get; set; }
        public List<ClaimForReview> ClaimsForReview { get; set; }
    }
}