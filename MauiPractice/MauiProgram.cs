using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MauiPractice.Service;
using MauiPractice.ViewModel;
using MauiPractice.View;
using eShopOnContainers.Services;

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
        mauiAppBuilder.Services.AddSingleton<INetworkService, NetworkService>();
        mauiAppBuilder.Services.AddSingleton<IDialogService, DialogService>();
        return mauiAppBuilder;
    }
    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<MainPage>();
        mauiAppBuilder.Services.AddSingleton<MainDetailPage>();
        mauiAppBuilder.Services.AddSingleton<FirstPage>();
        mauiAppBuilder.Services.AddSingleton<SecondPage>();
        return mauiAppBuilder;
    }
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<MainPageViewModel>();
        mauiAppBuilder.Services.AddTransient<MainPageDetailViewModel>();
        mauiAppBuilder.Services.AddTransient<FirstPageViewModel>();
        mauiAppBuilder.Services.AddSingleton<SecondPageViewModel>();
        return mauiAppBuilder;
    }
}
