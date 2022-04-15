using ElCamino.AspNetCore.Identity.AzureTable.Model;

namespace LoopyNFT.WebApp.Entities;
public class AppUser : IdentityUser
{
    public string WalletAddress { get; set; }
    public string LocalUserName { get; set; }
    public string TwitterAcount { get; set; }
    public string RedditAccount { get; set; }
    public string DiscordAccount { get; set; }
}
