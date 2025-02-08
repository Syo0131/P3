
using Aplication.Repository;
using Aplication.ViewModel;
using DataBase.Context;
using DataBase.Entities.Productoras;

namespace Aplication.Services
{
    public class ProductoraServices
    {
        private readonly ProductoraRepository _productoraRepository;

        public ProductoraServices(ItlaTvContext dbContext)
        {
            _productoraRepository = new(dbContext);
        }
        public async Task<ProductoraViewModel> GetProductorabyId(int id)
        {
            var productora = await _productoraRepository.GetByIdP(id);
            return new ProductoraViewModel
            {
                IdProductora = productora.IdProductora,
                NombreProductora = productora.NombreProductora,
            };

        }
        public async Task<List<ProductoraViewModel>> GetAllProductora()
        {
            var productoras = await _productoraRepository.GetAllP();
            return productoras.Select(productora => new ProductoraViewModel
            {
                IdProductora = productora.IdProductora,
                NombreProductora = productora.NombreProductora,               
            }).ToList();
        }

        public async Task AddProductora(ProductoraViewModel productoras)
        {
            Productora productora = new();
            productora.NombreProductora = productoras.NombreProductora;
            await _productoraRepository.AddP(productora);
        }

        public async Task UpdateProductora(ProductoraViewModel productoras)
        {
            Productora productora = new();
            productora.IdProductora = productoras.IdProductora;
            productora.NombreProductora = productoras.NombreProductora;
            await _productoraRepository.UpdateP(productora);
        }

        public async Task DeleteProductora(int id)
        {
            var productora = await _productoraRepository.GetByIdP(id);  // Buscar la productora por ID
            if (productora == null)
            {
                throw new ArgumentException($"No se encontró una productora con el ID {id}.");
            }
            await _productoraRepository.DeleteP(productora);
        }
    }
}
