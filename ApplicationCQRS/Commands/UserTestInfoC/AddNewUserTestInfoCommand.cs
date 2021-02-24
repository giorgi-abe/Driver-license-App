using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Commands.UserTestInfoC
{
    public class AddNewUserTestInfoCommand: IRequest<bool>
    {
        public UserTestInfoDto UserTestInfo { get; set; }
        public int UserId { get; set; }
    }
}
