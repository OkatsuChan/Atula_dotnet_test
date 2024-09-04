using Application.Common.Interfaces;
using Application.Categories.Queries.GetCategoryById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.Queries;

public record GetCategoryByIdQuery(int Id) : IRequest<GetCategoryByIdQueryResponseDTO>;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResponseDTO>
{
    private readonly IApplicationDbContext _context;

    public GetCategoryByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GetCategoryByIdQueryResponseDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the target Category in Categorys
        var entity = await _context.Categories.FirstOrDefaultAsync(l => l.Id == request.Id);

        return new GetCategoryByIdQueryResponseDTO
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}
