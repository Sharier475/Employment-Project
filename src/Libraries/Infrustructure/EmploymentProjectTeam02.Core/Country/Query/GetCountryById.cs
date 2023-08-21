using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.Country.Query;



public record GetCountryById(int Id):IRequest<VmCountry>;

public class GetCountryByIdHandler : IRequestHandler<GetCountryById, VmCountry>
{

    private readonly  ICountryRepository _countryRepository;

    public GetCountryByIdHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<VmCountry> Handle(GetCountryById request, CancellationToken cancellationToken)
    {
        return await _countryRepository.GetById(request.Id);
    }
}
