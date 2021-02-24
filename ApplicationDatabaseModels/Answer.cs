using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationDatabaseModels
{
    public class Answer:BaseEntity
    {
        public string Text { get; set; }
        public int? TicketId { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
    }
}
