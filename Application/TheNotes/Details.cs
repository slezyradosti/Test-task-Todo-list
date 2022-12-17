using Application.Core;
using Domain.EntityModels;
using MediatR;
using Persistence;

namespace Application.Activities
{
	public class Details
	{
		public class Query : IRequest<Result<Notes>>
		{
			public Guid? Id { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<Notes>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Result<Notes>> Handle(Query request, CancellationToken cancellationToken)
			{
				bool result = true;
				if (request.Id == null || request.Id == Guid.Empty)
				{
					result = false;
				}

				var note = await _context.Notes.FindAsync(request.Id);
				if (note == null)
				{
					result = false;
				}

				if (!result) return Result<Notes>.Failure("Failed to create activity");

				return Result<Notes>.Success(note);
			}
		}
	}
}
