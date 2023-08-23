using AutoMapper;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.City.Query;

public record GetAllCityQuery() : IRequest<IEnumerable<VmCity>>;
public class GetAllCityQueryHandler : IRequestHandler<GetAllCityQuery, IEnumerable<VmCity>>
{
    private readonly ICityRepository _CityRepository;
    public GetAllCityQueryHandler(ICityRepository CityRepository, IMapper mapper)
    {
        _CityRepository = CityRepository;
    }
    public async Task<IEnumerable<VmCity>> Handle(GetAllCityQuery request, CancellationToken cancellationToken)
    {
        var result = await _CityRepository.GetList(x=>x.State);
        return result;
    }
}
