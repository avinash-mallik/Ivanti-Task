using Ivanti.API.Interface;
using Ivanti.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ivanti.API.Implementation
{
	public class ValidateInputService : IValidateInputService
	{
		public async Task<Tuple<int, int>> ValidateAndReturnRow_Column(string row_column)
		{
			if(row_column.Length > 0 && row_column.Length <= 3)
			{
				row_column = row_column.ToLower();
				int row = row_column[0] - 'a';
				bool parsed = Int32.TryParse(row_column[1..], out int column);
				if (parsed && column > 0 && column <= 12 && row >= 0 && row < 6)
				{
					return new Tuple<int, int>(row, column);
				}
				else
				{
					throw new CustomException("Invalid row or column");
				}
			}
			else
			{
				throw new CustomException("Invalid row or column");
			}
		}

		public async Task ValidateCoordinates(Coordinates[] coordinates)
		{
			if(coordinates.Length == 3)
			{
				foreach (var coordinate in coordinates)
				{
					var x = coordinate.X;
					var y = coordinate.Y;
					if(x % 10 == 0 && y % 10 == 0)
					{
						if(x < 0 || x > 60 || y < 0 || y > 60)
						{
							throw new CustomException("Coordinates should lie in the range [0-60]");
						}
					}

					else
					{
						throw new CustomException("Coordinates should be a multiple of 10");
					}
				}

				
				int c_100 = 0;
				int c_200 = 0;
				for(int i = 0; i < 3; i++)
				{
					for(int j = i + 1; j < 3; j++)
					{
						var diff_x = coordinates[i].X - coordinates[j].X;
						var diff_y = coordinates[i].Y - coordinates[j].Y;

						if((diff_x * diff_x) + (diff_y * diff_y) == 100)
							c_100++;

						else if((diff_x * diff_x) + (diff_y * diff_y) == 200)
							c_200++;

						if(Math.Abs(diff_x) == 10 && Math.Abs(diff_y) == 10)
						{
							var slope = diff_y / diff_x;
							if(slope == -1)
							{
								throw new CustomException("Invalid coordinates");
							}
						}
					}
				}

				if(!(c_100 == 2 && c_200 == 1))
				{
					throw new CustomException("Invalid coordinates");
				}
			}
		}
	}
}
