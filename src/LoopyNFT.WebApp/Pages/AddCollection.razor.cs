using LoopyNFT.WebApp.DTOs;
using LoopyNFT.WebApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Security.Claims;

namespace LoopyNFT.WebApp.Pages;
public partial class AddCollection : ComponentBase
{
    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationStateTask { get; set; }

    [Inject] private ICollectionService collectionService { get; set; }
    [Inject] private ISnackbar Snackbar { get; set; }

    private CreateCollectionDto model = new CreateCollectionDto();
    private bool success;
    public EditContext editContext;
    private ClaimsPrincipal user;

    private string userId = string.Empty;
    protected override void OnInitialized()
    {
        model = new()
        {
            Description = "",
            ImageUrl = "",
            Name = "",
            OwnerId = "",
            Quantity = 1
        };

        editContext = new EditContext(model);
    }

    protected override async Task OnInitializedAsync()
    {
        user = (await AuthenticationStateTask).User;
        userId = user.Identity.Name;
        var username = user.Identity.Name;
    }

    private async Task<bool> OnValidSubmit(EditContext context)
    {
        model.OwnerId = userId;
        var result = await collectionService.CreateCollectionAsync(model);
        if (result.Equals(true))
        {
            model = new();
            StateHasChanged();
            Snackbar.Add("Collection has been added!", MudBlazor.Severity.Success);
            return true;
        }
        StateHasChanged();
        Snackbar.Add("ERROR: Collection could not be added!", MudBlazor.Severity.Error);
        return false;
    }

}
