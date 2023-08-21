using AutoMapper;
using EmploymentProjectTeam02.Core.City.Command;
using EmploymentProjectTeam02.Repositories.Base;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.Employee.Command;

public record CreateEmployee(VmEmployee VmEmployee) : IRequest<VmEmployee>;
public class CreateEmployeeHandler : IRequestHandler<CreateEmployee, VmEmployee>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public CreateEmployeeHandler(IEmployeeRepository employeeRepository,
                                 IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    public async Task<VmEmployee> Handle(CreateEmployee request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Model.Employee>(request.VmEmployee);
        return await _employeeRepository.Add(data);
    }
}

