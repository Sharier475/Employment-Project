
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.City.Query;

public record GetCityById(int Id) : IRequest<VmCity>;

    public class GetCityByIdHandler : IRequestHandler<GetCityById, VmCity>
{
    private readonly ICityRepository _cityRepository;
    public GetCityByIdHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }
    public async Task<VmCity> Handle(GetCityById request, CancellationToken cancellationToken)
    {
        return await _cityRepository.GetById(request.Id);
    }
}
    
    

