using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Queries.TicketQ
{
    public class ReadAllTicketsQuery : IRequest<IEnumerable<TicketDto>>
    {
    }
}
