using DataBase.Context;
using DataBase.Entities.Series;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aplication.Repository
{
    public class SerieRepository
    {
        private readonly ItlaTvContext _dbContext;

        public SerieRepository(ItlaTvContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddS(Serie serie)
        {
            await _dbContext.Series.AddAsync(serie);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateS(Serie serie)
        {
            _dbContext.Entry(serie).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteS(Serie serie)
        {
            _dbContext.Set<Serie>().Remove(serie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Serie>> GetAllS(Expression<Func<Serie, bool>> filter = null)
        {
            IQueryable<Serie> query = _dbContext.Series
                .Include(s => s.Productora)
                .Include(s => s.GeneroPrimario)
                .Include(s => s.GeneroSecundario); // Si es necesario

            if (filter != null)
            {
                query = query.Where(filter); // Aplicar el filtro
            }

            return await query.ToListAsync();
        }
        public async Task<Serie> GetByIdS(int id)

        {
            return await _dbContext.Series
                   .Include(s => s.Productora)
                   .Include(s => s.GeneroPrimario)
                   .Include(s => s.GeneroSecundario)
                   .FirstOrDefaultAsync(s => s.IdSerie == id);
        }
    }
}
