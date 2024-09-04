using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        // Get the target Product in Products
        var entity = await _context.Products
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

        // Remove the Product 
        _context.Products.Remove(entity);


        // Commit Changes to DB
        await _context.SaveChangesAsync(cancellationToken);
    }
}