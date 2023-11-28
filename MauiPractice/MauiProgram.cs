using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MauiPractice.Service.Network;
using MauiPractice.ViewModel;

namespace MauiPractice;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
           .RegisterServices()
           .RegisterViewModels()
           .RegisterViews();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<INetworkService,NetworkService>();
        return  mauiAppBuilder;
    }
    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder){
      mauiAppBuilder.Services.AddSingleton<MainPage>();
      mauiAppBuilder.Services.AddSingleton<MainDetailPage>();
    return mauiAppBuilder;
    }
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<MainPageViewModel>();
        mauiAppBuilder.Services.AddTransient<MainPageDetailViewModel>();
        return mauiAppBuilder;
    }
}
