namespace LoopyNFT.API.DTOs;
public class CreateCollectionDto
{
    public string OwnerId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
}
