using Aplication.Services;
using Aplication.ViewModel;
using DataBase.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MiniTV.Controllers.Generos
{
    public class GeneroController : Controller
    {
        private readonly GeneroServices _generoServices;

        public GeneroController(ItlaTvContext dbContext)
        {
            _generoServices = new(dbContext);
        }
        public async Task<IActionResult> ListGenero()
        {
            var list = await _generoServices.GetAllGeneros();
            return View(list);
        }

        public IActionResult CreateG()
        {
            return View("SaveGenero", new GenerosViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateG(GenerosViewModel GM)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGenero", GM);
            }
            await _generoServices.AddGenero(GM);
            return RedirectToRoute(new { Controller = "Genero", action = "ListGenero" });
        }

        public async Task<IActionResult> DeleteG(int id)
        {
            var genero = await _generoServices.GetGeneroById(id);

            if (genero == null)
            {
                return NotFound();
            }

            return View("DeleteGenero", genero);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteG(int id, GenerosViewModel GM)
        {
            await _generoServices.DeleteGenero(id);
            return RedirectToAction("ListGenero");
        }

        public async Task<IActionResult> EditG(int id)
        {
            var genero = await _generoServices.GetGeneroById(id);
            if (genero == null)
            {
                return NotFound();
            }
            return View("EditGenero", genero);
        }
        [HttpPost]
        public async Task<IActionResult> EditG(GenerosViewModel GM)
        {
            if (!ModelState.IsValid)
            {
                return View("EditGenero", GM);
            }
            await _generoServices.UpdateGenero(GM);
            return RedirectToAction("ListGenero");
        }
    }
}
