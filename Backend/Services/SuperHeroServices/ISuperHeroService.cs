using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.SuperHeroServices
{
    public interface ISuperHeroService
    {

        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero> GetSingleHero(int id);
        Task<List<SuperHero>> AddHero(SuperHero hero);
        Task<List<SuperHero>> Update(int id, SuperHero request);
        Task<List<SuperHero>> Delete(int id);

    }
}
