using DataBase.Context;
using DataBase.Entities.Productoras;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Repository
{
    public class ProductoraRepository
    {
        private readonly ItlaTvContext _dbContext;

        public ProductoraRepository(ItlaTvContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddP(Productora productora)
        {
            await _dbContext.Productoras.AddAsync(productora);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateP(Productora productora)
        {
            _dbContext.Entry(productora).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteP(Productora productora)
        {
            _dbContext.Set<Productora>().Remove(productora);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Productora>> GetAllP()
        {
            return await _dbContext.Set<Productora>().ToListAsync();
        }
        public async Task<Productora> GetByIdP(int id)
        {
            return await _dbContext.Set<Productora>().FindAsync(id);
        }
    }
}