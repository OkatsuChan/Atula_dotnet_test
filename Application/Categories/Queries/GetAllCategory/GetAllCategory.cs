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


public record GetAllCategoryQuery() : IRequest<List<GetCategoryByIdQueryResponseDTO>>;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<GetCategoryByIdQueryResponseDTO>>
{
    private readonly IApplicationDbContext _context;

    public GetAllCategoryQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetCategoryByIdQueryResponseDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        // Get the target Category in Categorys
        var entities = await _context.Categories.ToListAsync();

        // Set recordList
        var recordList = new List<GetCategoryByIdQueryResponseDTO>();

        // Loop each entities
        foreach (var entity in entities)
        {
            var getCategoryByIdQueryResponseDTO = new GetCategoryByIdQueryResponseDTO();

            // Assign the value from DB
            getCategoryByIdQueryResponseDTO.Id = entity.Id;
            getCategoryByIdQueryResponseDTO.Name = entity.Name;

            // Add to Record List
            recordList.Add(getCategoryByIdQueryResponseDTO);
        }

        // Return the recordList
        return recordList;
    }
}
