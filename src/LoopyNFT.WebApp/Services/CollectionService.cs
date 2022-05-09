using LoopyNFT.WebApp.DTOs;

namespace LoopyNFT.WebApp.Services;
public class CollectionService : ICollectionService
{
    private readonly HttpClient _client;

    public CollectionService(HttpClient client)
    {
        _client = client;
    }

    public async Task<bool> CreateCollectionAsync(CreateCollectionDto request)
    {
        var result = await _client.PostAsJsonAsync<CreateCollectionDto>("Collection", request);
        return result.IsSuccessStatusCode;
    }

    public async Task<List<CollectionDto>> GetAllCollectionAsync()
    {
        var result = await _client.GetFromJsonAsync<List<CollectionDto>>("Collection");
        if (result.Count <= 0) return null;
        return result.ToList();
    }

    public async Task<CollectionDto> GetCollectionAsync(string collectionId)
    {
        var result = await _client.GetFromJsonAsync<CollectionDto>($"Collection/{collectionId}");

        if (result == null) return null;
        return result;
    }
}
