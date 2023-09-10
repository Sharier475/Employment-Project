using EmploymentProjectTeam02.Common.Base;

namespace EmploymentProjectTeam02.Common;

public class Repository<TEntity>  : IRepository<TEntity> where TEntity : class
{
    private readonly HttpClient _httpClient;
    private readonly string _endpoint;

    public Repository(IHttpClientFactory httpClientFactory, string endpoint)
    {
        _httpClient = httpClientFactory.CreateClient("EmployeeApi");
        _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
    }
    public async Task<TEntity> GetById(int id)
    {
        var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
        return await response.Content.ReadFromJsonAsync<TEntity>();
    }
    public async Task<IEnumerable<TEntity>> GetAll()
    {
        var response = await _httpClient.GetAsync(_endpoint);
        return await response.Content.ReadFromJsonAsync<IEnumerable<TEntity>>();
    }
    public async Task Insert(TEntity entity)=> await _httpClient.PostAsJsonAsync(_endpoint, entity);
    public async Task Update(int id, TEntity entity)=> await _httpClient.PutAsJsonAsync($"{_endpoint}/{id}", entity);
       
    public async Task<TEntity> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
        if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<TEntity>();
        else throw new Exception($"Failed to delete entity with ID {id}. Status code: {response.StatusCode}");
    }
}
