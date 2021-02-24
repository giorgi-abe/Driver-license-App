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
    public class DeletUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<User> _repository = default;

        public DeletUserHandler(IRepository<User> Repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = Repository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.UserId);
        }
    }
}
