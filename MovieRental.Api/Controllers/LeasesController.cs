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
    public class LeasesController : ControllerBase
    {
        private readonly ILeaseRepository _leaseRepository;
        private readonly IMovieRepository _movieRepository;
        public LeasesController(ILeaseRepository leaseRepository, IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
            _leaseRepository = leaseRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            // TODO
            var movies = _leaseRepository.ListLeases();
            return Ok(movies);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] LeaseDTO model)
        {
            var movies = _movieRepository.ListMovies();

            var m = movies.Where(x => x.IsActive == true && x.IsRent == false && x.MovieId == model.MovieId);

            if (m == null || m.Count() <= 0)
            {
                return BadRequest(new RequestDTO { Status = HttpStatusCode.BadRequest, Message = "Movie is not available or do not exist" });
            }

            _leaseRepository.CreateLease(new Lease
            {
                CustomerId = model.CustomerId,
                MovieId = model.MovieId,
                RentalDate = DateTime.Now,
                IsActive = true
            });

            var movie = m.FirstOrDefault();
            movie.IsRent = true;
            _movieRepository.UpdateMovie(movie);

            return Ok(new RequestDTO { Status = HttpStatusCode.Created, Message = "Data Successfully" });
        }

        // POST api/values
        [HttpPost("return")]
        public ActionResult ReturnMovie([FromBody] LeaseDTO model)
        {
            var movies = _movieRepository.ListMovies();

            var m = movies.Where(x => x.IsActive == true && x.IsRent == true && x.MovieId == model.MovieId);

            if (m == null || m.Count() <= 0)
            {
                return BadRequest(new RequestDTO { Status = HttpStatusCode.BadRequest, Message = "Movie is not available, do not exist or already returned" });
            }

            var leases = _leaseRepository.ListLeases();
            var lease = leases.Where(x => x.IsActive = true && x.CustomerId == model.CustomerId && x.MovieId == model.MovieId).FirstOrDefault();
            lease.ReturnDate = DateTime.Now;
            _leaseRepository.UpdateLease(lease);

            var movie = m.FirstOrDefault();
            movie.IsRent = false;
            _movieRepository.UpdateMovie(movie);

            if (DateTime.Now > lease.RentalDate.AddDays(movie.DaysMax))
            {
                return Ok("Movie return is late");
            }

            return Ok(new RequestDTO { Status = HttpStatusCode.OK, Message = "Data Successfully" });
        }
    }
}
