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

        // Add tunneling event handlers to override selection behavior.
        countries.AddHandler(TreeDataGrid.PointerPressedEvent, countries_PointerPressed, RoutingStrategies.Tunnel);
        countries.AddHandler(TreeDataGrid.KeyDownEvent, countries_KeyDown, RoutingStrategies.Tunnel);
    }

    private void countries_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (countries.TryGetCell(e.Source as Control, out var cell) &&
            countries.Source?.Selection is TreeDataGridCellSelectionModel<Country> selection)
        {
            if (cell.ColumnIndex == 2)
            {
                // Clicks on the Population column cause cell selection.
                selection.SelectedIndex = new(cell.ColumnIndex, cell.RowIndex);
            }
            else
            {
                // Clicks anywhere but the Population column cause row selection.
                selection.SetSelectedRange(new(0, cell.RowIndex), countries.Columns.Count, 1);
            }

            // Mark the event as handled to prevent default selection interaction behavior.
            e.Handled = true;

            // Handling the tunneling event will also prevent default focus handling and so focus
            // needs to be changed manually.
            cell.Focus();
        }
    }

    private void countries_KeyDown(object? sender, KeyEventArgs e)
    {
        if (countries.Source?.Selection is not TreeDataGridCellSelectionModel<Country> selection)
            return;

        (int x, int y) delta = e.Key switch
        {
            Key.Up => (0, -1),
            Key.Down => (0, 1),
            Key.Left => (-1, 0),
            Key.Right => (1, 0),
            _ => default,
        };

        var rowIndex = countries.Source.ModelIndexToRowIndex(selection.SelectedIndex.RowIndex);

        if (delta == default || rowIndex == -1)
            return;

        if (selection.Count == 1)
        {
            // A single cell is selected: if the user presses left or right, select the whole row.
            // Otherwise for up and down allow the default selection interaction.
            if (delta.x != 0)
            {
                selection.SetSelectedRange(new(0, rowIndex), countries.Columns.Count, 1);
                e.Handled = true;
            }
        }
        else if (selection.Count > 1)
        {
            // A row is selected, move the selection up or down.
            if (delta.y != 0)
            {
                var nextRowIndex = Math.Clamp(rowIndex + delta.y, 0, countries.Source.Rows.Count);
                selection.SetSelectedRange(new(0, nextRowIndex), countries.Columns.Count, 1);
            }

            e.Handled = true;
        }
    }
}
