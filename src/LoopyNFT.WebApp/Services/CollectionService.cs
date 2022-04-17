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
}
