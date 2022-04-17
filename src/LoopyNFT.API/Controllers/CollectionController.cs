using LoopyNFT.API.DTOs;
using LoopyNFT.API.Entities;
using LoopyNFT.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoopyNFT.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CollectionController : ControllerBase
{
    private readonly ILogger<CollectionController> _logger;
    private readonly ITableService _tableService;

    public CollectionController(ILogger<CollectionController> logger, ITableService tableService)
    {
        _logger = logger;
        _tableService = tableService;
    }

    [HttpGet(Name = "GetCollections")]
    public async Task<List<CollectionDto>> Get()
    {
        var result = await _tableService.GetAllCollections();
        return result;
    }

    [HttpPost(Name = "CreateCollection")]
    public async Task<bool> Add(CreateCollectionDto collection)
    {
        var result = await _tableService.CreateCollection(collection);

        return result;
    }

    [HttpGet("{id}")]
    public async Task<CollectionDto> Get(string id) 
    {
        var result = await _tableService.GetCollectionAsync(id);
        return result;
    }
}
