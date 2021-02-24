using ApplicationCQRS.Queries.UserQ;
using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using ApplicationDtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCQRS.Handlers.UserC
{
    public class ReadallUsersHandler : IRequestHandler<ReadallUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<User> _repository = default;

        public ReadallUsersHandler(IRepository<User> Repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = Repository;
        }

        public async Task<IEnumerable<UserDto>> Handle(ReadallUsersQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.Get().Include("Infos").ToListAsync();

/*            var data = alltopics.Select(o => new UserDto()
            {
                Id = o.Id,
                Name = o.Name,
                Surname = o.Surname,
                UserName = o.UserName,
                Password = o.Password,
                TestNumbers = o.TestNumbers,
                Infos = o.Infos?.Select(a => new UserTestInfoDto()
                {
                    Id = a.Id,
                    CorrectAnswersNumber = a.CorrectAnswersNumber,
                    Date = a.Date
                })?.ToList()
            });*/
            return _mapper.Map<IEnumerable<UserDto>>(data);
        }
    }
}
