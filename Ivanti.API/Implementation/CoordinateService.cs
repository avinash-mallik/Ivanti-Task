using Ivanti.API.Interface;
using Ivanti.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ivanti.API.Implementation
{
	public class CoordinateService : ICoordinateService
	{
		public async Task<Coordinates[]> GetCoordinatesForRowAndColumn(int row, int column)
		{
			var coordinates = new Coordinates[3];			
			if(column % 2 == 0)
			{
				column = (column - 2) / 2;
				coordinates[0] = new Coordinates { X = column * 10, Y = row * 10 };
				coordinates[1] = new Coordinates { X = (column + 1) * 10, Y = row * 10 };
				coordinates[2] = new Coordinates { X = (column + 1) * 10, Y = (row + 1) * 10 };
			}
			else
			{
				column = (column - 1) / 2;
				coordinates[0] = new Coordinates { X = column * 10, Y = row * 10 };
				coordinates[1] = new Coordinates { X = column * 10, Y = (row + 1) * 10 };
				coordinates[2] = new Coordinates { X = (column + 1) * 10, Y = (row + 1) * 10 };
			}

			return coordinates;
		}

		public async Task<string> GetRowAndColumnByCoordinates(Coordinates[] coordinates)
		{
			var result_x = ReturnMinMax(coordinates[0].X, coordinates[1].X, coordinates[2].X);
			var result_y = ReturnMinMax(coordinates[0].Y, coordinates[1].Y, coordinates[2].Y);

			for(int i = 0; i < 3; i++)
			{
				var cond1 = (coordinates[i].X == result_x.Item1) && (coordinates[i].Y == result_y.Item1);
				var cond2 = (coordinates[i].X == result_x.Item2) && (coordinates[i].Y == result_y.Item2);
				if(!cond1 && !cond2)
				{
					char row;
					int column;
					if(coordinates[i].X == result_x.Item1)
					{
						row = (char)(coordinates[i].Y / 10 - 1 + 'A');
						column = coordinates[i].X / 10 * 2 + 1;
					}
					else
					{
						row = (char)(coordinates[i].Y / 10 + 'A');
						column = (coordinates[i].X / 10) * 2;
					}

					return row.ToString() + column.ToString();
				}
			}
			return "";
		}

		private Tuple<int,int> ReturnMinMax(int a, int b, int c)
		{
			int min = a < b ? (a < c ? a : c) : (b < c ? b : c);
			int max = a > b ? (a > c ? a : c) : (b > c ? b : c);
			return new Tuple<int, int>(min, max);
		}
	}
}
