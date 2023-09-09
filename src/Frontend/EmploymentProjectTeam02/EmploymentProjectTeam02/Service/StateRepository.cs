using EmploymentProjectTeam02.Common;
using EmploymentProjectTeam02.Models;
using EmploymentProjectTeam02.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EmploymentProjectTeam02.Service;

public class StateRepository : Repository<State>, IStateRepository
{
    private readonly HttpClient _httpClient;
    public StateRepository(IHttpClientFactory httpClientFactory, string endpoint="State") : base(httpClientFactory, endpoint)
    {
        _httpClient = httpClientFactory.CreateClient("EmployeeApi");
    }
    public async Task<IEnumerable<SelectListItem>> Dropdown()
    {
        using (var countryresponse = await _httpClient.GetAsync("State"))
        {
            countryresponse.EnsureSuccessStatusCode();
            var jsonContent = await countryresponse.Content.ReadAsStringAsync();
            var stateList = JsonConvert.DeserializeObject<List<State>>(jsonContent);
            var selectListItems = stateList.Select(state => new SelectListItem
            {
                Value = state.Id.ToString(),Text = state.StateName
            }).ToList();
            return selectListItems;
        }
    }
}
