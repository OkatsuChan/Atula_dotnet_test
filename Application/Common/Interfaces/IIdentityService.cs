using Application.Common.Models;
using Application.User.Commands.CreateUser;
using Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string?> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(CreateUserCommand createUserCommand);

        Task<Result> DeleteUserAsync(string userId);

        Task<Result> LoginAsync(string? email, string? password);

    }
}
