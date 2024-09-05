using Application.Common.Interfaces;
using Application.User.Queries.LoginUser;
using exam1MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
        public async Task<IActionResult> Login(LoginUserCommand request)
        {
            //// Set Email and Password
            //request.Email = model.Email; //administrator@localhost
            //request.Password = model.Password; // Administrator1!

            try
            {
                var response = await this.sender.Send(request);

                if (response.Succeeded)
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Category");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Invalid login attempt. {ex.Message}";
            }

            return View();
        }



    }
}
