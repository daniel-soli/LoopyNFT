using Azure;
using Azure.Data.Tables;
using LoopyNFT.API.DTOs;

namespace LoopyNFT.API.Entities;
public class Collection : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
    public Guid Id { get; set; }
    public string OwnerId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public string CollectionImage { get; set; }
}
