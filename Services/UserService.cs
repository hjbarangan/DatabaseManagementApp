using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DatabaseManagementApp.Models; // Assuming YourBlazorApp.Models contains the User model

namespace DatabaseManagementApp.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5077/";

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    public async Task<List<UserModel>> GetUsers()
{
    try
    {
        // Make HTTP GET request to the API endpoint to fetch users
        var response = await _httpClient.GetFromJsonAsync<List<UserModel>>($"{BaseUrl}api/DatabaseManager/check-postgres");
        return response!;
    }
    catch (Exception ex)
    {
        // Handle any errors, log them, etc.
        Console.WriteLine($"Error fetching users: {ex.Message}");
        throw; // Rethrow the exception to be handled by the caller
    }
}


        public async Task CreateUser(UserModel user)
        {
            try
            {
                // Make HTTP POST request to the API endpoint to create a new user
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}api/users", user);

                response.EnsureSuccessStatusCode(); // Throw an exception if the response status code indicates an error
            }
            catch (Exception ex)
            {
                // Handle any errors, log them, etc.
                Console.WriteLine($"Error creating user: {ex.Message}");
                throw; // Rethrow the exception to be handled by the caller
            }
        }

        // public async Task UpdateUser(UserModel user)
        // {
        //     try
        //     {
        //         // Make HTTP PUT request to the API endpoint to update an existing user
        //         var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}api/users/{user.Id}", user);

        //         response.EnsureSuccessStatusCode(); // Throw an exception if the response status code indicates an error
        //     }
        //     catch (Exception ex)
        //     {
        //         // Handle any errors, log them, etc.
        //         Console.WriteLine($"Error updating user: {ex.Message}");
        //         throw; // Rethrow the exception to be handled by the caller
        //     }
        // }
    }
}