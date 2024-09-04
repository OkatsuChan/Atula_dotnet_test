using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(int Id) : IRequest;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        // Get the target Category in Categories
        var entity = await _context.Categories
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

        // Remove the Category 
        _context.Categories.Remove(entity);


        // Commit Changes to DB
        await _context.SaveChangesAsync(cancellationToken);
    }
}
