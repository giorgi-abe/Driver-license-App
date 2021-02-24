using ApplicationCQRS.Queries.UserQ;
using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using ApplicationDtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCQRS.Handlers.UserC
{
    public class ReadUserByIdHandler : IRequestHandler<ReadUserByIdQuery, UserDto>
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<User> _repository = default;

        public ReadUserByIdHandler(IRepository<User> Repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = Repository;
        }

        public async Task<UserDto> Handle(ReadUserByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.Get().Include("Infos").FirstOrDefaultAsync(o => o.Id == request.UserId);

            return _mapper.Map<UserDto>(data);
        }
    }
}
