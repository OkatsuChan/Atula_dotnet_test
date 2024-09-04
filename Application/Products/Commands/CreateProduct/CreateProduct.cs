using Application.Common.Interfaces;
using Domain.Entitities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<int>
{

    public string? Sku { get; set; }

    public string? Name { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product();

        // Set Data to Product
        entity.Sku = request.Sku;
        entity.Name = request.Name;

        // Add to Products
        _context.Products.Add(entity);

        // Commit Changes to DB
        await _context.SaveChangesAsync(cancellationToken);

        // Return the newly Created Id
        return entity.Id;
    }
}


