using ApplicationCQRS.Queries.TopicQ;
using ApplicationDomainCore.Abstraction;
using ApplicationDtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCQRS.Handlers.TopicHandlers
{
    public class ReadAllTopicsHandler : IRequestHandler<ReadAllTopicsQuery, IEnumerable<TopicDto>>
    {
        private readonly IMapper _mapper = default;
        private readonly ITopicRepository _topicRepository = default;

        public ReadAllTopicsHandler(ITopicRepository topicRepository, IMapper mapper)
        {
            _mapper = mapper;
            _topicRepository = topicRepository;
        }
        public async Task<IEnumerable<TopicDto>> Handle(ReadAllTopicsQuery request, CancellationToken cancellationToken)
        {
            var alltopics = await _topicRepository.ReadAsync();

            return _mapper.Map<List<TopicDto>>(alltopics);
        }
    }
}
