using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using WebAuthenticationBrokerSample.Services;

namespace WebAuthenticationBrokerSample.ViewModels;

public partial class GoogleOAuthViewModel(MainViewModel mainViewModel)
    : OAuthViewModelBase("Google", mainViewModel)
{
    [ObservableProperty]
    public partial string ClientId { get; set; } = "";

    [ObservableProperty]
    public partial string ClientSecret { get; set; } = "";

    [ObservableProperty]
    public partial string RedirectUri { get; set; }  = "http://localhost";

    protected override async Task<string> AuthenticateCore(TopLevel topLevel)
    {
        if (string.IsNullOrWhiteSpace(ClientId))
            throw new InvalidOperationException("ClientId must be set.");
        if (string.IsNullOrWhiteSpace(ClientSecret))
            throw new InvalidOperationException("ClientSecret must be set.");
        if (string.IsNullOrWhiteSpace(RedirectUri))
            throw new InvalidOperationException("RedirectUri must be set.");

        var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            new ClientSecrets
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret
            },
            ["openid"],
            "user",
            CancellationToken.None,
            codeReceiver: new AvaloniaBrokerGoogleCodeReceiver(topLevel, RedirectUri, PreferNativeWebDialog),
            dataStore: new NullDataStore());
        return "Token: " + credential.Token.AccessToken;
    }
}
