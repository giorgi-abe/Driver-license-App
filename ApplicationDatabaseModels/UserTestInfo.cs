using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationDatabaseModels
{
    public class UserTestInfo : BaseEntity
    {
        public int CorrectAnswersNumber { get; set; }
        public DateTime Date { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
