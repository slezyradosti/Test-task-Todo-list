using Application.Core;
using Domain.EntityModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using ReflectionIT.Mvc.Paging;
using Type = Domain.EntityModels.Type;

namespace Application.Types
{
    public class List
    {
        public class Query : IRequest<Result<List<Type>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<Type>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Type>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Type>>.Success(await _context.Types.AsQueryable()
                    .OrderBy(n => n.TypeName)
                    .ToListAsync(cancellationToken)
                    );
            }
        }
    }
}
