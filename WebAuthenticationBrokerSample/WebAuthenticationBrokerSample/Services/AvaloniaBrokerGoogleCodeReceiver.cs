using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Avalonia.Controls;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;

namespace WebAuthenticationBrokerSample.Services;

internal class AvaloniaBrokerGoogleCodeReceiver(TopLevel topLevel, string redirectUri, bool preferNativeWebDialog) : ICodeReceiver
{
    public async Task<AuthorizationCodeResponseUrl> ReceiveCodeAsync(AuthorizationCodeRequestUrl url, CancellationToken taskCancellationToken)
    {
        var result = await WebAuthenticationBroker.AuthenticateAsync(topLevel,
            new WebAuthenticatorOptions(url.Build(), new Uri(redirectUri))
            {
                PreferNativeWebDialog = preferNativeWebDialog
            });
        var parameters = HttpUtility.ParseQueryString(result.CallbackUri.Query);
        return new AuthorizationCodeResponseUrl
        {
            State = parameters.Get("state"),
            Code = parameters.Get("code"),
            Error = parameters.Get("error"),
            ErrorDescription = parameters.Get("error_description"),
            ErrorUri = parameters.Get("error_uri")
        };
    }

    public string RedirectUri => redirectUri;
}