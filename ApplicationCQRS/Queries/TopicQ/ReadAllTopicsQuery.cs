using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Queries.TopicQ
{
    public class ReadAllTopicsQuery:IRequest<IEnumerable<TopicDto>>
    {
    }
}
