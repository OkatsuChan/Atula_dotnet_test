using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(int Id, string Name) : IRequest;


public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        // Get the target Category in Categorys
        var entity = await _context.Categories
            .FindAsync(new object[] { request.Id }, cancellationToken);

        // Update Data of Category
        entity.Name = request.Name;

        // Commit Changes to DB
        await _context.SaveChangesAsync(cancellationToken);

    }
}
