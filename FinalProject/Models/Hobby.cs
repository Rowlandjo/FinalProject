namespace FinalProject.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public required string HobbyName { get; set; }
        public required string TypeOfHobby { get; set; }
        public required string CostOfHobby { get; set; }
        public string? TimeWhenHobbyPerformed { get; internal set; }

    }
}
