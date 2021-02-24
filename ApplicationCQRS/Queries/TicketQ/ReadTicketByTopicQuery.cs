using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Queries.TicketQ
{
    public class ReadTicketByTopicQuery : IRequest<IEnumerable<TicketDto>>
    {
        public long Topic { get; set; }
    }
}
