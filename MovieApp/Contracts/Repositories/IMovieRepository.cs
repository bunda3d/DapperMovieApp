using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MovieApp.Models;

namespace MovieApp.Contracts.Repositories
{
	public interface IMovieRepository
	{
		Task<IEnumerable<MovieModel>> GetAllMovies();

		Task<MovieModel> GetMovieById(int id);

		Task<IEnumerable<DirectorModel>> GetAllDirectors();

		Task<int> AddMovie(CreateMovieModel movie);
	}
}