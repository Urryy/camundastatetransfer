using CamundaState.Models;
using CamundaState.Services;
using Microsoft.AspNetCore.Mvc;

namespace CamundaState.Controllers
{
	[ApiController]
	[Route("api/state/[controller]")]
	public class StateTranslaterController : Controller
	{
		private readonly ICamundaTranslateService _camundaTranslateService;
		public StateTranslaterController(ICamundaTranslateService camundaTranslateService)
		{
			_camundaTranslateService = camundaTranslateService;
		}
		[HttpGet]
		[Route("task")]
		public async Task<IActionResult> CreateTaskInCamunda()
		{
			try
			{
				var response = await _camundaTranslateService.CheckIsTranslate();

				return response.status
					? await ExecuteTaskInCamunda(response.data)
					: BadRequest("Oop's something went wrong");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		[HttpGet]
		[Route("execute")]
		public async Task<IActionResult> ExecuteTaskInCamunda(IEnumerable<ProjectWf> projects)
		{
			if (projects.Count() == 0)
				return BadRequest("Projects are empty");

			var isTranslated = await _camundaTranslateService.InvokeTask(projects);
			return Ok(isTranslated);
		}
	}
}
