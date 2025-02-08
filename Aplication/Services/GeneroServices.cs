using Aplication.Repository;
using Aplication.ViewModel;
using DataBase.Context;
using DataBase.Entities.Generos;

namespace Aplication.Services
{
    public class GeneroServices
    {
        private readonly GeneroRepository _GeneroRepository;

        public GeneroServices(ItlaTvContext dbContext)
        {
            _GeneroRepository = new(dbContext);
        }

        public async Task<List<GenerosViewModel>> GetAllGeneros()
        {
            var generolist = await _GeneroRepository.GetAllG();
            return generolist.Select(genero => new GenerosViewModel
            {
                IdGenero = genero.IdGenero,
                NombreGenero = genero.NombreGenero,
            }).ToList();
        }

        public async Task<GenerosViewModel> GetGeneroById(int id)
        {
            var genero = await _GeneroRepository.GetByIdG(id);
            if (genero == null)
            {
                throw new ArgumentException($"No se encontró un género con el ID {id}.");
            }
            return new GenerosViewModel
            {
                IdGenero = genero.IdGenero,
                NombreGenero = genero.NombreGenero,
            };
        }
        public async Task AddGenero(GenerosViewModel generos)
        {
            Genero genero = new();
            genero.NombreGenero = generos.NombreGenero;
            await _GeneroRepository.AddG(genero);
        }

        public async Task UpdateGenero(GenerosViewModel generos)
        {
            Genero genero = new();
            genero.IdGenero = generos.IdGenero;
            genero.NombreGenero = generos.NombreGenero;
            await _GeneroRepository.UpdateG(genero);
        }

        public async Task DeleteGenero(int id)
        {
            var genero = await _GeneroRepository.GetByIdG(id);  // Buscar el género por ID
            if (genero == null)
            {
                throw new ArgumentException($"No se encontró un género con el ID {id}.");
            }
            await _GeneroRepository.DeleteG(genero);
        }

    }
}