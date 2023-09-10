using AutoMapper;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.State.Command
{
    public record  UpdateState(int Id,VmState VmState):IRequest<VmState>;
    public class UpdateStateHandler : IRequestHandler<UpdateState, VmState>
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        public UpdateStateHandler(IStateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }


        public async Task<VmState> Handle(UpdateState request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Model.State>(request.VmState);
            return await _stateRepository.Update(request.Id, data);

        }
    }



}
