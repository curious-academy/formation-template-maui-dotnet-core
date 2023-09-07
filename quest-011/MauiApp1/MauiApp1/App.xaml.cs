using MetroLog.Maui;

namespace MauiApp1;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();

        LogController.InitializeNavigation(
            page => MainPage!.Navigation.PushModalAsync(page),
            () => MainPage!.Navigation.PopModalAsync());
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        window.Created += (s, e) => { Application.Current.MainPage.DisplayAlert("Created", "Created", "ok", "no"); }; // Après création fenêtre native, fenetre peut etre pas encore visible

        window.Activated += (s, e) => { Application.Current.MainPage.DisplayAlert("Activated", "Activated", "ok", "no"); }; // fenetre active / prioritaire

        window.Deactivated += (s, e) => { Application.Current.MainPage.DisplayAlert("Deactivated", "Deactivated", "ok", "no"); }; // plus prio, mais peut etre encore visible

        window.Stopped += (s, e) => { Application.Current.MainPage.DisplayAlert("Stopped", "Stopped", "ok", "no"); }; // plus visible

        window.Resumed += (s, e) => { Application.Current.MainPage.DisplayAlert("Resumed", "Resumed", "ok", "no"); };  // application reprend, après stopped, obligatoirement

        window.Destroying += (s, e) => { Application.Current.MainPage.DisplayAlert("Destroying", "Destroying", "ok", "no"); }; // fenetre native détruite / libérée

        return window;
    }
}

