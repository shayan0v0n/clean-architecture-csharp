using AutoMapper;
using CleanArchitectureTemplate.Domain.DomainServiceResult;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Identity;
using CleanArchitectureTemplate.Domain.Repositories;
using CleanArchitectureTemplate.Shared.Security.Hashing;
using CleanArchitectureTemplate.Shared.Security.JwtToken;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanTemplate.Application.Users.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<GetProductQuery, IDomainServiceRespondResult<string>>
    {
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;
        //private readonly UserManager<User> _userManager;

        public LoginCommandHandler(
            ICurrentUser currentUser, IUserRepositoryAsync userRepository, IMapper mapper)
        {
            _currentUser = currentUser;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IDomainServiceRespondResult<string>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            var result = new DomainServiceRespondResult<string>();
            var user = await _userRepository.Authentication(request.Username, SalterHashing.PasswordGenerator(request.Password));
            if (user != null)
            {
                if (user.IsActive)
                {
                    var token = Token.GenerateToken(user);
                    user.LastLoginDate = DateTime.Now;
                    await _userRepository.UpdateAsync(user);
                    result.SetResult(token, ResultStatus.Success, Messages.Ok);
                }
                else
                {
                    var random = new Random();
                    var activeCode = random.Next(100000, 999999);
                    user.ActiveCode = activeCode.ToString();
                    user.ExpireActiveCode = DateTime.Now.AddMinutes(10);
                    await _userRepository.UpdateAsync(user);

                    //var url = "با کلیک بروی لینک زیر ایمیل شما تایید خواهند شد" + "\n" + "\n" +
                    //ConfigSource.Site + "activation-code?userId=" + user.Id + "&activeCode=" + activeCode + "";

                    //await SendEmailService.SendEmail(dto.Email, "اعتبارسنجی ایمیل شرکت تست", url);
                    result.SetResult("", ResultStatus.WaitConfirmEmail, Messages.WaitConfirmEmail);
                }
            }
            else
            {
                result.SetResult(ResultStatus.NotFound, Messages.NotExist);
            }

            return result;

        }

    }
}
