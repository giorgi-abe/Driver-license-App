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
    class ReadTopicByTopicHandler : IRequestHandler<ReadTopicByIdQuery, TopicDto>
    {
        private readonly IMapper _mapper = default;
        private readonly ITopicRepository _topicRepository = default;

        public ReadTopicByTopicHandler(ITopicRepository topicRepository, IMapper mapper)
        {
            _mapper = mapper;
            _topicRepository = topicRepository;
        }

        public async Task<TopicDto> Handle(ReadTopicByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _topicRepository.GetByIdAsync(request.TopicId);

            return _mapper.Map<TopicDto>(account);
        }
    }
}
