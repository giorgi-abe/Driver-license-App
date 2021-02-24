using ApplicationCQRS.Commands.UserTestInfoC;
using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCQRS.Handlers.UserTestInfoHandler
{
    public class AddNewUserTestInfoHandler : IRequestHandler<AddNewUserTestInfoCommand, bool>
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<UserTestInfo> _repository = default;

        public AddNewUserTestInfoHandler(IRepository<UserTestInfo> Repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = Repository;
        }

        public async Task<bool> Handle(AddNewUserTestInfoCommand request, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<UserTestInfo>(request.UserTestInfo);
            account.UserId = request.UserId;
            return await _repository.CreateAsync(account);
        }
    }
}
