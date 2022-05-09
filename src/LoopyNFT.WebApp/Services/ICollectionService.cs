using LoopyNFT.WebApp.DTOs;

namespace LoopyNFT.WebApp.Services
{
    public interface ICollectionService
    {
        Task<bool> CreateCollectionAsync(CreateCollectionDto request);
        Task<List<CollectionDto>> GetAllCollectionAsync();
        Task<CollectionDto> GetCollectionAsync(string collectionId);
    }
}