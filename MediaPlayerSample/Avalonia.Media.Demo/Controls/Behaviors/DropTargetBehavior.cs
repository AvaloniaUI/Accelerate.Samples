using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Threading;
using Avalonia.Xaml.Interactivity;

namespace Avalonia.Media.Demo.Controls.Behaviors;

public class DropTargetBehavior : Behavior<Control>
{
    public static readonly StyledProperty<ICommand?> DropCommandProperty =
        AvaloniaProperty.Register<DropTargetBehavior, ICommand?>(
            nameof(DropCommand));

    public ICommand? DropCommand
    {
        get => GetValue(DropCommandProperty);
        set => SetValue(DropCommandProperty, value);
    }
    
    protected override void OnAttached()
    {
        base.OnAttached();
        if (AssociatedObject == null) return;
        AssociatedObject.SetValue(DragDrop.AllowDropProperty, true);
        AssociatedObject.AddHandler(DragDrop.DropEvent, Drop);
        AssociatedObject.AddHandler(DragDrop.DragEnterEvent, DragEnter);
        AssociatedObject.AddHandler(DragDrop.DragLeaveEvent, DragLeave);
     } 

    protected override void OnDetaching()
    {
        base.OnDetaching();
        if (AssociatedObject == null) return;
        AssociatedObject.SetValue(DragDrop.AllowDropProperty, false);
        AssociatedObject.RemoveHandler(DragDrop.DropEvent, Drop);
        AssociatedObject.RemoveHandler(DragDrop.DragEnterEvent, DragEnter);
        AssociatedObject.RemoveHandler(DragDrop.DragLeaveEvent, DragLeave);

     }

    private void DragLeave(object? sender, DragEventArgs e)
    {
        e.DragEffects &= (DragDropEffects.Copy | DragDropEffects.Move);
        if (!e.Data.Contains(DataFormats.Files))
        {
            e.DragEffects = DragDropEffects.None;
            return;
        }
        
        DisableClass();
    }

    private void DragEnter(object? sender, DragEventArgs e)
    {
        e.DragEffects &= (DragDropEffects.Copy | DragDropEffects.Move);
        if (!e.Data.Contains(DataFormats.Files))
        {
            e.DragEffects = DragDropEffects.None;
            return;
        }
        
        EnableClass();
    }

    private void Drop(object? sender, DragEventArgs e)
    {
        DisableClass();
        if (!e.Data.Contains(DataFormats.Files)) return;
        if (DropCommand?.CanExecute(e) == true)
        {
            DropCommand.Execute(e);
        }
    }

    private void DisableClass()
    {
        Dispatcher.UIThread.Post(() =>
        {
            if (AssociatedObject?.Classes.Contains("dragover") ?? false)
            {
                AssociatedObject.Classes.Remove("dragover");
            }
        });

    }
    
    private void EnableClass()
    {
        Dispatcher.UIThread.Post(() =>
        {
            if (AssociatedObject is { } associatedObject && !associatedObject.Classes.Contains("dragover"))
            {
                associatedObject.Classes.Add("dragover");
            }
        });
    }
}