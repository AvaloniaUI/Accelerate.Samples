using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using HierarchicalTreeDataGridSample.Models;

namespace HierarchicalTreeDataGridSample.ViewModels;

/// <summary>
/// Represents the view model for the main window, providing a hierarchical data source
/// for a TreeDataGrid that displays a taxonomic classification system.
/// </summary>
public partial class MainWindowViewModel : ViewModelBase
{
    private readonly ObservableCollection<TaxonomyItem> _data = new(TaxonomyData.GetSampleTaxonomy());

    public MainWindowViewModel()
    {
        // Create a hierarchical TreeDataGrid source
        Source = new HierarchicalTreeDataGridSource<TaxonomyItem>(_data)
        {
            Columns =
            {
                // Define an expander column with an inner text column for the scientific name
                new HierarchicalExpanderColumn<TaxonomyItem>(
                    new TextColumn<TaxonomyItem, string>(
                    "Scientific Name",
                    x => x.ScientificName,
                    new GridLength(2, GridUnitType.Star),
                    new TextColumnOptions<TaxonomyItem>
                    {
                        IsTextSearchEnabled = true,
                    }),
                    x => x.Children),
                
                // Define an expander column with an inner text column the taxonomic rank
                new TextColumn<TaxonomyItem, string>(
                        "Taxonomic Rank",
                        x => x.TaxonomicRank,
                        new GridLength(1, GridUnitType.Star)),
                
                // Define a column for the common name
                new TextColumn<TaxonomyItem, string>(
                    "Common Name",
                    x => x.CommonName,
                    new GridLength(2, GridUnitType.Star)),
                
                // Define a column for the description
                new TextColumn<TaxonomyItem, string>(
                    "Description",
                    x => x.Description,
                    new GridLength(3, GridUnitType.Star)),
                
                // Define a column for the habitat
                new TextColumn<TaxonomyItem, string>(
                    "Habitat",
                    x => x.Habitat,
                    new GridLength(2, GridUnitType.Star)),
                
                // Define a column for the conservation status
                new TemplateColumn<TaxonomyItem>(
                    "Conservation Status",
                    "ConservationStatusTemplate",
                    null,
                    new GridLength(1, GridUnitType.Star))
            }
        };

        // Auto-expand the top level items
        for (var i = 0; i < _data.Count; ++i)
        {
            Source.Expand(i);
        }
    }

    /// <summary>
    /// Gets the hierarchical data source for the tree data grid.
    /// </summary>
    public HierarchicalTreeDataGridSource<TaxonomyItem> Source { get; }
}
