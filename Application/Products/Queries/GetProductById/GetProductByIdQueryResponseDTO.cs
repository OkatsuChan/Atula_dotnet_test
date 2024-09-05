using Domain.Entitities;

namespace Application.Products.Queries.GetProductByIdById;

public class GetProductByIdQueryResponseDTO 
{
    public int Id { get; set; }
    public string Sku { get; set; }
    public string Name { get; set; }
    public List<Category> Categories { get; set; }
}

