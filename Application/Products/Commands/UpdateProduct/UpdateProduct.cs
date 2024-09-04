using Application.Common.Interfaces;
using Domain.Entitities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(int Id, string? Sku, string Name , List<Category> Categories) : IRequest;


public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        // Get the target Product in Products
        var entity = await _context.Products
            .FindAsync(new object[] { request.Id }, cancellationToken);

        // Update Data of Product
        entity.Sku = request.Sku;
        entity.Name = request.Name;
        entity.Categories = request.Categories;

        // Commit Changes to DB
        await _context.SaveChangesAsync(cancellationToken);

    }
}


