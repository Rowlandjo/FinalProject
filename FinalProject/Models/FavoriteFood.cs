namespace FinalProject.Models
{
    public class FavoriteFood
    {
        public int Id { get; set; }
        public required string FoodName { get; set; }
        public required string Cuisine { get; set; }
        public required string FlavorProfile { get; set; }
        public int PrepTime { get; set; }
        public required string Healthy { get; set; }
    }
}
