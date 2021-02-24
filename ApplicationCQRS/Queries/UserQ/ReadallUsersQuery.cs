using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Queries.UserQ
{
    public class ReadallUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
