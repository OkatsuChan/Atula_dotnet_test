
using Application.Products.Queries.GetAllProductById;
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
    }
}
