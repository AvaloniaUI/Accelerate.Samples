using Avalonia;
using Avalonia.Controls;
using WebAuthenticationBrokerSample.ViewModels;

namespace WebAuthenticationBrokerSample.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        ((MainViewModel)DataContext!).AttachedTopLevel = TopLevel.GetTopLevel(this);
        base.OnAttachedToVisualTree(e);
    }

    protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
    {
        ((MainViewModel)DataContext!).AttachedTopLevel = null;
        base.OnDetachedFromVisualTree(e);
    }
}