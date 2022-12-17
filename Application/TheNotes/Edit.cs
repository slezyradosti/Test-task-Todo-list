using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;
using Domain.EntityModels;

namespace Application.TheNotes
{
	public class Edit
	{
		public class Command : IRequest<Result<Unit>>
		{
            public Notes Note { get; set; }
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
                var note = await _context.Notes.FindAsync(request.Note.Id);

                if (note == null) return null;

                _mapper.Map(request.Note, note);
                var result = await _context.SaveChangesAsync() > 0;

				if (!result) return Result<Unit>.Failure("Failed to update activity");

				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}