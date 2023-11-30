namespace eShopOnContainers.Services;

public class DialogService : IDialogService
{
    public Task ShowAlertAsync(string message, string title, string buttonLabel)
    {
        return Application.Current.MainPage.DisplayAlert(title, message, buttonLabel);
    }
    public async Task<bool> ShowActionSheetAsync(string message, string title)
    {
        var result = await Application.Current.MainPage.DisplayActionSheet(title, "Cancel", null, "Yes", "No");
        return result == "Yes";
    }

    //커스텀해야함
    public async Task<bool> ShowConfirmationAsync(string message, string title)
    {
        return await Application.Current.MainPage.DisplayAlert(title, message, "Yes", "No");
    }
}