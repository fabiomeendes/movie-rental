using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RentalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            var movies = _movieRepository.ListMovies();
            return Ok(new RequestDTO<List<Movie>> { Data = movies.ToList(), Status = HttpStatusCode.OK, Message = "Data Successfully" });
        }

        [HttpPost]
        public ActionResult Post([FromBody] Movie model)
        {
            var movies = _movieRepository.ListMovies();

            _movieRepository.CreateMovie(new Movie
            {
                Name = model.Name,
                DaysMax = model.DaysMax,
                IsRent = false,
                IsActive = true
            });

            return Ok(new RequestDTO<Movie> { Status = HttpStatusCode.Created, Message = "Data Successfully" });
        }
    }
}
