using ElCamino.AspNetCore.Identity.AzureTable.Model;

namespace LoopyNFT.WebApp.Entities;
public class AppUser : IdentityUser
{
    public string WalletAddress { get; set; }
}
