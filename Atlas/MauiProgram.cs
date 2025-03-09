using Atlas.Interfaces;
using Atlas.Services;
using Microsoft.Extensions.Logging;
using SQLite;
using Atlas.Views;
using Atlas.ViewModels;

namespace Atlas
{
    public static class MauiProgram
    {

        public static MauiApp CreateMauiApp()
        {
            var databasePath = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
    "atlas.db3"
);

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<SQLiteConnection>(s =>
      new SQLiteConnection(databasePath));

            // Register generic repository
            builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            // Register DataService
            builder.Services.AddSingleton<DataService>();

            // Register pages
            builder.Services.AddTransient<BooksPage>();
            // builder.Services.AddTransient<TodoPage>();
            builder.Services.AddTransient<BooksViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
