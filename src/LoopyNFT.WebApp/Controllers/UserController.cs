using LoopyNFT.WebApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoopyNFT.WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly SignInManager<AppUser> _signInManager;

    public UserController(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpPost("/signin")]
    public async Task SignIn(SignInModel model)
    {
        var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
        if (signInResult.Succeeded)
        {
            Redirect("/");
        }
        Redirect("/login/" + signInResult.Succeeded);
    }

    [HttpPost("/signout")]
    public async Task<IActionResult> Logout()
    {
        if (_signInManager.IsSignedIn(User))
        {
            await _signInManager.SignOutAsync();
        }
        return Redirect("/");
    }
}
public class SignInModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}