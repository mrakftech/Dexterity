using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dexterity.UiServices;

public class SnackbarNotificationService(ISnackbar snackbar)
{
    [Inject] internal ISnackbar Snackbar { get; set; } = snackbar;


    public void SuccessMessage(string message)
    {
        Snackbar.Add(message);
        
    }

    public void FailMessage(string message)
    {
        Snackbar.Add(message, Severity.Error);
    }
}