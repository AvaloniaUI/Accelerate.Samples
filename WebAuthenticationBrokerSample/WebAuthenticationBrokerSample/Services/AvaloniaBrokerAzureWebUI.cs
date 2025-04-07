using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Threading;
using Microsoft.Identity.Client.Extensibility;

namespace WebAuthenticationBrokerSample.Services;

public class AvaloniaBrokerAzureWebUI(TopLevel topLevel, bool preferNativeWebDialog) : ICustomWebUi
{
    public Task<Uri> AcquireAuthorizationCodeAsync(Uri authorizationUri, Uri redirectUri, CancellationToken cancellationToken)
    {
        // Sometimes, ICustomWebUi can be executed off-the UI thread. 
        return Dispatcher.UIThread.InvokeAsync(async () =>
        {
            var result = await WebAuthenticationBroker
                .AuthenticateAsync(topLevel, new WebAuthenticatorOptions(authorizationUri, redirectUri)
                {
                    PreferNativeWebDialog = preferNativeWebDialog
                })
                .WaitAsync(cancellationToken);
            return result.CallbackUri;
        });
    }
}