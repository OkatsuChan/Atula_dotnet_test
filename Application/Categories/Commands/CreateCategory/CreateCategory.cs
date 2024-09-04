using Application.Common.Interfaces;
using Domain.Entitities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand : IRequest<int>
{

    public string? Name { get; set; }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Category();

        // Set Data to Category
        entity.Name = request.Name;

        // Add to Categorys
        _context.Categories.Add(entity);

        // Commit Changes to DB
        await _context.SaveChangesAsync(cancellationToken);

        // Return the newly Created Id
        return entity.Id;
    }
}
