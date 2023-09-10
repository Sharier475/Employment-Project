using EmploymentProjectTeam02.Common;
using EmploymentProjectTeam02.Models;
using EmploymentProjectTeam02.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EmploymentProjectTeam02.Service;

public class DepartmentRepository : Repository<Department>,IDepartmentRepository
{
    private readonly HttpClient _httpClient;
    public DepartmentRepository(IHttpClientFactory httpClientFactory, string endpoint= "Department") : base(httpClientFactory, endpoint)
    {
        _httpClient = httpClientFactory.CreateClient("EmployeeApi");
    }
    public async Task<IEnumerable<SelectListItem>> Dropdown()
    {
        using (var countryresponse = await _httpClient.GetAsync("Department"))
        {
            countryresponse.EnsureSuccessStatusCode();
            var jsonContent = await countryresponse.Content.ReadAsStringAsync();
            var dapartmentList = JsonConvert.DeserializeObject<List<Department>>(jsonContent);
            var selectListItems = dapartmentList.Select(department => new SelectListItem
            {
                Value = department.Id.ToString(), Text = department.DepartmentName
            }).ToList();

            return selectListItems;
        }
    }
}
