using Backend.Services.SuperHeroServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
           _superHeroService=superHeroService;
            
        }


        [HttpGet] 
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
             return await _superHeroService.GetAllHeroes();
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
        {
            var hero= await _superHeroService.GetSingleHero(id);
            if (hero == null) 
            { return NotFound("Sorry, Hero doesnot exist"); 
            }
            return Ok(hero);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            await _superHeroService.AddHero(hero);
            return Ok(hero);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Update(int id, SuperHero request)
        {
            var hero = await _superHeroService.Update(id, request);   
            if (hero == null)
            {
                return NotFound("Sorry, Hero doesnot exist");
            }
            return Ok(hero);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = await _superHeroService.Delete(id);
            if (hero == null)
            {
                return NotFound("Sorry, Hero doesnot exist");
            }

            return Ok(hero);
        }
    }
}
