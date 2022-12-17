using Domain.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Application.TheNotes;
using Application.Activities;

namespace TodoList.WebUI.Controllers
{
	public class NotesController : BaseController
    {
		public IActionResult Index(string typeName) => typeName switch
		{
			"Default" => RedirectToAction(nameof(DefaultList)),
			"Archived" => RedirectToAction(nameof(ArchivedList)),
			_ => throw new ArgumentOutOfRangeException(nameof(typeName), $"Not expected direction value: {typeName}"),
		};

		public async Task<IActionResult> DefaultList(int pageIndex = 1)
		{
			ViewBag.listName = nameof(DefaultList);
			ViewBag.buttonArchiveName = "Archive";
            ViewBag.listCount = pageIndex > 1 ? pageIndex * 5 - 4 : pageIndex;

            return HandleResult(await Mediator
				.Send(new ListDefault.Query() { pageIndex = pageIndex }, 
				new CancellationToken()));
		}

		public async Task<IActionResult> ArchivedList(int pageIndex = 1)
		{
			ViewBag.listName = nameof(ArchivedList);
			ViewBag.buttonArchiveName = "Unarchive";
			ViewBag.listCount = pageIndex > 1 ? pageIndex * 5 - 4 : pageIndex;

			return HandleResult(await Mediator
				.Send(new ListArchived.Query() { pageIndex = pageIndex },
				new CancellationToken()));
		}


		public IActionResult Create(string listName)
		{
            ViewBag.listName = listName;
            return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Notes theNote, string listName)
		{
			await Mediator.Send(new Create.Command { Note = theNote });
			return RedirectToAction(listName);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(Guid Id, string listName)
		{
			await Mediator.Send(new Delete.Command { Id = Id });
			return RedirectToAction(listName);
		}

		[HttpPost]
		public async Task<IActionResult> Archive(Guid Id, string listName)
		{
			await Mediator.Send(new Archive.Command { Id = Id });
			return RedirectToAction(listName);
		}

		[HttpPost]
		public async Task<IActionResult> Check(Guid Id)
		{
			await Mediator.Send(new Check.Command { Id = Id });
			return RedirectToAction(nameof(DefaultList));
		}

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? Id, string listName)
		{
            ViewBag.listName = listName;
            return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Notes theNote, string listName)
		{
			await Mediator.Send(new Edit.Command { Note = theNote });
			return RedirectToAction(listName);
		}
	}
}
