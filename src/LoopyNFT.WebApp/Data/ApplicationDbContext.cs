using ElCamino.AspNetCore.Identity.AzureTable;
using ElCamino.AspNetCore.Identity.AzureTable.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoopyNFT.WebApp.Data
{
    public class ApplicationDbContext : IdentityCloudContext
    {
        //public ApplicationDbContext() : base()
        //{
        //}

        public ApplicationDbContext(IdentityConfiguration config) : base(config)
        {

        }
    }
}