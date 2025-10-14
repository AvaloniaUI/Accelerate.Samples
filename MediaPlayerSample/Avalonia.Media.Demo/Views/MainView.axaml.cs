using Avalonia.Media.Demo.ViewModels;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Labs.Controls;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Linq;

namespace Avalonia.Media.Demo.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private MainViewModel? MainVm { get; set; }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        MainVm = DataContext as MainViewModel;

        if (MainVm is null) throw new InvalidOperationException("MainViewModel can't be null.");

        MainVm.DropCommand = new RelayCommand<DragEventArgs>(HandleDrop);

        base.OnAttachedToVisualTree(e);
    }

    private void HandleDrop(DragEventArgs? e)
    {
        var files = e?.Data.GetFiles()?.FirstOrDefault();

        if (files is null || MainVm is null) return;

        MainVm.SetSource(new UriSource(files.Path));
        
    }

    private async void Load_Click(object? _, RoutedEventArgs __)
    {
        var storageProver = TopLevel.GetTopLevel(this)?.StorageProvider;
        if (storageProver is null || MainVm is null)
            return;

        var files = await storageProver.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            AllowMultiple = false
        });

        if (files.Count != 1) return;
        if (files[0].Path is not { } path) return;

        MainVm.Source = new StorageFileSource(files[0]);
    }

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        MainVm?.DragMoveCommand?.Execute(e);
    }

    private async void Load_Uri_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var dialog = new ContentDialog()
        {
            PrimaryButtonText = "Open",
            SecondaryButtonText = "Cancel",
            Title = "Open URL"
        };

        var input = new TextBox()
        {
            Watermark = "Enter Url"
        };

        dialog.Content = input;

        var result = await dialog.ShowAsync();

        if(result == ContentDialogResult.Primary)
        {
            if (string.IsNullOrWhiteSpace(input.Text) || MainVm == null) return;

            var url = input.Text;
            MainVm.Source = new UriSource(url);
        }
    }

    private async void MediaPlayerControl_OnErrorOccurred(object? sender, MediaPlayerControlErrorEventArgs e)
    {
        var dialog = new ContentDialog
        {
            PrimaryButtonText = "Ok",
            SecondaryButtonText = null,
            IsSecondaryButtonEnabled = false,
            Title = "Error Occurred",
            Content = new ScrollViewer
            {
                Content = new SelectableTextBlock
                {
                    Text = e.Message
                },
                MaxHeight = 300
            }
        };
        e.Handled = true;
        await dialog.ShowAsync();
    }
}