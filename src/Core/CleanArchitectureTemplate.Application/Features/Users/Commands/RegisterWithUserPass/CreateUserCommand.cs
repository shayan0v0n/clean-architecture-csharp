using AutoMapper;
using CleanArchitectureTemplate.Domain.DomainServiceResult;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Identity;
using CleanArchitectureTemplate.Domain.Repositories;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.Users.Commands.RegisterWithUserPass
{

    public partial class CreateUserCommand : IRequest<IDomainServiceRespondResult<bool>>
    {
        public string Email { get; set; }

        public string Password { get; set; }

    }


}