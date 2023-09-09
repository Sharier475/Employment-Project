using AutoMapper;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
namespace EmploymentProjectTeam02.Core.Department.Command;
public record UpdateDepartment(int Id, VmDepartment VmDepartment) : IRequest<VmDepartment>;
public class UpdateDepartmentHandler :IRequestHandler<UpdateDepartment, VmDepartment>
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;
    public UpdateDepartmentHandler(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper=mapper;
    }
 public async Task<VmDepartment> Handle(UpdateDepartment request, CancellationToken cancellationToken)=> await _departmentRepositpry.Update(request.Id, _mapper.Map<Model.Department>(request.VmDepartment));
    
}
