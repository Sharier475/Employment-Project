using AutoMapper;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.State.Command
{
    public  record CreateState(VmState VmState) : IRequest<VmState>;
    public class CreateStateHandler : IRequestHandler<CreateState, VmState>
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        public CreateStateHandler(IStateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }


        public async Task<VmState> Handle(CreateState request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Model.State>(request.VmState);
            return await _stateRepository.Add(data);

        }
    }
}
