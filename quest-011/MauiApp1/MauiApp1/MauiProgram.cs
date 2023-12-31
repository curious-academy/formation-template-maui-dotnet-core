﻿using Interfaces;
using MauiApp1.Features.Planets;
using MauiApp1.Features.Planets.AddPlanet;
using MauiApp1.Features.Planets.AddPlanet.ViewModels;
using MauiApp1.Features.Planets.ListPlanet;
using MauiApp1.Features.Planets.ListPlanet.ViewModels;
using MauiApp1.Shared.UIs.Dialogs;
using MetroLog.MicrosoftExtensions;
using MetroLog.Operators;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Services;
using SQLite.Plugins;

namespace MauiApp1;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureLifecycleEvents(events =>
            {
#if ANDROID
                events.AddAndroid(android => android
                    .OnActivityResult((activity, requestCode, resultCode, data) => LogEvent(nameof(AndroidLifecycle.OnActivityResult), requestCode.ToString()))
                    .OnStart((activity) => LogEvent(nameof(AndroidLifecycle.OnStart)))
                    .OnCreate((activity, bundle) => LogEvent(nameof(AndroidLifecycle.OnCreate)))
                    .OnBackPressed((activity) => LogEvent(nameof(AndroidLifecycle.OnBackPressed)) && false)
                    .OnStop((activity) => LogEvent(nameof(AndroidLifecycle.OnStop))));
#endif

#if IOS
                events.AddiOS(ios => ios
                        .OnActivated((app) => LogEvent(nameof(iOSLifecycle.OnActivated)))
                        .OnResignActivation((app) => LogEvent(nameof(iOSLifecycle.OnResignActivation)))
                        .DidEnterBackground((app) => LogEvent(nameof(iOSLifecycle.DidEnterBackground)))
                        .WillTerminate((app) => LogEvent(nameof(iOSLifecycle.WillTerminate))));
#endif

                static bool LogEvent(string eventName, string type = null)
                {
                    System.Diagnostics.Debug.WriteLine($"Lifecycle event: {eventName}{(type == null ? string.Empty : $" ({type})")}");
                    return true;
                }
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Logging
#if DEBUG
            .AddTraceLogger(
                options =>
                {
                    options.MinLevel = LogLevel.Trace;
                    options.MaxLevel = LogLevel.Critical;
                }) // Will write to the Debug Output
#endif
            .AddInMemoryLogger(
                options =>
                {
                    options.MaxLines = 1024;
                    options.MinLevel = LogLevel.Debug;
                    options.MaxLevel = LogLevel.Critical;
                })
#if RELEASE
            .AddStreamingFileLogger(
                options =>
                {
                    options.RetainDays = 2;
                    options.FolderPath = Path.Combine(
                        FileSystem.CacheDirectory,
                        "MetroLogs");
                })
#endif
            .AddConsoleLogger(
                options =>
                {
                    options.MinLevel = LogLevel.Information;
                    options.MaxLevel = LogLevel.Critical;
                }); // Will write to the Console Output (logcat for android)

        builder.Services.AddSingleton(LogOperatorRetriever.Instance);

        builder.Services.AddSingleton<IDialogService, DialogService>();
        builder.Services.AddSingleton<IAddOnePlanet, SQLiteAddOnePlanet>();
        builder.Services.AddSingleton<IGetPlanets, ApiGetPlanets>();
        builder.Services.AddSingleton<PlanetsUseCase>();

        builder.Services.AddSingleton<AddPlanetViewModel>();
        builder.Services.AddSingleton<AddPlanet>();
        builder.Services.AddSingleton<ListPlanetViewModel>();
        builder.Services.AddSingleton<ListPlanet>();

        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}
