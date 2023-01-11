using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using WatchList.Data;
using WatchList.Enums;
using WatchList.Models;
using WatchList.Models.TMDB;
using WatchList.Models.ViewModels;
using WatchList.Services;
using WatchList.Services.Interfaces;

namespace WatchList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; //update constructor to allow for DbContext --- Database
        private readonly ApplicationDbContext _context;
        private readonly IRemoteMovieService _tmdbMovieService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IRemoteMovieService tmdbMovieService)
        {
            _logger = logger;
            _context = context;
            _tmdbMovieService = tmdbMovieService;
        }

        public async Task<IActionResult> Index()
        {


            const int count = 16; //pulls 16 records for each category.
            var data = new LandingPageVM()
            {
                CustomCollections = await _context.Collection.Include(c => c.MovieCollections)
                                                             .ThenInclude(mc => mc.Movie)
                                                             .ToListAsync(),
                NowPlaying = await _tmdbMovieService.MovieSearchAsync(MovieCategory.now_playing, count),
                Popular = await _tmdbMovieService.MovieSearchAsync(MovieCategory.popular, count),
                TopRated = await _tmdbMovieService.MovieSearchAsync(MovieCategory.top_rated, count),
                Upcoming = await _tmdbMovieService.MovieSearchAsync(MovieCategory.upcoming, count)

            };
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
