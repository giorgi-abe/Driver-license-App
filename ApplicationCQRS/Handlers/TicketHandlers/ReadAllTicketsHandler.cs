using ApplicationCQRS.Queries.TicketQ;
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

namespace ApplicationCQRS.Handlers.TicketHandlers
{
    public class ReadAllTicketsHandler : IRequestHandler<ReadAllTicketsQuery, IEnumerable<TicketDto>>
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<Ticket> _repository = default;

        public ReadAllTicketsHandler(IRepository<Ticket> Repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = Repository;
        }

        public async Task<IEnumerable<TicketDto>> Handle(ReadAllTicketsQuery request, CancellationToken cancellationToken)
        {
            var alltopics = await  _repository.Get().Include("Answers").ToListAsync();

            return _mapper.Map<List<TicketDto>>(alltopics);
        }
    }
}
