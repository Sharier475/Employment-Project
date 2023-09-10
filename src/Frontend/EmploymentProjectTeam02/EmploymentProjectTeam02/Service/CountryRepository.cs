using EmploymentProjectTeam02.Common;
using EmploymentProjectTeam02.Models;
using EmploymentProjectTeam02.Service.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EmploymentProjectTeam02.Service;
public class CountryRepository : Repository<Country>, ICountryRepository
{
    private readonly HttpClient _httpClient;
    public CountryRepository(IHttpClientFactory httpClientFactory, string endpoint="Country") : base(httpClientFactory, endpoint)
    {
        _httpClient = httpClientFactory.CreateClient("EmployeeApi");
    }
    public async Task<IEnumerable<SelectListItem>> Dropdown()
    {
     
            using (var countryresponse = await _httpClient.GetAsync("Country"))
            {
                countryresponse.EnsureSuccessStatusCode();
                var jsonContent = await countryresponse.Content.ReadAsStringAsync();
                var countryList = JsonConvert.DeserializeObject<List<Country>>(jsonContent);
                var selectListItems = countryList.Select(country => new SelectListItem
                {
                    Value = country.Id.ToString(),Text = country.CountryName
                }).ToList();

                return selectListItems;
            }
    }
}

