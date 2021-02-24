using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDtos
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? TicketId { get; set; }
        public TicketDto Ticket { get; set; }
    }
}
