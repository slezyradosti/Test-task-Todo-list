using Application.Core;
using MediatR;
using Domain.EntityModels;
using Persistence;
using System.Formats.Asn1;

namespace Application.TheNotes
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Notes Note { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				request.Note.TypeId = _context.Types.First(t => t.TypeName == "Default").Id;
				_context.Notes.Add(request.Note);
				var result = await _context.SaveChangesAsync() > 0;

				if (!result) return Result<Unit>.Failure("Failed to create activity");

				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}
