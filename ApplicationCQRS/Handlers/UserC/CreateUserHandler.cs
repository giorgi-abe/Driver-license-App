using ApplicationCQRS.Commands.UserC;
using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCQRS.Handlers.UserC
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<User> _repository = default;

        public CreateUserHandler(IRepository<User> Repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = Repository;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var account = new User()
            {
                Name = request.Name,
                Surname = request.Surname,
                UserName = request.UserName,
                Password = request.Password,
                TestNumbers = request.TestNumbers,
                Infos = request.Infos?.Select(o => new UserTestInfo()
                {
                    CorrectAnswersNumber = o.CorrectAnswersNumber,
                    Date = o.Date
                })?.ToList()
            };
            account.WrongCounter = 3;
            return await _repository.CreateAsync(account);
        }
    }
}
