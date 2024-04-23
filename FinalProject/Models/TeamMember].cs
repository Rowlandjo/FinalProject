namespace FinalProject.Models
{
    public class TeamMember_
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public required string CollegeProgram { get; set; }
        public required string YearInProgram { get; set; }
    }
}
