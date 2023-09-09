using AutoMapper;
using EmploymentProjectTeam02.Core.City.Command;
using EmploymentProjectTeam02.Repositories.Base;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
using Microsoft.AspNetCore.Hosting;

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

        return await _employeeRepository.Add(_mapper.Map<Model.Employee>(request.VmEmployee));
    }
}

