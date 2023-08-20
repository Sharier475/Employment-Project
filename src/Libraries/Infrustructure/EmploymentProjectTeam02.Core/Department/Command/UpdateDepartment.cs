using AutoMapper;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentProjectTeam02.Core.Department.Command
{
    public record UpdateDepartment(int Id, VmDepartment
VmDepartment) : IRequest<VmDepartment>;
    public class UpdateDepartmentHandler :
    IRequestHandler<UpdateDepartment, VmDepartment>
    {
        private readonly IDepartmentRepositpry _departmentRepositpry;
        private readonly IMapper _mapper;

        public UpdateDepartmentHandler(IDepartmentRepositpry departmentRepositpry, IMapper mapper)
        {
            _departmentRepositpry = departmentRepositpry;
            _mapper=mapper;
        }

     public async Task<VmDepartment> Handle(UpdateDepartment request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Model.Department>(request.VmDepartment);
            return await _departmentRepositpry.Update(request.Id, data);
        }
    }
}
