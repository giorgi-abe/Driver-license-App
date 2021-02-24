using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Queries.UserTestInfoQ
{
    public class ReadUserTestInfosByUserIdQuery : IRequest<IEnumerable<UserTestInfoDto>>
    {
        public int UserId { get; set; }
    }
}
