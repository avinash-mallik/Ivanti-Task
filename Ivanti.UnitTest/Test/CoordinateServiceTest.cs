using Ivanti.API.Implementation;
using Ivanti.API.Models;
using Ivanti.UnitTest.Mock;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ivanti.UnitTest.Test
{
	public class CoordinateServiceTest
	{
		[Theory]
        [ClassData(typeof(CoordinateServiceMock))]
		public async void GetCoordinatesTest()
		{
			var testData = new Coordinates[] { new Coordinates { X = 0, Y = 0 }, new Coordinates { X = 0, Y = 10 }, new Coordinates { X = 10, Y = 10 } };
			var coordinateService = new CoordinateService();

			var result = await coordinateService.GetCoordinatesForRowAndColumn(0, 1);

			Assert.True(CheckCoordinates(result, testData));
		}

		[Theory]
		[ClassData(typeof(CoordinateServiceMock))]
		public async void GetRowAndColumnTest()
		{
			var coordinates = new Coordinates[] { new Coordinates { X = 0, Y = 0 }, new Coordinates { X = 0, Y = 10 }, new Coordinates { X = 10, Y = 10 } };

			var coordinateService = new CoordinateService();

			var result = await coordinateService.GetRowAndColumnByCoordinates(coordinates);

			Assert.True(result == "A1");
		}

		private bool CheckCoordinates(Coordinates[] result, Coordinates[] testData)
		{
			for(int i = 0; i < 3; i++)
			{
				if(result[i].X != testData[i].X || result[i].Y != testData[i].Y)
					return false;
			}
			return true;
		}
	}
}
