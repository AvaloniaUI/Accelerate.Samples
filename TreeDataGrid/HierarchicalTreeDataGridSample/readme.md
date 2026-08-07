## HierarchicalTreeDataGridSample

This sample reproduces the setup from the bug report *"Expander icon in TreeDataGrid not
responsive to double-click or keyboard toggles"*.

It builds a `HierarchicalTreeDataGridSource<TreeNode>` in `MainWindowViewModel` from a small
tree of fruits and animals, and exposes it to the view via a `Source` property. The view is a
bare `<TreeDataGrid Source="{Binding Source}" />`.

### Setup as described in the report

- **Model**: `public record TreeNode(string Name, TreeNode[] Children);` — a record whose
  children are held in an array.
- **Column**: a single `WithHierarchicalExpanderColumn` whose inner column is a
  `TreeDataGridTemplateColumn` rendering a `TextBlock`. No `isExpanded` binding is supplied.
- **Package**: `Avalonia.Controls.TreeDataGrid` `12.2.0`, matching the version in the report.

### Reproducing / investigating

The tree starts collapsed. The reporter states that the expander chevron only updates when the
chevron itself is clicked, and not when the row is expanded via a double-click or via keyboard
navigation. To exercise each path:

- **Chevron**: click the expander triangle directly.
- **Double-click**: double-click a row's content (away from the chevron).
- **Keyboard**: select a row, then press <kbd>Right</kbd> to expand and <kbd>Left</kbd> to
  collapse.

Note: the report uses a ReactiveUI `ReactiveObject` view-model base; this sample keeps the
repo-standard `CommunityToolkit.Mvvm` base, which is equivalent for this scenario as the
expanded state is not bound to the model.
