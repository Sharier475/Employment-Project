using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.Department.Command;

public record DeleteDepartment(int Id) : IRequest<VmDepartment>;
public class DeleteDepartmentHandler :
IRequestHandler<DeleteDepartment, VmDepartment>
{
    private readonly IDepartmentRepositpry _departmentRepositpry;
    public DeleteDepartmentHandler(IDepartmentRepositpry departmentRepositpry)
    {
        _departmentRepositpry = departmentRepositpry;
    }
    public async Task<VmDepartment> Handle(DeleteDepartment request, CancellationToken cancellationToken)
    {
        return await _departmentRepositpry.Delete(request.Id);
    }
}
