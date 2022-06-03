using System.Collections.Generic;

namespace WhatsForDinner.Model
{
    public class Dinner
    {
        public int Id { get; set; }
        public string DinnerName { get; set; }
        public bool IsFavourite { get; set; }
        public string Description { get; set; }
        public List<string> DinnerTags { get; set; }
        public string RecipeURL { get; set; }
        public int CusineId { get; set; }
    }
}
