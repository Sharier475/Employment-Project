using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.State.Command
{
    public record DeleteState(int Id): IRequest<VmState>;
    public class DeleteStateHandler : IRequestHandler<DeleteState, VmState>
    {
        private readonly IStateRepository _stateRepository;
        public DeleteStateHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public async Task<VmState> Handle(DeleteState request, CancellationToken cancellationToken)
        {
            return await _stateRepository.Delete(request.Id);
        }

    
       
    }
}

