using AutoMapper;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
namespace EmploymentProjectTeam02.Core.Employee.Command;
public record UpdateEmployee(int Id, VmEmployee VmEmployee) : IRequest<VmEmployee>;
public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployee, VmEmployee>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public UpdateEmployeeHandler(IEmployeeRepository employeeRepository,
                                 IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    public async Task<VmEmployee> Handle(UpdateEmployee request, CancellationToken cancellationToken)
    {

        if (request.VmEmployee.PictureFile?.Length > 0)
        {
            if (request.VmEmployee.PictureFile != null && request.VmEmployee.PictureFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/profiles", request.VmEmployee.PictureFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    request.VmEmployee.PictureFile.CopyTo(stream);
                }
                request.VmEmployee.Picture = $"{request.VmEmployee.PictureFile.FileName}";
            }
        }

        return await _employeeRepository.Update(request.Id, _mapper.Map<Model.Employee>(request.VmEmployee));
    }
}
