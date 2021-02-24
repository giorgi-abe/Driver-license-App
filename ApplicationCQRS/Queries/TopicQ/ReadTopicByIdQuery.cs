using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Queries.TopicQ
{
    public class ReadTopicByIdQuery : IRequest<TopicDto>
    {
        public int TopicId { get; set; }
    }
}
