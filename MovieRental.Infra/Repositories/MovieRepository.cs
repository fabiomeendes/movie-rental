using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
     
        public IEnumerable<Movie> ListMovies()
        {
            return _dbContext.Set<Movie>().ToList();
        }

        public void CreateMovie(Movie model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }

        public void UpdateMovie(Movie model)
        {
            _dbContext.Entry(model).CurrentValues.SetValues(model);
            _dbContext.SaveChanges();
        }
    }
}
