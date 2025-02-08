using Aplication.Services;
using Aplication.ViewModel;
using DataBase.Context;
using Microsoft.AspNetCore.Mvc;

namespace MiniTV.Controllers.Productoras
{
    public class ProductoraController : Controller
    {
        private readonly ProductoraServices _productoraServices;

        public ProductoraController(ItlaTvContext dbContext)
        {
            _productoraServices = new(dbContext);
        }

        public async Task<IActionResult> ListProductora()
        {
            return View(await _productoraServices.GetAllProductora());
        }


        public IActionResult CreateP()
        {
            return View("SaveProductora", new ProductoraViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateP(ProductoraViewModel Pvm)
        {
            if (!ModelState.IsValid)
            {
                return View("EditProductora", Pvm);
            }

            await _productoraServices.AddProductora(Pvm);
            return RedirectToRoute(new { Controller = "Productora", action = "ListProductora" });
        }

        public async Task<IActionResult> EditP(int id)
        {
            var productora = await _productoraServices.GetProductorabyId(id);
            if (productora == null)
            {
                return NotFound();
            }
            return View("EditProductora", productora);
        }

        [HttpPost]
        public async Task<IActionResult> EditP(ProductoraViewModel Pvm)
        {
            if (!ModelState.IsValid)
            {
                return View("EditProductora", Pvm);
            }
            await _productoraServices.UpdateProductora(Pvm);
            return RedirectToAction("ListProductora");
        }

        public async Task<IActionResult> DeleteP(int id)
        {
            var productora = await _productoraServices.GetProductorabyId(id);

            if (productora == null)
            {
                return NotFound();
            }

            return View("DeleteProductora", productora);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteP(int id, ProductoraViewModel PM)
        {
            await _productoraServices.DeleteProductora(id);
            return RedirectToAction("ListProductora");
        }
    }
}
