using AutoMapper;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.State.Query;

public record GetAllStateQuery() : IRequest< IEnumerable<VmState>>;
public class GetAllProductQueryHandler : IRequestHandler<GetAllStateQuery, IEnumerable<VmState>>

{
    private readonly IStateRepository _stateRepository;

    public GetAllProductQueryHandler(IStateRepository stateRepository)
    {
        _stateRepository = stateRepository;
    }

    public async Task<IEnumerable<VmState>> Handle(GetAllStateQuery request, CancellationToken cancellationToken)
    {
        var result = await _stateRepository.GetList(x=>x.Country);
        return result;

    }
}
