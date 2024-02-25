using lab1.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
namespace lab1
{
    public static class MauiProgram
    {
        public static IServiceCollection services = new ServiceCollection();
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            services.AddTransient<IDbService, SQLiteService>();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddTransient<PageEmployees>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
