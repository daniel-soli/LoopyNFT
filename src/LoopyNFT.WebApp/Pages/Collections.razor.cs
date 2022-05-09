using LoopyNFT.WebApp.DTOs;
using LoopyNFT.WebApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace LoopyNFT.WebApp.Pages;

public partial class Collections : ComponentBase
{
    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationStateTask { get; set; }

    [Inject] private ICollectionService collectionService { get; set; }
    [Inject] private ISnackbar Snackbar { get; set; }

    public List<CollectionDto> CollectionList { get; set; }
    protected override async Task OnInitializedAsync()
    {
        CollectionList = await collectionService.GetAllCollectionAsync();

    }
}
