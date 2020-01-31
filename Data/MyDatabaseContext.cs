using Microsoft.EntityFrameworkCore;

namespace DotNetCoreSqlDb.Models
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext (DbContextOptions<MyDatabaseContext> options)
            : base(options)
        {
            var conn = (System.Data.SqlClient.SqlConnection)Database.GetDbConnection();
            string accesstoken = new Microsoft.Azure.Services.AppAuthentication.AzureServiceTokenProvider().GetAccessTokenAsync("https://database.windows.net/").Result;
            //if the user belogns to more subscriptions/tenants, add tenantID
            //string accesstoken = new Microsoft.Azure.Services.AppAuthentication.AzureServiceTokenProvider().GetAccessTokenAsync("https://database.windows.net/", "<tenantid>").Result;
            conn.AccessToken = accesstoken;
            
        }

        public DbSet<DotNetCoreSqlDb.Models.Todo> Todo { get; set; }
    }
}
