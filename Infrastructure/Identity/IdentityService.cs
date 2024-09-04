using Application.Common.Interfaces;
using Application.Common.Models;
using Application.User.Commands.CreateUser;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;

        public IdentityService(
           UserManager<ApplicationUser> userManager,
           IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
           IAuthorizationService authorizationService)
        {
            _userManager = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
        }
        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

            var result = await _authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(CreateUserCommand createUserCommand)
        {
            var user = new ApplicationUser 
            {
                Email = createUserCommand.EmailAddress,
                FirstName = createUserCommand.FirstName,
                LastName = createUserCommand.LastName
            };

            var identityResult = await _userManager.CreateAsync(user, createUserCommand.Password);

            var result = new Result( 
                                succeeded: identityResult.Succeeded,
                                errors: identityResult.Errors.Select(error => error.Description));

            return (result, user.Id);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user != null 
                ? await DeleteUserAsync(user.Id) 
                : Result.Success();
        }

        public async Task<string?> GetUserNameAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user?.UserName;
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user != null && await _userManager.IsInRoleAsync(user, role);
        }
    }
}
