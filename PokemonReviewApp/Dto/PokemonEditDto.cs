﻿namespace PokemonReviewApp.Dto
{
    public class PokemonEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int OwnerId { get; set; }
        public int CategoryId { get; set; }
    }
}
