using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace TodoList.WebUI.Controllers
{
    public class BaseController : Controller
    {
		private IMediator _mediator;
		protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
			.GetService<IMediator>();

		protected ActionResult HandleResult<T>(Result<T> result, string view = null)
		{
			if (result == null) return NotFound();
			if (result.IsSuccess && result.Value != null)
			{
				if (view != null) return View(view, result.Value);
				else return View(result.Value);
			}
			if (result.IsSuccess && result.Value == null) return NotFound();
			return BadRequest();
		}

	}
}
