using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;
using WebAuthenticationBrokerSample.Services;

namespace WebAuthenticationBrokerSample.ViewModels;

public partial class MicrosoftIdentityOAuthViewModel(MainViewModel mainViewModel)
    : OAuthViewModelBase("Microsoft Identity", mainViewModel)
{
    [ObservableProperty]
    public partial string ClientId { get; set; } = "";

    [ObservableProperty]
    public partial string Authority { get; set; } = "";

    [ObservableProperty]
    public partial string RedirectUri { get; set; }  = "http://localhost";

    protected override async Task<string> AuthenticateCore(TopLevel topLevel)
    {
        if (string.IsNullOrWhiteSpace(ClientId))
            throw new InvalidOperationException("ClientId must be set.");
        if (string.IsNullOrWhiteSpace(Authority))
            throw new InvalidOperationException("Authority must be set.");
        if (string.IsNullOrWhiteSpace(RedirectUri))
            throw new InvalidOperationException("RedirectUri must be set.");

        var app = PublicClientApplicationBuilder
            .Create(ClientId)
            .WithAuthority(Authority)
            .WithRedirectUri(RedirectUri)
            .Build();

        var accounts = await app.AcquireTokenInteractive(["User.Read"])
            .WithCustomWebUi(new AvaloniaBrokerAzureWebUI(topLevel, PreferNativeWebDialog))
            .ExecuteAsync();

        return "Access token: " + accounts.AccessToken;
    }
}