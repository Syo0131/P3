using DataBase.Context;
using DataBase.Entities.Generos;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Repository
{
    public class GeneroRepository
    {
        private readonly ItlaTvContext _dbContext;

        public GeneroRepository(ItlaTvContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddG(Genero genero)
        {
            await _dbContext.Generos.AddAsync(genero);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateG(Genero genero)
        {
            _dbContext.Entry(genero).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteG(Genero genero)
        {
            _dbContext.Set<Genero>().Remove(genero);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Genero>> GetAllG()
        {
            return await _dbContext.Set<Genero>().ToListAsync();
        }
        public async Task<Genero> GetByIdG(int id)
        {
            return await _dbContext.Set<Genero>().FindAsync(id);
        }
    }
}
