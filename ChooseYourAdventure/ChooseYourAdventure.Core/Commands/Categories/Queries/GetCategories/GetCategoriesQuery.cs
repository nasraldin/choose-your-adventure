using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChooseYourAdventure.Core.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Core.Commands.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<CategoryDto>>
    {
        public class GetCategoriesQueryHandler :
            IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
            {
                return await _context.Categories.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            }
        }
    }
}
