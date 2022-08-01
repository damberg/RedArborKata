using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedArborKata.Models;
using RedArborKata.Services;

namespace RedArborKata.Controllers
{
	[ApiController]
	[Route("api/RedArbor")]
	public class RedArborController : ControllerBase
	{
		private RedArborService<Employees> _RedArborService;

		public RedArborController(RedArborService<Employees> RedArborService)
		{
			_RedArborService = RedArborService;
		}

		/// <summary>
		/// Get all employees items
		/// </summary>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees[]))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Get()
		{
			try
			{
				var employees = _RedArborService.get();
				return Ok(JsonConvert.SerializeObject(employees));
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		/// <summary>
		/// Get an item by ID
		/// </summary>
		[Route("/{id}")]
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult GetByID(int id)
		{
			try
			{
				var employee = _RedArborService.GetByID(id);
				return Ok(JsonConvert.SerializeObject(employee));
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}


		/// <summary>
		/// Add a new item
		/// </summary>
		// [Route("Create")]
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Create(Employees employee)
		{
			try
			{
				var employeeResult = _RedArborService.Create(employee);
				return Ok(JsonConvert.SerializeObject(employeeResult));
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		/// <summary>
		/// Update an existing item
		/// </summary>
		//[Route("{id}")]
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Update(int employeeID, Employees employee)
		{
			try
			{
				_RedArborService.Update(employeeID, employee);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		/// <summary>
		/// Delete an item
		/// </summary>
		[Route("Delete/{id}")]
		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Delete(int id)
		{
			try
			{
				_RedArborService.Delete(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

	}
}

