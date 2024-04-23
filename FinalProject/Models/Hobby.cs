namespace FinalProject.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string HobbyName { get; set; }
        public string TypeOfHobby { get; set; }
        public string CostOfHobby { get; set; }
        public string TimeWhenHobbyPerformed { get; internal set; }

    }
}
