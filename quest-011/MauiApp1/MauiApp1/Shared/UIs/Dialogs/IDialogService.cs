namespace MauiApp1.Shared.UIs.Dialogs
{
    public interface IDialogService
    {
        Task<bool> ShowConfirmationAsync(string title, string message);
    }
}
