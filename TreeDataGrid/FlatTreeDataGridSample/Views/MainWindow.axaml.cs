using System;
using Avalonia.Controls;
using Avalonia.Controls.Selection;
using Avalonia.Input;
using Avalonia.Interactivity;
using FlatTreeDataGridSample.Models;

namespace FlatTreeDataGridSample.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        countries.AddHandler(InputElement.KeyDownEvent, OnPreviewCountriesKeyDown, RoutingStrategies.Tunnel);
    }

    private void OnPreviewCountriesKeyDown(object? sender, KeyEventArgs e)
    {
        if (countries.Source is not TreeDataGridSource<Country> source ||
            countries.Selection is not TreeDataGridRowSelectionModel<Country> selection ||
            selection.SelectedIndex == default)
        {
            return; 
        }

        if (e.Key == Key.Enter)
        {
            // Translate from model index to row index. This is necessary because if the grid is
            // sorted or filtered, then the row and model indices will be ordered differently.
            var selectedRowIndex = source.ModelIndexToRowIndex(selection.SelectedIndex);

            if (selectedRowIndex == -1)
                return;

            // Move the selection down one rowand to translate back to model index.
            var newRowIndex = selectedRowIndex + 1;
            var newModelIndex = source.RowIndexToModelIndex(newRowIndex);

            // Set the new selection. The focused column will remain the same, so we don't need to
            // worry about that (as can be seen by using Tab/Arrow keys to change the focused column
            // and then pressing F2 to edit).
            selection.SelectedIndex = newModelIndex;
        }
    }
}
