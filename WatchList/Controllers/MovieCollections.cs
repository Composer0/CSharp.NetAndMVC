using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchList.Data;
using WatchList.Models.Database;

namespace WatchList.Controllers
{
    public class MovieCollections : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieCollections(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id) //so the user can specify the id of a movie colleciton
        {
            id ??= (await _context.Collection.FirstOrDefaultAsync(c => c.Name.ToUpper() == "ALL")).Id; //null-coalescing operator. Only use if we are assigning a value from the right to a null left operand.

            ViewData["CollectionId"] = new SelectList(_context.Collection, "Id", "Name", id);

            var allMovieIds = await _context.Movie.Select(m => m.Id).ToListAsync();

            //Provides the movies in the collection.
            var movieIdsInCollection = await _context.MovieCollection
                                                     .Where(m => m.CollectionId == id)
                                                     .OrderBy(m => m.Order)
                                                     .Select(m => m.MovieId)
                                                     .ToListAsync();
            //Movie ids not in collection
            var movieIdsNotInCollection = allMovieIds.Except(movieIdsInCollection);
            var moviesInCollection = new List<Movie>();
            
            movieIdsInCollection.ForEach(movieId => moviesInCollection.Add(_context.Movie.Find(movieId)));
            ViewData["IdsInCollection"] = new MultiSelectList(moviesInCollection, "Id", "Title");

            var moviesNotInCollection = await _context.Movie.AsNoTracking().Where(m => movieIdsNotInCollection.Contains(m.Id)).ToListAsync();
            ViewData["IdsNotInCollection"] = new MultiSelectList(moviesNotInCollection, "Id", "Title");

            return View();
        }

        //Adding Movies into the User's Collection
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id, List<int> idsInCollection)
        {
            var oldRecords = _context.MovieCollection.Where(c => c.CollectionId == id);
            _context.MovieCollection.RemoveRange(oldRecords);
            await _context.SaveChangesAsync();

            if (idsInCollection != null)
            {
                int index = 1;
                idsInCollection.ForEach(movieId =>
                {
                    _context.Add(new MovieCollection()
                    {
                        CollectionId = id,
                        MovieId = movieId,
                        Order = index++
                    });
                });

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index), new { id });
        }

    }
}
