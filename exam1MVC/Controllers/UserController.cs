using Application.Common.Interfaces;
using Application.User.Commands.LoginUser;
using exam1MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace exam1MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator sender;

        public UserController(IMediator sender)
        {
            this.sender = sender;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var request = new LoginUserCommand();

                // Set Email and Password
                request.Email = model.Email; //administrator@localhost
                request.Password = model.Password; // Administrator1!

                var response = await this.sender.Send(request);
                
                if (response.Succeeded)
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Category");
                }

                //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }



    }
}
