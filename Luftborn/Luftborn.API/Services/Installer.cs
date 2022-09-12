using Luftborn.API.Models;
using Luftborn.API.Repositories;
using Luftborn.API.BLL.Items;


namespace Luftborn.API.Services
{
    public static class Installer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository<Item>, Repository<Item>>();
            services.AddTransient<IitemBLL, ItemBLL>();


        }
    }
}
