using EmploymentProjectTeam02.Repositories.Base;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.Employee.Query;


public record GetEmployeeById(int Id) : IRequest<VmEmployee>;

public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeById, VmEmployee>
{
    private readonly IEmployeeRepository _employeeRepository;
    public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public async Task<VmEmployee> Handle(GetEmployeeById request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetById(request.Id);
    }
}

