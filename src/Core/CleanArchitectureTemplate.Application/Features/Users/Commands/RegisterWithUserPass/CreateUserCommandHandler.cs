using AppSimcard.Security.RolesConst;
using AutoMapper;
using CleanArchitectureTemplate.Domain.DomainServiceResult;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Identity;
using CleanArchitectureTemplate.Domain.Repositories;
using CleanArchitectureTemplate.Shared.Security.Hashing;
using CleanArchitectureTemplate.Shared.Utilities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace CleanArchitectureTemplate.Application.Features.Users.Commands.RegisterWithUserPass
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IDomainServiceRespondResult<bool>>
    {
        private readonly IRoleRepositoryAsync _roleRepository;
        private readonly IUserRoleRepositoryAsync _userRoleRepository;
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;

        public CreateUserCommandHandler(
            ICurrentUser currentUser,
            IUserRepositoryAsync userRepository,
            IUserRoleRepositoryAsync userRoleRepository,
            IRoleRepositoryAsync roleRepository,
            IMapper mapper
            )
        {
            _currentUser = currentUser;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IDomainServiceRespondResult<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new DomainServiceRespondResult<bool>();

            var isExist = await _userRepository.ExistUser(request.Email);
            if (isExist)
            {
                result.SetResult(false, ResultStatus.NotValid, Messages.NotExist);
                return result;
            }

            bool isValidUser = EmailValidation.IsValid(request.Email);
            bool isValidPass = PasswordValidation.IsValid(request.Password);

            if (!isValidUser)
            {
                result.SetResult(false, ResultStatus.NotValid, Messages.NoValidEmail);
                return result;
            }

            if (!isValidPass)
            {
                result.SetResult(false, ResultStatus.NotValid, Messages.NoValidPass);
                return result;
            }

            var role = _roleRepository.GetRoleByName(ApplicationRoles.ApplicationUserRole).Result;
            var userId = Guid.NewGuid().ToString();

            var userRole = new UserRole()
            {
                UserId = userId,
                RoleId = role.Id
            };

            var user = new User()
            {
                Id = userId,
                Username = request.Email,
                Email = request.Email,
                HashPasscode = SalterHashing.PasswordGenerator(request.Password),
                IsActive = false,
                ActiveCode = new Random().Next(100000, 999999).ToString(),
                ExpireActiveCode = DateTime.Now.AddMinutes(1000),
            };

            var isSuccess = await _userRepository.Register(user);

            if (isSuccess)
            {
                // send email or sms
                //var url = "با کلیک بروی لینک زیر ایمیل شما تایید خواهند شد" + "\n" +
                //     ConfigSource.Site + "activation-code?userId=" + user.Id + "&activeCode=" + activeCode + "";

                //await SendEmailService.SendEmail(dto.Email, "تایید ایمیل ثبت نام ستاره سیم", url);
                await _userRoleRepository.AddAsync(userRole);

                result.SetResult(true, ResultStatus.Success, Messages.Ok);
            }
            else
            {
                result.SetResult(false, ResultStatus.Error, Messages.Error);
            }
            return result;
        }

    }
}
