using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WebAuthenticationBrokerSample.ViewModels;

public partial class CustomOAuthViewModel(MainViewModel mainViewModel) : OAuthViewModelBase("Custom Arguments", mainViewModel)
{
    [ObservableProperty]
    public partial string RequestUri { get; set; } = "";

    [ObservableProperty]
    public partial string RedirectUri { get; set; }  = "http://localhost";

    protected override async Task<string> AuthenticateCore(TopLevel topLevel)
    {
        var result = await WebAuthenticationBroker.AuthenticateAsync(topLevel, new WebAuthenticatorOptions(
            new Uri(RequestUri),
            new Uri(RedirectUri))
        {
            PreferNativeWebDialog = PreferNativeWebDialog
        });

        return "Callback: " + result.CallbackUri;
    }
}