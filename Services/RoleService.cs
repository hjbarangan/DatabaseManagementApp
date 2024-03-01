using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


public class RoleService
{
    private readonly HttpClient _httpClient;

    public RoleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Role>> GetProductsAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:5281/api/roles");
        response.EnsureSuccessStatusCode();
        return await JsonSerializer.DeserializeAsync<List<Role>>(await response.Content.ReadAsStreamAsync());
    }

    // ... other methods for different API endpoints
}

  public class Role
  {
    public DateOnly Date { get; set; }
    public string? RoleName { get; set; }
    public string? RoleDescription { get; set; }


  }