using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;
using Domain.EntityModels;

namespace Application.TheNotes
{
	public class Archive
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid Id { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				Notes theNote = _context.Notes.First(n => n.Id == request.Id);

				Guid defaultId = _context.Types.First(t => t.TypeName == "Default").Id;

				if (theNote.TypeId == defaultId)
				{
					theNote.TypeId = _context.Types.First(t => t.TypeName == "Archived").Id;
				}
				else
				{
					theNote.TypeId = defaultId;
				}

				var note = await _context.Notes.FindAsync(theNote.Id);

				if (note == null) return null;

				_mapper.Map(theNote, note);
				var result = await _context.SaveChangesAsync() > 0;

				if (!result) return Result<Unit>.Failure("Failed to update activity");

				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}