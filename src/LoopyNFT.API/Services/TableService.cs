using AutoMapper;
using LoopyNFT.API.Entities;
using Azure.Data.Tables;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using LoopyNFT.API.DTOs;
using Azure;

namespace LoopyNFT.API.Services;
public class TableService : ITableService
{
    private IConfiguration _configuration;
    private readonly IMapper _mapper;

    private TableClient _tableClient { get; set; }

    public TableService(IConfiguration configuration, IMapper mapper)
    {
        
        _configuration = configuration;
        _mapper = mapper;

        var uri = new Uri(_configuration.GetSection("StorageAccount:Uri").Value);
        var tableName = _configuration.GetSection("StorageAccount:TableName").Value;
        var sharedKey = new TableSharedKeyCredential("loopnftstorage", _configuration.GetSection("StorageAccount:SharedKey").Value);
        _tableClient = new TableClient(uri, 
            tableName, 
            sharedKey);
    }

    public async Task<List<CollectionDto>> GetAllCollections()
    {
        var entities = _tableClient.Query<Collection>().AsQueryable();

        if (entities != null)
        {
            List<CollectionDto> result = new List<CollectionDto>();
            foreach (var entity in entities)
            {
                var temp = _mapper.Map<CollectionDto>(entity);
                result.Add(temp);
            }
            return result;
        }
        return null;
    }

    public async Task<CollectionDto> GetCollectionAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id) && Guid.TryParse(id, out Guid guid))
        {
            var entity = _tableClient.Query<Collection>(ent => ent.Id == guid).FirstOrDefault();
            if (entity != null)
                return _mapper.Map<CollectionDto>(entity);
        }

        return null;
    }

    public async Task<bool> CreateCollection(CreateCollectionDto collection)
    {
        Collection request = new Collection()
        {
            Id = Guid.NewGuid(),
            Description = collection.Description,
            Name = collection.Name,
            ImageUrl = collection.ImageUrl,
            OwnerId = collection.OwnerId,
            Quantity = collection.Quantity,
            PartitionKey = collection.OwnerId,
            RowKey = Guid.NewGuid().ToString(),
            Timestamp = DateTimeOffset.UtcNow
        };
        var result = await _tableClient.AddEntityAsync(request);
        if (result.IsError)
            return false;
            
        return true;
    }
}
