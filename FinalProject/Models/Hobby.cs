namespace FinalProject.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string HobbyName { get; set; }
        public string TypeOfHobby { get; set; }
        public string CostOfHobby { get; set; }
        public int TimeWhenHobbyPerformex { get; set; }
        public string FoodName { get; internal set; }
        public string GoalName { get; internal set; }
        public string Cuisine { get; internal set; }
        public string FlavorProfile { get; internal set; }
        public int PrepTime { get; internal set; }
        public string Healthy { get; internal set; }
        public string SupportNeeded { get; internal set; }
        public string TimeWhenHobbyPerformed { get; internal set; }
        public string ResourcesReq { get; internal set; }
        public string SuccessIndicator { get; internal set; }
    }
}
