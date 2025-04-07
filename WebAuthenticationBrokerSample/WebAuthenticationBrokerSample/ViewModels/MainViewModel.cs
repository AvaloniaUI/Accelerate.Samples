using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WebAuthenticationBrokerSample.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        AuthViewModels =
        [
            new CustomOAuthViewModel(this),
            new GoogleOAuthViewModel(this),
            new MicrosoftIdentityOAuthViewModel(this)
        ];

        CurrentViewModel = AuthViewModels.First();
    }

    public TopLevel? AttachedTopLevel { get; set; }

    public IReadOnlyCollection<OAuthViewModelBase> AuthViewModels { get; }

    [ObservableProperty]
    public partial OAuthViewModelBase CurrentViewModel { get; set; }
}
