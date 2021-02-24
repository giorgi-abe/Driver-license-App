using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Queries.UserTestInfoQ
{
    public class ReadAllUserTestInfosQuery : IRequest<IEnumerable<UserTestInfoDto>>
    {
    }
}
