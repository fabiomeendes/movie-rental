using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> ListMovies();

        void CreateMovie(Movie model);

        void UpdateMovie(Movie model);
    }
}
