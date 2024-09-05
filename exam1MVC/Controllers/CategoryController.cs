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
        private readonly IUser user;
        private readonly IIdentityService identityService;

        public CategoryController(IMediator sender, IUser  user, IIdentityService identityService)
        {
            this.sender = sender;
            this.user = user;
            this.identityService = identityService;
        }

        public  async Task<IActionResult> Index()
        {

            var userName = await this.identityService.GetUserNameAsync(this.user.Id);

            TempData["SuccessMessage"] = $"Successful Login!, Welcome User {userName}";

            var request = new GetAllCategoryQuery();

            var response = await sender.Send(request);

            return View(response);
        }
    }
}
