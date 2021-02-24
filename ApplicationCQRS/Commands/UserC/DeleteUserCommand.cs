using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Commands.UserC
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int UserId { get; set; }
    }
}
