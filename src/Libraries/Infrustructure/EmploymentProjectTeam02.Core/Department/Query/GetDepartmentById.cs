using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.Department.Query;

public record GetDepartmentById(int Id): IRequest<VmDepartment>;
public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentById, VmDepartment>

{
    private readonly IDepartmentRepository _departmentRepository;
    public GetDepartmentByIdHandler(IDepartmentRepository departmentRepository)=>_departmentRepository = departmentRepository;
    public async Task<VmDepartment> Handle(GetDepartmentById request, CancellationToken cancellationToken)=> await _departmentRepository.GetById(request.Id);
    
}
