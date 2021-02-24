using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int TestNumbers { get; set; }
        public List<UserTestInfoDto> Infos { get; set; }
    }
}
