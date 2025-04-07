using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WebAuthenticationBrokerSample.ViewModels;

public abstract partial class OAuthViewModelBase(string title, MainViewModel mainViewModel) : ObservableObject
{
    public string Title => title;

    [ObservableProperty]
    public partial string Result { get; set; } = "";

    [ObservableProperty]
    public partial bool PreferNativeWebDialog { get; set; }

    [RelayCommand]
    private async Task Authenticate()
    {
        if (mainViewModel.AttachedTopLevel is null)
            throw new InvalidOperationException("ViewModel wasn't attached to the View.");

        Result = "In progress...";

        try
        {
            Result = await AuthenticateCore(mainViewModel.AttachedTopLevel);
        }
        catch (OperationCanceledException)
        {
            Result = "Operation cancelled";
        }
        catch (Exception ex)
        {
            // If user cancels the dialog, OperationCanceledException will be thrown.
            Result = $"{ex.GetType()}: {ex.Message}";
        }
    }

    protected abstract Task<string> AuthenticateCore(TopLevel topLevel);
}