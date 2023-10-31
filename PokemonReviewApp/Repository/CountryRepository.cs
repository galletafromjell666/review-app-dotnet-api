using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CountryRepository(DataContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public bool countryExist(int countryId)
        {
            return _context.Countries.Any(country => country.Id == countryId);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.OrderBy(country => country.Name).ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(country => country.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(owner => owner.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetCountryOwners(int countryId)
        {
            return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }
    }
}
