using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entitities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Queries.LoginUser;

public record LoginUserCommand : IRequest<Result>
{
    public string? Email { get; set; }

    public string? Password { get; set; }

}

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result>
{
    private readonly IIdentityService identityService;

    public LoginUserCommandHandler(IIdentityService identityService)
    {
        this.identityService = identityService;
    }
    public async Task<Result> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var result = await identityService.LoginAsync(request.Email, request.Password);

        return result;

    }
}




