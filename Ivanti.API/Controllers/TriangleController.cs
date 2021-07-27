using Ivanti.API.Interface;
using Ivanti.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Ivanti.API.Controllers
{
	[Route("api/Triangle")]
	[ApiController]
	public class TriangleController : Controller
	{
		private readonly ICoordinateService _coordinateService;
		private readonly IValidateInputService _validateInputService;

		public TriangleController(ICoordinateService coordinateService, IValidateInputService validateInputService)
		{
			_coordinateService = coordinateService;
			_validateInputService = validateInputService;
		}
		// GET: api/Triangle/GetCoordinates/A1
		[HttpGet("GetCoordinates/{row_column}")]
		public async Task<IActionResult> GetCoordinates(string row_column)
		{			
			var results = await _validateInputService.ValidateAndReturnRow_Column(row_column);
			var coordinates = await _coordinateService.GetCoordinatesForRowAndColumn(results.Item1, results.Item2);
			return Ok(coordinates);
		}

		// POST: api/Triangle/GetRowAndColumn
		[HttpPost("GetRowAndColumn")]
		public async Task<IActionResult> GetRowAndColumn([FromBody] Coordinates[] coordinates)
		{
			await _validateInputService.ValidateCoordinates(coordinates);
			var row_column = await _coordinateService.GetRowAndColumnByCoordinates(coordinates);
			return Ok(row_column);
		}
	}
}
