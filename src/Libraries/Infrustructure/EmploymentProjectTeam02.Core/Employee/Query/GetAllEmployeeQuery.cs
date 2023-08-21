using AutoMapper;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.Employee.Query;

public record GetAllEmployeeQuery() : IRequest<IEnumerable<VmEmployee>>;
public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<VmEmployee>>
{
    private readonly IEmployeeRepository _EmployeeRepository;
    public GetAllEmployeeQueryHandler(IEmployeeRepository EmployeeRepository, IMapper mapper)
    {
        _EmployeeRepository = EmployeeRepository;
    }
    public async Task<IEnumerable<VmEmployee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        var result = await _EmployeeRepository.GetList();
        return result;
    }
}
