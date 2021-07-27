using Ivanti.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ivanti.API.Interface
{
	public interface ICoordinateService
	{
		Task<Coordinates[]> GetCoordinatesForRowAndColumn(int row, int column);
		Task<string> GetRowAndColumnByCoordinates(Coordinates[] coordinates);
	}
}
