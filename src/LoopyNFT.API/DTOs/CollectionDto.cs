using AutoMapper;
using Azure.Data.Tables;
using LoopyNFT.API.Common.Mappings;
using LoopyNFT.API.Entities;

namespace LoopyNFT.API.DTOs;
public class CollectionDto : IMapFrom<Collection>
{
    public string Id { get; set; }
    public string OwnerId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public string ColletionImage { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Collection, CollectionDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id.ToString()));
    }
}
