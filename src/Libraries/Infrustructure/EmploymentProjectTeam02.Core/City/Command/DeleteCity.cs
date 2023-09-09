using AutoMapper;
using EmploymentProjectTeam02.Repositories.Interface;
using EmploymentProjectTeam02.Services.Model;
using MediatR;

namespace EmploymentProjectTeam02.Core.City.Command;

public record DeleteCity(int Id) : IRequest<VmCity>;
public class DeleteCityHandler : IRequestHandler<DeleteCity, VmCity>
{
    private readonly ICityRepository _cityRepository;
    public DeleteCityHandler(ICityRepository cityRepository)=>_cityRepository = cityRepository;
    public async Task<VmCity> Handle(DeleteCity request, CancellationToken cancellationToken)=> await _cityRepository.Delete(request.Id);
    
}

