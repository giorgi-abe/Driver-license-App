using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDatabaseModels
{
    public class Ticket : BaseEntity
    { 
        public List<Answer> Answers { get; set; }

        public string Coeficient { get; set; }

        public long CorrectAnswer { get; set; }

        public long Cutoff { get; set; }

        public string Desc { get; set; }

        public long FileParent { get; set; }

        public string Filename { get; set; }

        public long TicketId { get; set; }

        public string Question { get; set; }

        public string Timestamp { get; set; }

        public long Topic { get; set; }
    }
}
