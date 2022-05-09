using System.ComponentModel.DataAnnotations;

namespace LoopyNFT.WebApp.DTOs;
public class CreateCollectionDto
{
    public string OwnerId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public string CollectionImage { get; set; }
}
