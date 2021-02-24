using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDtos
{
    public class pathTickets
    {
        public int Id { get; set; }
        [JsonProperty("answers")]
        public string Answers { get; set; }

        public List<string> SplitedAnswers { get; set; } = new List<string>();

        [JsonProperty("coeficient")]
        public string Coeficient { get; set; }

        [JsonProperty("correct_answer")]
        public long CorrectAnswer { get; set; }

        [JsonProperty("cutoff")]
        public long Cutoff { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("file_parent")]
        public long FileParent { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("id")]
        public long TicketId { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("topic")]
        public long Topic { get; set; }
    }
}
