

public interface IDialogService
{
    Task ShowAlertAsync(string message, string title, string buttonLabel);
    Task <bool> ShowActionSheetAsync(string message, string title);

    Task <bool> ShowConfirmationAsync(string message, string title);
}

