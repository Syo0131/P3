
using Aplication.Services;
using Microsoft.AspNetCore.Mvc;


namespace MiniTV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SerieServices _serieService;
        private readonly ProductoraServices _productoraService;
        private readonly GeneroServices _generoService;
        public HomeController(ILogger<HomeController> logger, SerieServices serieService, ProductoraServices productoraService, GeneroServices generoService)
        {
            _logger = logger;
            _serieService = serieService;
            _productoraService = productoraService;
            _generoService = generoService;
        }

        public async Task<IActionResult> HomeView(string search, int? productoraId, int? generoId)
        {
            var series = await _serieService.GetAllSeries();

            // Aplicar filtros si hay valores en los parámetros
            if (!string.IsNullOrEmpty(search))
            {
                series = series.Where(s => s.Titulo.Contains(search, System.StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (productoraId.HasValue)
            {
                series = series.Where(s => s.IdProductora == productoraId.Value).ToList();
            }

            if (generoId.HasValue)
            {
                series = series.Where(s => s.IdGeneroPrimario == generoId.Value || s.IdGeneroSecundario == generoId.Value).ToList();
            }

            // Cargar listas de productoras y géneros para los filtros
            ViewBag.Productoras = await _productoraService.GetAllProductora();
            ViewBag.Generos = await _generoService.GetAllGeneros();

            return View("HomeView", series);
        }
    }
}