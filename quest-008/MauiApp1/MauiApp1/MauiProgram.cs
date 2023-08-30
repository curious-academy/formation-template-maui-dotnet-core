using Interfaces;
using MauiApp1.Features.Planets;
using MauiApp1.Features.Planets.AddPlanet;
using MauiApp1.Features.Planets.ListPlanet;
using Services;

namespace MauiApp1;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<IGetPlanets, ApiGetPlanets>();
        builder.Services.AddSingleton<PlanetsUseCase>();
        builder.Services.AddSingleton<AddPlanet>();
        builder.Services.AddSingleton<ListPlanet>();
        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}
