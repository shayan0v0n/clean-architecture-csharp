using AutoMapper;
using CleanArchitectureTemplate.Domain.DomainServiceResult;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Identity;
using CleanArchitectureTemplate.Domain.Repositories;
using CleanArchitectureTemplate.Shared.Security.Hashing;
using CleanArchitectureTemplate.Shared.Security.JwtToken;
using CleanTemplate.Application.Users.Command.Login;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanTemplate.Application.Products.Queries
{
    public class GetProductsHandler : IRequestHandler<GetProductQuery, IDomainServiceRespondResult<string>>
    {
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _currentUser;
        //private readonly UserManager<User> _userManager;

        public GetProductsHandler(
            IUserContext currentUser, IUserRepositoryAsync userRepository, IMapper mapper)
        {
            _currentUser = currentUser;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IDomainServiceRespondResult<string>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            var userId = _currentUser.Id;
            var result = new DomainServiceRespondResult<string>();
            result.SetResult("", ResultStatus.Error, Messages.Error);        
            return result; ;


        }

    }
}
