using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Microsoft.Identity.Client.Extensibility;

namespace WebAuthenticationBrokerSample.Services;

public class AvaloniaBrokerAzureWebUI(TopLevel topLevel, bool preferNativeWebDialog) : ICustomWebUi
{
    public async Task<Uri> AcquireAuthorizationCodeAsync(Uri authorizationUri, Uri redirectUri, CancellationToken cancellationToken)
    {
        var result = await WebAuthenticationBroker
            .AuthenticateAsync(topLevel, new WebAuthenticatorOptions(authorizationUri, redirectUri))
            .WaitAsync(cancellationToken);
        return result.CallbackUri;
    }
}