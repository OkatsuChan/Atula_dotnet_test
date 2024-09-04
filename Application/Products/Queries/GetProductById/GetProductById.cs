using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductByIdById;

public record GetProductByIdQuery(int Id) : IRequest<GetProductByIdQueryResponseDTO>;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResponseDTO>
{
    private readonly IApplicationDbContext _context;

    public GetProductByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GetProductByIdQueryResponseDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the target Product in Products
        var entity = await _context.Products.FirstOrDefaultAsync(l => l.Id == request.Id);

       return new GetProductByIdQueryResponseDTO 
        {
            Id = entity.Id,
            Sku= entity.Sku,
            Name = entity.Name,
        };
    }
}

