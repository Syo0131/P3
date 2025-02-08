using Aplication.Services;
using Aplication.ViewModel;
using DataBase.Context;
using Microsoft.AspNetCore.Mvc;

namespace MiniTV.Controllers.Series
{
    public class SeriesController : Controller
    {
        private readonly SerieServices _serieServices;
        private readonly ProductoraServices _productoraServices;
        private readonly GeneroServices _generoServices;


        public SeriesController(ItlaTvContext dbContext)
        {
            _serieServices = new SerieServices(dbContext);
            _productoraServices = new ProductoraServices(dbContext);
            _generoServices = new GeneroServices(dbContext);
        }

        public async Task<IActionResult> ListSerie()
        {
            var list = await _serieServices.GetAllSeries();
            return View(list);
        }
        public async Task<IActionResult> CreateS()
        {

            ViewBag.Productoras = await _productoraServices.GetAllProductora();
            ViewBag.Generos = await _generoServices.GetAllGeneros();
            return View("SaveSerie", new SeriesViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateS(SeriesViewModel vm)
        { 
            Console.WriteLine("Intentando guardar la serie...");

            await _serieServices.AddSerie(vm);

            Console.WriteLine("Serie guardada correctamente.");

            return RedirectToAction("ListSerie");
        }

        public async Task<IActionResult> DetailS(int id)
        {
            var serie = await _serieServices.GetSerieById(id);
            if (serie == null)
            {
                return NotFound(); // Devuelve un error 404 si no encuentra la serie
            }
            return View("DetailsSerie", serie);

        }
        public async Task<IActionResult> DeleteS(int id)
        {
            var serie = await _serieServices.GetSerieById(id);
            if (serie == null)
            {
                return NotFound();
            }
            return View("DeleteSerie", serie);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteS(int id, SeriesViewModel Vm)
        {
            await _serieServices.DeleteS(id); // Implementa este método en tu servicio
            return RedirectToAction("ListSerie"); // Redirige a la lista de series
        }

        public async Task<IActionResult> EditS(int id)
        {
            var serieViewModel = await _serieServices.GetSerieById(id);
            if (serieViewModel == null)
            {
                return NotFound();
            }

            ViewBag.Productoras = await _productoraServices.GetAllProductora();
            ViewBag.Generos = await _generoServices.GetAllGeneros();

            return View("EditSerie", serieViewModel); // 🔹 Ahora apunta a la vista correcta
        }

        [HttpPost]
        public async Task<IActionResult> EditS(SeriesViewModel vm)
        {

                ViewBag.Productoras = await _productoraServices.GetAllProductora();
                ViewBag.Generos = await _generoServices.GetAllGeneros();
                
            

            await _serieServices.UpdateS(vm);
            return RedirectToAction("ListSerie"); // 🔹 Corregimos la redirección
        }

    }
}
