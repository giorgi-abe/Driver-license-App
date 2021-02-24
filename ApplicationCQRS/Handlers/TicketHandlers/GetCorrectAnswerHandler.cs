using ApplicationCQRS.Queries.TicketQ;
using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCQRS.Handlers.TicketHandlers
{
    public class GetCorrectAnswerHandler : IRequestHandler<GetCorrectAnswerQuery, Tuple<bool,int>>
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<Ticket> _repository = default;
        private readonly IRepository<User> _userRepository = default;

        public GetCorrectAnswerHandler(IRepository<Ticket> Repository, IRepository<User> userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _repository = Repository;
        }
        public async Task<Tuple<bool, int>> Handle(GetCorrectAnswerQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.ReadByIdAsync(request.UserId);

            var data = await _repository.ReadByIdAsync(request.QuetionId);
            var obj = data.CorrectAnswer == request.Answer;
            if(!obj)
            {
                user.WrongCounter -= 1;
                if (user.WrongCounter == 0)
                {
                    user.WrongCounter = 3;
                    await _userRepository.UpdateAsync(request.UserId, user);
                    throw new Exception("You lost");
                }
                await _userRepository.UpdateAsync(request.UserId, user);
            }
            return new Tuple<bool, int>(obj,Convert.ToInt32(data.CorrectAnswer));
        }
    }
}
