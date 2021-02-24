using ApplicationCQRS.Queries.TicketQ;
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

namespace ApplicationCQRS.Handlers.TicketHandlers
{
    public class ReadTicketByTopicHandler : IRequestHandler<ReadTicketByTopicQuery, IEnumerable<TicketDto>>
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<Ticket> _repository = default;

        public ReadTicketByTopicHandler(IRepository<Ticket> Repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = Repository;
        }
        public async Task<IEnumerable<TicketDto>> Handle(ReadTicketByTopicQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.Get().Include("Answers").ToListAsync();
            var data = ticket.Where(o => o.Topic == request.Topic).ToList();
            return _mapper.Map<IEnumerable<TicketDto>>(data);
        }
    }
}
