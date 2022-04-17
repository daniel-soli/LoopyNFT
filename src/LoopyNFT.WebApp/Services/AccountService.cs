using LoopyNFT.WebApp.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace LoopyNFT.WebApp.Services;

public interface IAccountService
{
    Task Logout();
    Task SignIn(string userName, string password, bool rememberMe);
}
public class AccountService : IAccountService
{
    private readonly HttpClient _client;

    public AccountService(HttpClient client)
    {
        _client = client;
    }

    public async Task Logout()
    {
        var result = await _client.GetAsync("/signout");
        return;
    }

    public async Task SignIn(string userName, string password, bool rememberMe)
    {
        SignInModel model = new SignInModel() { UserName = userName, Password = password, RememberMe = rememberMe };
        await _client.PostAsJsonAsync<SignInModel>("/signin", model);
    }

}
public class SignInModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
