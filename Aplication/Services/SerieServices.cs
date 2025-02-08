using Aplication.Repository;
using Aplication.ViewModel;
using DataBase.Context;
using DataBase.Entities.Series;

namespace Aplication.Services
{
    public class SerieServices
    {
        private readonly SerieRepository _SerieRepository;

        public SerieServices(ItlaTvContext dbContext)
        {
            _SerieRepository = new(dbContext);
        }

        public async Task<List<SeriesViewModel>> GetAllSeries()
        {
            var Series = await _SerieRepository.GetAllS();

            return Series.Select(serie => new SeriesViewModel
            {
                Id = serie.IdSerie,
                Titulo = serie.Titulo,
                PortadaUrl = serie.PortadaUrl,
                VideoURl = serie.VideoURl,
                IdProductora = serie.IdProductora,
                NombreProductora = serie.Productora.NombreProductora,
                IdGeneroPrimario = serie.IdGeneroPrimario,
                NombreGeneroPrimario = serie.GeneroPrimario.NombreGenero,
                IdGeneroSecundario = serie.IdGeneroSecundario,
                NombreGeneroSecundario = serie.GeneroSecundario?.NombreGenero
            }).ToList();
        }

        public async Task AddSerie(SeriesViewModel series)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }

            Serie serie = new();

            serie.Titulo = series.Titulo;
            serie.PortadaUrl = series.PortadaUrl;
            serie.VideoURl = series.VideoURl;
            serie.IdProductora = series.IdProductora;
            serie.IdGeneroPrimario = series.IdGeneroPrimario;
            serie.IdGeneroSecundario = series.IdGeneroSecundario;

            await _SerieRepository.AddS(serie);
        }

        public async Task<SeriesViewModel> GetSerieById(int id)
        {
            var serie = await _SerieRepository.GetByIdS(id);
            if (serie == null)
            {
                return null; // or handle the null case appropriately
            }
            string videoUrl = serie.VideoURl;
            if (!string.IsNullOrEmpty(videoUrl) && videoUrl.Contains("watch?v="))
            {
                // Extraer solo el ID del video
                var videoId = videoUrl.Split("watch?v=")[1].Split('&')[0];
                videoUrl = $"https://www.youtube.com/embed/{videoId}";
            }

            return new SeriesViewModel
            {
                Id = serie.IdSerie,
                Titulo = serie.Titulo,
                PortadaUrl = serie.PortadaUrl,
                VideoURl = videoUrl,
                IdProductora = serie.IdProductora,
                NombreProductora = serie.Productora?.NombreProductora,
                IdGeneroPrimario = serie.IdGeneroPrimario,
                NombreGeneroPrimario = serie.GeneroPrimario?.NombreGenero,
                IdGeneroSecundario = serie.IdGeneroSecundario,
                NombreGeneroSecundario = serie.GeneroSecundario?.NombreGenero
            };
        }

        public async Task DeleteS(int id)
        {
            var serie = await _SerieRepository.GetByIdS(id); // Buscar la serie por ID
            if (serie == null)
            {
                throw new ArgumentException($"No se encontró una serie con el ID {id}.");
            }
            await _SerieRepository.DeleteS(serie); // Llamar al repositorio para eliminar
        }

        public async Task UpdateS(SeriesViewModel model)
        {
            var serie = await _SerieRepository.GetByIdS(model.Id);
            if (serie == null)
            {
                throw new ArgumentException($"No se encontró la serie con ID {model.Id}.");
            }

            // Actualizar propiedades
            serie.Titulo = model.Titulo;
            serie.PortadaUrl = model.PortadaUrl;
            serie.VideoURl = model.VideoURl;
            serie.IdProductora = model.IdProductora;
            serie.IdGeneroPrimario = model.IdGeneroPrimario;
            serie.IdGeneroSecundario = model.IdGeneroSecundario;

            await _SerieRepository.UpdateS(serie);
        }



    }
}
