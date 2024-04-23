namespace FinalProject.Models
{
    public class CareerGoals
    {
        public int Id { get; set; }
        public required string GoalName { get; set; }
        public required string ResourcesReq { get; set; }
        public required string SupportNeeded { get; set; }
        public required string SuccessIndicator { get; set; }
    }
}
