
using Application.Products.Queries.GetAllProductById;
using Application.Products.Queries.GetProductByIdById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exam1MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator sender;

        public ProductController(IMediator sender)
        {
            this.sender = sender;
        }

        public  async Task<IActionResult> Index()
        {
            var request = new GetAllProductQuery();

            var response = await sender.Send(request);

            return View(response);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var request = new GetProductByIdQuery(id);

            var response = await sender.Send(request);

            return View(response);
        }
    }
}
