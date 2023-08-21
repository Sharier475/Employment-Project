using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.Country.Command;


public record DeleteCountry(int id):IRequest<VmCountry>;
public class DeleteCountryHandler:IRequestHandler<DeleteCountry, VmCountry>
{
    private readonly ICountryRepository _countryRepository;
    public DeleteCountryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<VmCountry> Handle(DeleteCountry request, CancellationToken cancellationToken)
    {
        return await _countryRepository.Delete(request.id);
    }
}
