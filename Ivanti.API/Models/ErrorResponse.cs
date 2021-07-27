using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ivanti.API.Models
{
	public class ErrorResponse
	{
		public Error Error { get; set; }
	}

	public class Error
	{
		public int StatusCode { get; set; }
		public string Message { get; set; }
	}
}
