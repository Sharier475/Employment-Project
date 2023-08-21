using AutoMapper;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.City.Command;

public record CreateCity(VmCity VmCity) : IRequest<VmCity>;
public class CreateCityHandler : IRequestHandler<CreateCity, VmCity>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;
    public CreateCityHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }
    public async Task<VmCity> Handle(CreateCity request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Model.City>(request.VmCity);
        return await _cityRepository.Add(data);
    }
}
