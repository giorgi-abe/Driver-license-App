using ApplicationCQRS.Commands.UserC;
using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCQRS.Handlers.UserC
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<User> _repository = default;

        public UpdateUserHandler(IRepository<User> Repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = Repository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.Id, _mapper.Map<User>(request.User));

        }
    }
}
