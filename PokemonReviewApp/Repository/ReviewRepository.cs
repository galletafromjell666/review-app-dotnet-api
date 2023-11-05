using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateReview(int reviewerId, int pokemonId, Review review)
        {
            Reviewer reviewerEntity = _context.Reviewers.Where(r => r.Id == reviewerId).FirstOrDefault();
            Pokemon pokemonEntity = _context.Pokemons.Where(p => p.Id == pokemonId).FirstOrDefault();

            if (reviewerEntity == null || pokemonEntity == null)
            {
                return false;
            }

            review.Reviewer = reviewerEntity;
            review.Pokemon = pokemonEntity;

            _context.Add(review);
            return Save();
        }

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            return _context.Reviews.Where(r => r.Pokemon.Id == pokeId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(r => r.Id == reviewId);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
