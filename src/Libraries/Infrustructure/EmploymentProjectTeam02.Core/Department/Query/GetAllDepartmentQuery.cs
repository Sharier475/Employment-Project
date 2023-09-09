using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
namespace EmploymentProjectTeam02.Core.Department.Query;
public record GetAllDepartmentQuery(): IRequest<IEnumerable<VmDepartment>>;
public class GetAllDepartmentQueryHandler :
IRequestHandler<GetAllDepartmentQuery,
IEnumerable<VmDepartment>>
{
    private readonly IDepartmentRepository _departmentRepository;
    public GetAllDepartmentQueryHandler(IDepartmentRepository departmentRepository)=>_departmentRepository = departmentRepository;
    public async Task<IEnumerable<VmDepartment>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)=> await _departmentRepository.GetList();
    
}
