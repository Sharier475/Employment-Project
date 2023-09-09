using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
namespace EmploymentProjectTeam02.Core.Department.Command
{
    public record DeleteDepartment(int Id) : IRequest<VmDepartment>;
    public class DeleteDepartmentHandler :
    IRequestHandler<DeleteDepartment, VmDepartment>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DeleteDepartmentHandler(IDepartmentRepository departmentRepository)=>_departmentRepository = departmentRepository;
        public async Task<VmDepartment> Handle(DeleteDepartment request, CancellationToken cancellationToken)=> await _departmentRepository.Delete(request.Id);
        
    }
}
