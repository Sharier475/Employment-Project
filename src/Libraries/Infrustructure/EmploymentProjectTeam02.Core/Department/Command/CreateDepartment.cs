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
    public record CreateDepartment(VmDepartment VmDepartment) :
       IRequest<VmDepartment>;
    public class CrateDepartmentHandler :
    IRequestHandler<CreateDepartment, VmDepartment>
    {
        private readonly IDepartmentRepositpry _departmentRepositpry;
        private readonly IMapper _mapper;

        public CrateDepartmentHandler (IDepartmentRepositpry departmentRepositpry, IMapper mapper)
        {
            _departmentRepositpry = departmentRepositpry;
            _mapper = mapper;
        }

        public async Task<VmDepartment> Handle(CreateDepartment request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Model.Department>(request.VmDepartment);
            return await _departmentRepositpry.Add(data);
        }
    }
}
