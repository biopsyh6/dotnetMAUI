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
            string databasePath = "Database.db";
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, databasePath);
            var builder = MauiApp.CreateBuilder();
            services.AddTransient<IDbService, SQLiteService>(sp=>new SQLiteService(dbPath));
            services.AddHttpClient<IRateService>(opt =>
                    opt.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates"));
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddTransient<PageEmployees>();
            var baseAddress = DeviceInfo.Platform == DevicePlatform.Android
                    ? "http://10.0.2.2:5091"
                    : "https://localhost:7091";
            builder.Services.AddHttpClient<IRateService, RateService>(opt => opt.BaseAddress = new Uri(baseAddress));
            builder.Services.AddSingleton<IRateService, RateService>();
            builder.Services.AddSingleton<Currency_Converter>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
