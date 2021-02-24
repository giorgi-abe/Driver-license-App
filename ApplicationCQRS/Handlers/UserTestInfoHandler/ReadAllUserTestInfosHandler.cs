using ApplicationCQRS.Queries.UserTestInfoQ;
using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using ApplicationDtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCQRS.Handlers.UserTestInfoHandler
{
    public class ReadAllUserTestInfosHandler : IRequestHandler<ReadAllUserTestInfosQuery, IEnumerable<UserTestInfoDto>>
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<UserTestInfo> _repository = default;

        public ReadAllUserTestInfosHandler(IRepository<UserTestInfo> Repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = Repository;
        }

        public async Task<IEnumerable<UserTestInfoDto>> Handle(ReadAllUserTestInfosQuery request, CancellationToken cancellationToken)
        {
            var alltopics = await _repository.ReadAsync();

            return _mapper.Map<List<UserTestInfoDto>>(alltopics);
        }
    }
}
