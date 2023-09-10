using EmploymentProjectTeam02.Common;
using EmploymentProjectTeam02.Models;
using EmploymentProjectTeam02.Service.Interface;
using System.Net.Http.Headers;

namespace EmploymentProjectTeam02.Service;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    private readonly HttpClient _httpClient;
    public EmployeeRepository(IHttpClientFactory httpClientFactory, string endpoint = "Employee") : base(httpClientFactory, endpoint)
    {
        _httpClient = httpClientFactory.CreateClient("EmployeeApi");
    }

    //public async void Create(Employee employee)
    //{
    //    var content = new MultipartFormDataContent
    //    {
    //        {
    //            new StreamContent(employee.PictureFile.OpenReadStream())
    //            {
    //                Headers ={
    //                        ContentLength= employee.PictureFile.Length,
    //                        ContentType=new MediaTypeHeaderValue(employee.PictureFile.ContentType)

    //                    }
    //            },
    //            "PictureFile",
    //            employee.PictureFile.FileName
    //        },
    //        { new StringContent(employee.Name), "Name" },
    //        { new StringContent(employee.Gender), "Gender" },
    //        { new StringContent(employee.Address), "Address" },
    //        { new StringContent(employee.JoiningDate.ToString()), "JoiningDate" },
    //        { new StringContent(employee.DepartmentId.ToString()), "DepartmentId" },
    //        { new StringContent(employee.CountryId.ToString()), "CountryId" },
    //        { new StringContent(employee.CityId.ToString()), "CityId" },
    //        { new StringContent(employee.StateId.ToString()), "StateId" },
    //        { new StringContent(employee.Bsc.ToString()), "Bsc" },
    //        { new StringContent(employee.Hsc.ToString()), "Hsc" },
    //        { new StringContent(employee.Ssc.ToString()), "Ssc" },
    //        { new StringContent(employee.Msc.ToString()), "Msc" }
    //    };
    //    await _httpClient.PostAsync("Employee", content);

    //}

    public async void Create(Employee employee)
    {
        var content = new MultipartFormDataContent {
        {
            new StreamContent(employee.PictureFile.OpenReadStream())
            {
                Headers ={
                    ContentLength= employee.PictureFile.Length,
                    ContentType=new MediaTypeHeaderValue(employee.PictureFile.ContentType)
                }
            },
                "PictureFile", employee.PictureFile.FileName 
        }};
        string[] fields = { "Name", "Gender", "Address", "JoiningDate", "DepartmentId", "CountryId", "CityId", "StateId", "Bsc", "Hsc", "Ssc", "Msc" };
        foreach (string field in fields)
        {
            content.Add(new StringContent(employee.GetType().GetProperty(field).GetValue(employee, null).ToString()), field);
        }
       await _httpClient.PostAsync("Employee", content);
    }

}
