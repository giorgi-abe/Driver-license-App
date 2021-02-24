using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDtos
{
    public class TicketDto
    {
        public int Id { get; set; }

        public List<AnswerDto> Answers { get; set; }

        public string Coeficient { get; set; }

        public int CorrectAnswer { get; set; }

        public int Cutoff { get; set; }

        public string Desc { get; set; }

        public int FileParent { get; set; }

        public string Filename { get; set; }

        public int TicketId { get; set; }

        public string Question { get; set; }

        public string Timestamp { get; set; }

        public int Topic { get; set; }
    }
}
