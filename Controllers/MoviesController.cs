using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace PracticaconAri.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MoviesController : ControllerBase
    {
        private static readonly List<Movie> _movies = new()
        {
            new Movie { Id = Guid.NewGuid(), Title = "Titanic", Genre = "drama", ReleaseDate = new DateTime(2000,12,07), DurationMinutes = 120, Available = true },
            new Movie { Id = Guid.NewGuid(), Title = "Charlie y la Fabrica de Chocolate", Genre = "fantasy", ReleaseDate = new DateTime(2005,11,13), DurationMinutes = 100, Available = true },
             new Movie { Id = Guid.NewGuid(), Title = "Los Increibles", Genre = "fantasy", ReleaseDate = new DateTime(2008,10,13), DurationMinutes = 90, Available = true },
        };

        private static (int page, int limit) NormalizePage(int? page, int? limit)
        {
            var p = page.GetValueOrDefault(1);
            if(p<1) p = 1;

            var l = limit.GetValueOrDefault(10);
            if(l<1) l = 1;
            if (l > 100) l = 100;

            return (p, l);
        }

        private static IEnumerable<T> OrderByProp<T>(IEnumerable<T> src, string? sort, string? order)
        {
            if(string.IsNullOrWhiteSpace(sort)) return src;
            var prop = typeof(T).GetProperty(sort,BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if(prop is null) return src;

            return string.Equals(order, "desc", StringComparison.OrdinalIgnoreCase)
                ? src.OrderByDescending(x => prop.GetValue(x))
                : src.OrderBy(x => prop.GetValue(x));
        }

        //LIST GET movies
        [HttpGet]
        public IActionResult GetAll(
            [FromQuery] int? page,
            [FromQuery] int?limit,
            [FromQuery] string?sort,
            [FromQuery] string? order,
            [FromQuery] string? q
        )

        {
            var (p, l) = NormalizePage(page, limit);

            IEnumerable<Movie> query = _movies;

            //ordenamiento
            query=OrderByProp(query, sort, order);

            //paginacion
            var total = query.Count();
            var data = query.Skip((p - 1) * l).Take(l).ToList();

            return Ok(new
            {
                data,
                meta = new { page = p, limit = l, total }
            });


       

        }

        //get  by id
        [HttpGet("{id:guid}")]
        public ActionResult<Movie> GetOne(Guid id)
        {
            var movie = _movies.FirstOrDefault(x => x.Id == id);
            return movie is null
                ? NotFound(new { error = "Movie not found", status = 404 })
                : Ok(movie);
        }

        //POST
        [HttpPost]
        public ActionResult<Movie> Create([FromBody] CreateMovieDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var movie = new Movie
            {
                Id = Guid.NewGuid(),
                Title = dto.Title.Trim(),
                Genre = dto.Genre.Trim(),
                ReleaseDate= dto.ReleaseDate,
                DurationMinutes = dto.DurationMinutes,
                Available = dto.Available
            };

            _movies.Add(movie);
            return CreatedAtAction(nameof(GetOne), new { id = movie.Id }, movie);

        }
    }
}
