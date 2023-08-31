namespace MauiApp1.Shared.UIs.Dialogs
{
    internal class DialogService : IDialogService
    {
        public Task<bool> ShowConfirmationAsync(string title, string message)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, "ok", "no");
        }
    }
}
