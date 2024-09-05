using Application.Categories.Queries;
using Application.Categories.Queries.GetCategoryById;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exam1MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator sender;

        public CategoryController(IMediator sender)
        {
            this.sender = sender;
        }

        public  async Task<IActionResult> Index()
        {
            var request = new GetAllCategoryQuery();

            var response = await sender.Send(request);

            return View(response);
        }
    }
}
