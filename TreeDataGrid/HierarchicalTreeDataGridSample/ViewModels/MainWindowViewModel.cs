using Avalonia.Controls;
using Avalonia.Controls.Templates;
using HierarchicalTreeDataGridSample.Models;

namespace HierarchicalTreeDataGridSample.ViewModels;

/// <summary>
/// Reproduces the setup from the bug report: a single hierarchical expander column whose
/// inner column is a <see cref="TreeDataGridTemplateColumn"/> rendering a <see cref="TextBlock"/>,
/// with no <c>isExpanded</c> binding. The tree is left collapsed so the expander icon can be
/// toggled by clicking the chevron, double-clicking a row, or using keyboard navigation
/// (Left/Right arrows).
/// </summary>
public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Source = CreateFakeData();
    }

    /// <summary>
    /// Gets the hierarchical data source for the tree data grid.
    /// </summary>
    public HierarchicalTreeDataGridSource<TreeNode> Source { get; private set; }

    private static HierarchicalTreeDataGridSource<TreeNode> CreateFakeData()
    {
        var nodes = new TreeNode[]
        {
            new TreeNode("Fruits",
            [
                new TreeNode("apples", []),
                new TreeNode("oranges", []),
            ]),
            new TreeNode("Animals",
            [
                new TreeNode("cats", []),
                new TreeNode("dogs", []),
            ]),
        };

        return new HierarchicalTreeDataGridSource<TreeNode>(nodes)
            .WithHierarchicalExpanderColumn(
                "Name",
                new TreeDataGridTemplateColumn
                {
                    Width = GridLength.Star,
                    CellTemplate = new FuncDataTemplate<TreeNode>((x, _) =>
                    {
                        // (my case is more complicated obviously)
                        return new TextBlock { Text = x?.Name };
                    })
                },
                x => x.Children,
                options: o => { o.Width = GridLength.Star; });
    }
}
