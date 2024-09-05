using Application.Common.Interfaces;
using Application.Products.Queries.GetProductByIdById;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetAllProductById;

public record GetAllProductQuery() : IRequest<List<GetProductByIdQueryResponseDTO>>;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<GetProductByIdQueryResponseDTO>>
{
    private readonly IApplicationDbContext _context;

    public GetAllProductQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetProductByIdQueryResponseDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        // Get the target Product in Products
        var entities = await _context.Products.ToListAsync();

        // Set recordList
        var recordList = new List<GetProductByIdQueryResponseDTO>();

        // Loop each entities
        foreach (var entity in entities)
        {
            var getProductByIdQueryResponseDTO = new GetProductByIdQueryResponseDTO();

            // Assign the value from DB
            getProductByIdQueryResponseDTO.Id = entity.Id;
            getProductByIdQueryResponseDTO.Sku = entity.Sku;
            getProductByIdQueryResponseDTO.Name = entity.Name;
            getProductByIdQueryResponseDTO.Categories = entity.Categories;

            // Add to Record List
            recordList.Add(getProductByIdQueryResponseDTO);
        }

        // Return the recordList
        return recordList;
    }
}

