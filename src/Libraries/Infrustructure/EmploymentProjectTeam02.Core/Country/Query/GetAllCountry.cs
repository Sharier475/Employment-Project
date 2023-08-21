using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.Country.Query;


public record GetAllCountry():IRequest<IEnumerable<VmCountry>>;
public class GetAllCountryHandler : IRequestHandler<GetAllCountry, IEnumerable<VmCountry>>
{
    private readonly ICountryRepository _countryRepository;
    public GetAllCountryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<IEnumerable<VmCountry>> Handle(GetAllCountry request, CancellationToken cancellationToken)
    {
        var result = await _countryRepository.GetList();
        return result;
    }
}

