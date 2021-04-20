using System.Collections.Generic;

namespace MovieApp.Models
{
	public class DirectorModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IList<DirectorMovie> Movies { get; set; }
	}
}