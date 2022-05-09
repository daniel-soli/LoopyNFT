using LoopyNFT.WebApp.DTOs;
using LoopyNFT.WebApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace LoopyNFT.WebApp.Pages;

public partial class CollectionDetail : ComponentBase
{
    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationStateTask { get; set; }

    [Parameter]
    public string CollectionId { get; set; }

    [Inject] private ICollectionService collectionService { get; set; }
    [Inject] private ISnackbar Snackbar { get; set; }

    public CollectionDto Collection { get; set; }
    protected override async Task OnParametersSetAsync()
    {
        Collection = await collectionService.GetCollectionAsync(CollectionId);
        StateHasChanged();
    }
}
