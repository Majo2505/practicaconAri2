using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticAssets;
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
    }
}
