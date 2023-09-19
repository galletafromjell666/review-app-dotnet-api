namespace PokemonReviewApp.Models
{
    public class PokemonCategory
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        // M:M Relation
        public Pokemon Pokemon { get; set; }
        public Category Category { get; set; }
    }
}
