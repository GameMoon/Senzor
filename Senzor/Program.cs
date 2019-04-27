using Microsoft.AspNetCore.Blazor.Hosting;

namespace Senzor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //initMapper();
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
        //public static void initMapper()
        //{
        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.CreateMap<Block, LogicCompareBlock>();
        //        cfg.CreateMap<Block, NodeInputBlock>();
        //    });
        //}
    }
}
