namespace CMCSWebApp.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public string ClaimPeriod { get; set; }
        public string LecturerName { get; set; }
        public decimal ClaimAmount { get; set; }
        public string Status { get; set; }
        public DateTime SubmissionDate { get; set; }

    }
}