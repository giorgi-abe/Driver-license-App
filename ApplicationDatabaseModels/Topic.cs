using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDatabaseModels
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Key]
        public int TopicId { get; set; }
    }
}
