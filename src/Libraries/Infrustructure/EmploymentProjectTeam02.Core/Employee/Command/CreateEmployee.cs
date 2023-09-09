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
    private readonly IWebHostEnvironment _webHostEnvironment;
    public CreateEmployeeHandler(IEmployeeRepository employeeRepository,
                                 IMapper mapper,IWebHostEnvironment webHostEnvironment)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _webHostEnvironment = webHostEnvironment;
    }
    public async Task<VmEmployee> Handle(CreateEmployee request, CancellationToken cancellationToken)
    {

        if (request.VmEmployee.PictureFile?.Length > 0)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "wwroot/images/profiles");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + request.VmEmployee.PictureFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create, access: FileAccess.ReadWrite))
            {
                var file = request.VmEmployee.PictureFile.OpenReadStream();
                await file.CopyToAsync(fileStream, cancellationToken);
            }
            request.VmEmployee.Picture = uniqueFileName;
        }

        return await _employeeRepository.Add(_mapper.Map<Model.Employee>(request.VmEmployee));
    }
}

