using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Queries.TicketQ
{
    public class GetCorrectAnswerQuery : IRequest<Tuple<bool,int>>
    {
        public int QuetionId { get; set; }
        public int Answer { get; set; }
        public int UserId { get; set; }
    }
}
