using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.State.Query;

public record GetStateById (int Id) : IRequest<VmState>
{
    public class GetStateByIdHandler : IRequestHandler<GetStateById, VmState>
    {
        private readonly IStateRepository _stateRepository;
        public GetStateByIdHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<VmState> Handle(GetStateById request, CancellationToken cancellationToken)
        {
            return await _stateRepository.GetById(request.Id);
        }
    }
}
    