using LoopyNFT.API.DTOs;
using LoopyNFT.API.Entities;

namespace LoopyNFT.API.Services
{
    public interface ITableService
    {
        Task<bool> CreateCollection(CreateCollectionDto collection);
        Task<List<CollectionDto>> GetAllCollections();
        Task<CollectionDto> GetCollectionAsync(string id);
    }
}