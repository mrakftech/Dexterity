using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dexterity.Services;

public class SnackbarNotificationService(ISnackbar snackbar)
{
    [Inject] public ISnackbar Snackbar { get; set; } = snackbar;


    public void SuccessMessge(string message)
    {
        Snackbar.Add(message);
    }

    public void FailMessge(string message)
    {
        Snackbar.Add(message, Severity.Error);
    }
}