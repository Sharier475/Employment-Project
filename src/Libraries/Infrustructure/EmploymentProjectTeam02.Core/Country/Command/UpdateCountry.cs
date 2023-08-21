using AutoMapper;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.Country.Command;


public record UpdateCountry(int Id,VmCountry VmCountry):IRequest<VmCountry>;
public class UpdateCountryHandler : IRequestHandler<UpdateCountry, VmCountry>
{

    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public UpdateCountryHandler(ICountryRepository countryRepository,IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }
    public async Task<VmCountry> Handle(UpdateCountry request, CancellationToken cancellationToken)
    {
        var data=_mapper.Map<Model.Country>(request.VmCountry);
       return await _countryRepository.Update(request.Id,data); 
    }
}
