using Application.Core;
using Domain.EntityModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using ReflectionIT.Mvc.Paging;

namespace Application.TheNotes
{
	public class ListArchived
	{
		public class Query : IRequest<Result<PagingList<Notes>>>
		{
			public int pageIndex { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<PagingList<Notes>>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Result<PagingList<Notes>>> Handle(Query request, CancellationToken cancellationToken)
			{
				return Result<PagingList<Notes>>.Success(MakePagination(await _context.Notes.AsQueryable()
					.Include(n => n.Type)
					.Where(n => n.Type.TypeName == "Archived")
					.OrderBy(n => n.isChecked)
					.ThenByDescending(n => n.Date)
					.ToListAsync(cancellationToken), request.pageIndex)
					);
			}

			private PagingList<Notes> MakePagination(IEnumerable<Notes> query, int pageIndex)
			{
				var model = PagingList.Create(query, 5, pageIndex);
				model.Action = "ArchivedList";
				return model;
			}
		}
	}
}
