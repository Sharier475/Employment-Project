﻿using AutoMapper;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentProjectTeam02.Core.Department.Query
{
    public record GetAllDepartmentQuery(): IRequest<IEnumerable<VmDepartment>>;
    public class GetAllDepartmentQueryHandler :
    IRequestHandler<GetAllDepartmentQuery,
    IEnumerable<VmDepartment>>
    {
        private readonly IDepartmentRepositpry _departmentRepositpry;
        public GetAllDepartmentQueryHandler(IDepartmentRepositpry departmentrepositpry, IMapper mapper)
        {
            _departmentRepositpry = departmentrepositpry;
        }
        public async Task<IEnumerable<VmDepartment>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var result = await _departmentRepositpry.GetList();
            return result;
        }
    }
}
