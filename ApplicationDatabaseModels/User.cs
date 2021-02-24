using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDatabaseModels
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int WrongCounter { get; set; }
        public int TestNumbers { get; set; }
        public List<UserTestInfo> Infos { get; set; }
    }
}
