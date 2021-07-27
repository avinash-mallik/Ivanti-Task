using Ivanti.API.Interface;
using Ivanti.API.Models;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Ivanti.UnitTest.Mock
{
	public class TriangleControllerMock : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			var coordinates = new Coordinates[] { new Coordinates { X = 0, Y = 0 }, new Coordinates { X = 0, Y = 10 }, new Coordinates { X = 10, Y = 10 } };
			var coordinateService = new Mock<ICoordinateService>();
			coordinateService.Setup(c => c.GetRowAndColumnByCoordinates(It.IsAny<Coordinates[]>())).ReturnsAsync("A1");
			coordinateService.Setup(c => c.GetCoordinatesForRowAndColumn(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(coordinates);

			var validateService = new Mock<IValidateInputService>();
			validateService.Setup(v => v.ValidateAndReturnRow_Column(It.IsAny<string>())).ReturnsAsync(new Tuple<int, int>(0,0));

			yield return new object[] { coordinateService,  validateService };
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
