using Application.Common.Interfaces;
using Domain.Entitities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Commands.CreateUser;

public record CreateUserCommand : IRequest<string>
{
    public string? EmailAddress { get; init; }

    public string? Password { get; init; }

    public string? LastName { get; init; }

    public string? FirstName { get; init; }


    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IIdentityService identityService;

        public CreateUserCommandHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }
        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
             var result = await identityService.CreateUserAsync(request);

            return result.UserId;
        }
    }
}




