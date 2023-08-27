using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.Department.Query;
public record GetDepartmentById(int Id): IRequest<VmDepartment>;
public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentById, VmDepartment>

{
    private readonly IDepartmentRepositpry _departmentRepositpry;
        public GetDepartmentByIdHandler(IDepartmentRepositpry departmentrepositpry)
    {
        _departmentRepositpry = departmentrepositpry;
    }

    public async Task<VmDepartment> Handle(GetDepartmentById request, CancellationToken cancellationToken)
    {
        return await _departmentRepositpry.GetById(request.Id);
    }
}
