using Ivanti.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ivanti.API.Interface
{
	public interface IValidateInputService
	{
		Task<Tuple<int, int>> ValidateAndReturnRow_Column(string row_column);
		Task ValidateCoordinates(Coordinates[] coordinates);
	}
}
