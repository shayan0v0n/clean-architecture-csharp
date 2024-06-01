using CleanArchitectureTemplate.Domain.DomainServiceResult;
using CleanArchitectureTemplate.Domain.Entities;
using MediatR;

namespace CleanTemplate.Application.Products.Queries
{
    public class GetProductQuery : IRequest<IDomainServiceRespondResult<string>>
    {
        public string Username { get; set; }

        public string Password { get; set; }

    }
}
