namespace Backend.Services.SuperHeroServices
{
    public class SuperHeroService : ISuperHeroService
    {
        public static List<SuperHero> superhero = new List<SuperHero>
            {  new SuperHero
            {
                Id = 1,
                Name="Spider Man",
                Power="Spider Sense"
            },
             new SuperHero
            {
                Id = 2,
                Name="Batman",
                Power="Detective Work"
            }
            };
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
            
        }
        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
             _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return superhero;
        }

      public  async Task<List<SuperHero>> Delete(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }

            _context.SuperHeroes.Remove(hero);   
            await _context.SaveChangesAsync();
            return superhero;
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes=await _context.SuperHeroes.ToListAsync();
           
            return heroes;
        }

       public async Task<SuperHero> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id); 

            //var hero=superhero.Find(x=>x.Id== id);
           

            return hero;
        }

       public async Task<List<SuperHero>> Update(int id, SuperHero request)
        {

            var hero = await _context.SuperHeroes.FindAsync(id);

            //var hero = superhero.Find(x => x.Id == id);
          

            hero.Name = request.Name;
            hero.Power = request.Power;

            await _context.SaveChangesAsync();
            return superhero;
        }
    }
}
