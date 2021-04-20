using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MovieApp.Data.Repositories;
using MovieApp.Contracts.Repositories;
using MovieApp.Models;

namespace MovieApp.Controllers
{
	[Route("api")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly IMovieRepository _movieRepository;

		public MoviesController(IMovieRepository movieRepository)
		{
			_movieRepository = movieRepository;
		}

		[HttpGet("/[controller]")]
		public async Task<IActionResult> GetMovies()
		{
			return Ok(await _movieRepository.GetAllMovies());
		}

		[HttpGet("/[controller]/{id}")]
		public async Task<IActionResult> GetMovies(int id)
		{
			var movie = await _movieRepository.GetMovieById(id);

			if (movie != null)
			{
				return Ok(movie);
			}

			return NotFound(new { Message = $"Movie with id {id} is not available." });
		}

		[HttpGet("/Directors")]
		public async Task<IActionResult> GetDirectors()
		{
			return Ok(await _movieRepository.GetAllDirectors());
		}

		[HttpPost("/[controller]")]
		public async Task<IActionResult> AddMovie(CreateMovieModel model)
		{
			var result = await _movieRepository.AddMovie(model);
			if (result > 0)
			{
				return Ok(new { Message = "Movie added successfully." });
			}

			return StatusCode(500, new { Message = "Some error happened" });
		}
	}
}