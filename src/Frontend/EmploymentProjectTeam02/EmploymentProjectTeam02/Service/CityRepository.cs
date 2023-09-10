using EmploymentProjectTeam02.Common;
using EmploymentProjectTeam02.Models;
using EmploymentProjectTeam02.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EmploymentProjectTeam02.Service;

public class CityRepository : Repository<City>, ICityRepository
{
    private readonly HttpClient _httpClient;
    public CityRepository(IHttpClientFactory httpClientFactory, string endpoint="City") : base(httpClientFactory, endpoint)
    {
        _httpClient = httpClientFactory.CreateClient("EmployeeApi");
    }

    public async Task<IEnumerable<SelectListItem>> Dropdown()
    {
        using (var countryresponse = await _httpClient.GetAsync("City"))
        {
            countryresponse.EnsureSuccessStatusCode();
            var selectListItems=JsonConvert.DeserializeObject<List<City>>(await countryresponse.Content.ReadAsStringAsync()).Select(city => new SelectListItem
            {
                Value = city.Id.ToString(), Text = city.CityName
            }).ToList();
            return selectListItems;
        }
    }
}
