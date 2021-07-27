using Ivanti.API.Controllers;
using Ivanti.API.Interface;
using Ivanti.API.Models;
using Ivanti.UnitTest.Mock;
using Moq;
using Xunit;

namespace Ivanti.UnitTest.Test
{
	public class TriangleControllerTest
	{
		[Theory]
        [ClassData(typeof(TriangleControllerMock))]
		public async void GetCoordinatesTest(Mock<ICoordinateService> coordinateService, Mock<IValidateInputService> validateInputService)
		{
			var triangleController = new TriangleController(coordinateService.Object, validateInputService.Object);

			await triangleController.GetCoordinates("A1");
		}

		[Theory]
		[ClassData(typeof(TriangleControllerMock))]
		public async void GetRowAndColumnTest(Mock<ICoordinateService> coordinateService, Mock<IValidateInputService> validateInputService)
		{
			var coordinates = new Coordinates[] { new Coordinates { X = 0, Y = 0 }, new Coordinates { X = 0, Y = 10 }, new Coordinates { X = 10, Y = 10 } };

			var triangleController = new TriangleController(coordinateService.Object, validateInputService.Object);

			await triangleController.GetRowAndColumn(coordinates);
		}
	}
}
