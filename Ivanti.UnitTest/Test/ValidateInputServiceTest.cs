using Ivanti.API.Implementation;
using Ivanti.API.Models;
using Ivanti.UnitTest.Mock;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ivanti.UnitTest.Test
{
	public class ValidateInputServiceTest
	{
		[Theory]
        [ClassData(typeof(ValidateInputServiceMock))]
		public async void ValidateAndReturnRow_ColumnTest()
		{
			var validInputService = new ValidateInputService();

			var result = await validInputService.ValidateAndReturnRow_Column("A1");

			Assert.True(result != null);
		}

		[Theory]
        [ClassData(typeof(ValidateInputServiceMock))]
		public async void ValidateCoordinatesTest()
		{
			var coordinates = new Coordinates[] { new Coordinates { X = 0, Y = 0 }, new Coordinates { X = 0, Y = 10 }, new Coordinates { X = 10, Y = 10 } };
			var validInputService = new ValidateInputService();

			await validInputService.ValidateCoordinates(coordinates);
		}
	}
}
