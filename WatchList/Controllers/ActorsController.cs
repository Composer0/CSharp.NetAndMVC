using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WatchList.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WatchList.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IRemoteMovieService _tmdbMovieService;
        private readonly IDataMappingService _mappingService;

        public ActorsController(IRemoteMovieService tmdbMovieService, IDataMappingService mappingService)
        {
            _tmdbMovieService = tmdbMovieService;
            _mappingService = mappingService;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var actor = await _tmdbMovieService.ActorDetailAsync(id);
            actor = _mappingService.MapActorDetailAsync(actor); //Check this at a later point...
            return View(actor);
        }
    }
}
