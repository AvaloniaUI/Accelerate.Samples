using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WebAuthenticationBrokerSample.ViewModels;

public partial class CustomOAuthViewModel(MainViewModel mainViewModel) : OAuthViewModelBase("Custom Arguments", mainViewModel)
{
    private const string CommunityPortalRedirectUri = "https://avaloniaui.community/ssos/redirect";

    [ObservableProperty]
    public partial string RequestUri { get; set; } = BuildAvaloniaPortalOAuthUrl();

    [ObservableProperty]
    public partial string RedirectUri { get; set; }  = CommunityPortalRedirectUri;

    protected override async Task<string> AuthenticateCore(TopLevel topLevel)
    {
        var result = await WebAuthenticationBroker.AuthenticateAsync(topLevel, new WebAuthenticatorOptions(
            new Uri(RequestUri),
            new Uri(RedirectUri))
        {
            PreferNativeWebDialog = PreferNativeWebDialog
        });

        var queryDictionary = System.Web.HttpUtility.ParseQueryString(result.CallbackUri.Query);
        return $"""
                CallbackUri: {result.CallbackUri}
                Query:
                {string.Join(Environment.NewLine, queryDictionary.AllKeys.Select(k => $"{k} = {queryDictionary[k]}"))}

                """;
    }

    /// <summary>
    /// Builds an OAuth 2.0 authorization URL for the Avalonia Portal authentication flow.
    /// </summary>
    /// <param name="redirectUri">The URI where the authorization server will redirect the user after completing the authentication process.</param>
    /// <param name="scope">Space-separated list of permissions that the application requests. See: https://openid.net/specs/openid-connect-core-1_0.html#ScopeClaims</param>
    /// <param name="clientId">The client identifier issued to the client during the registration process.</param>
    /// <returns>A fully constructed authorization URL that initiates the OAuth flow.</returns>
    /// <remarks>
    /// This method implements the OAuth 2.0 Authorization Code Flow as specified in RFC 6749.
    /// See: https://datatracker.ietf.org/doc/html/rfc6749#section-4.1
    ///
    /// IMPORTANT: this method works as a working demo of using WebAuth API with a custom OAuth/SSO provider.
    /// This exact code can't be used in production. 
    /// </remarks>
    private static string BuildAvaloniaPortalOAuthUrl(
        string redirectUri = CommunityPortalRedirectUri,
        string scope = "openid email profile",
        string clientId = "bettermode")
    {
        var state = new JsonObject();

        var stateEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(state)))
            .TrimEnd('=')
            .Replace('+', '-')
            .Replace('/', '_');

        var authorizeUrl = $"/__sso/connect/authorize" +
                           $"?response_type=code" +
                           $"&redirect_uri={Uri.EscapeDataString(redirectUri)}" +
                           $"&scope={Uri.EscapeDataString(scope)}" +
                           $"&state={stateEncoded}" +
                           $"&client_id={clientId}";

        return $"https://portal.avaloniaui.net/login?ReturnUrl={Uri.EscapeDataString(authorizeUrl)}";
    }
}