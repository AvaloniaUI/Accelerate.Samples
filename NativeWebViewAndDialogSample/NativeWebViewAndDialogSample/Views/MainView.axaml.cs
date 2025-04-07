using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using NativeWebViewAndDialogSample.ViewModels;

namespace NativeWebViewAndDialogSample.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void NativeWebView_OnNavigationStarted(object? sender, WebViewNavigationStartingEventArgs e)
    {
        ((MainViewModel)DataContext!).Log.Add($"OnNavigationStarted: {e.Request}");
    }

    private void NativeWebView_OnNavigationCompleted(object? sender, WebViewNavigationCompletedEventArgs e)
    {
        ((MainViewModel)DataContext!).Log.Add($"OnNavigationCompleted: {e.Request}");
    }

    private void NativeWebView_OnWebMessageReceived(object? sender, WebMessageReceivedEventArgs e)
    {
        ((MainViewModel)DataContext!).Log.Add($"OnWebMessageReceived: {e.Body}");
    }

    private async void ExecuteScript_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var result = await WebView.InvokeScript(ScriptTextBox.Text!);
            ((MainViewModel)DataContext!).Log.Add($"InvokeScript: {result}");
        }
        catch (Exception ex)
        {
            ((MainViewModel)DataContext!).Log.Add($"InvokeScript: {ex.Message}");
        }
    }
}