using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Data
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext (DbContextOptions<FinalProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TeamMember_>().HasData(
                new TeamMember { Id = 1, Fullname = "Natalie Plunkett", BirthDate = "January 31", CollegeProgram = "Information Technology", YearInProgram = "Senior," },
                new TeamMember { Id = 2, Fullname = "Josh Rowland", BirthDate = "April 7", CollegeProgram = "Information Technology", YearInProgram = "Junior," },
                new TeamMember {Id = 3, Fullname = "William Kohus", BirthDate = "December 20", CollegeProgram = "Information Technology", YearInProgram = "Sophmore,"}
                );
            builder.Entity<Hobby>().HasData(
                new Hobby { Id = 1, HobbyName = "Gardening", TypeOfHobby = "Outdoors", CostOfHobby = "Low", TimeWhenHobbyPerformed = "Daytime," },
                new Hobby { Id = 3, HobbyName = "Gym", TypeOfHobby = "Workout", CostOfHobby = "Low", TimeWhenHobbyPerformed = "Anytime," },
                 new Hobby { Id = 2, HobbyName = "Golf", TypeOfHobby = "Outdoors", CostOfHobby = "Low", TimeWhenHobbyPerformed = "Warm and Sunny," }
                );
            builder.Entity<CareerGoals>().HasData(
                new Hobby { Id = 1, GoalName = "Technical Specialist", ResourcesReq = "Schooling, Certificates, Experience", SupportNeeded = "Yes", SuccessIndicator = "Getting a Job," },
                new Hobby { Id = 3, GoalName = "Cybersecurity Analyst", ResourcesReq = "Degree, Certificates, Experience", SupportNeeded = "Yes", SuccessIndicator = "Getting a Job," },
               new Hobby { Id = 2, GoalName = "Information Assuarance Technician", ResourcesReq = "Degree, Certificates, Experience", SupportNeeded = "Yes", SuccessIndicator = "Succesful Job Interview and Hiring," }
               );
            builder.Entity<FavoriteFood>().HasData(
                new Hobby { Id = 1, FoodName = "Pizza", Cuisine = "Italian", FlavorProfile = "Savory", PrepTime = 2, Healthy = "No," },
                new Hobby { Id = 3, FoodName = "Burger", Cuisine = "American", FlavorProfile = "Tangy", PrepTime = 3, Healthy = "No,"},
                new Hobby { Id = 2, FoodName = "Steak", Cuisine = "American", FlavorProfile = "Smoky", PrepTime = 1, Healthy = "Yes/No,"}
                );
        }                
        
        public DbSet<FinalProject.Models.TeamMember_> TeamMember_ { get; set; } = default!;
        public DbSet<FinalProject.Models.Hobby> Hobby { get; set; } = default!;
        public DbSet<FinalProject.Models.CareerGoals> CareerGoals { get; set; } = default!;
        public DbSet<FinalProject.Models.FavoriteFood> FavoriteFood { get; set; } = default!;
    }

    internal class TeamMember
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string BirthDate { get; set; }
        public string CollegeProgram { get; set; }
        public string YearInProgram { get; set; }
    }
}
