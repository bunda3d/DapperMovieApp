using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Data.Helpers
{
	public sealed class ConnectionString
	{
		public ConnectionString(string value) => Value = value;

		public string Value { get; }
	}
}