using LoopyNFT.WebApp.DTOs;

namespace LoopyNFT.WebApp.Services
{
    public interface ICollectionService
    {
        Task<bool> CreateCollectionAsync(CreateCollectionDto request);
    }
}