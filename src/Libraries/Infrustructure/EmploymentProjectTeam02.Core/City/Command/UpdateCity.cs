using AutoMapper;
using EmploymentProjectTeam02.Repositories.Base;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.City.Command;

public record UpdateCity(int Id, VmCity VmCity) : IRequest<VmCity>;
public class UpdateCityHandler : IRequestHandler<UpdateCity, VmCity>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;
    public UpdateCityHandler(ICityRepository cityRepository,
                                 IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }
    public async Task<VmCity> Handle(UpdateCity request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Model.City>(request.VmCity);
        return await _cityRepository.Update(request.Id,data);
    }
}

