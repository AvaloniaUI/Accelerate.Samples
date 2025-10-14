## HierarchicalTreeDataGridSample

This sample demonstrates how to use the `TreeDataGrid` component to display hierarchical data in a tree-like structure.

It uses the MVVM pattern and sets up a `HierarchicalTreeDataGridSource` in `MainWindowViewModel` which is exposed to the view via a property.

The sample showcases a biological taxonomy classification system, displaying organisms hierarchically organized by their taxonomic ranks (Class, Order, Family, Genus, Species, etc.).

## Key Features Demonstrated

### Hierarchical Data Representation
- **Parent-Child Relationships**: Demonstrates how to model and display hierarchical data
- **Expandable Nodes**: Shows how to configure expandable/collapsible nodes for navigating the hierarchy
- **Depth Visualization**: Proper indentation showing the depth level of each item

### Advanced TreeDataGrid Features
- **Custom Node Styling**: Different styling for parent nodes vs. leaf nodes
- **Conditional Formatting**: Color-coded conservation status based on values
- **Custom Templates**: Using templates for specialized data visualization
- **Auto-Expansion**: Automatically expanding top-level nodes when loading

### Data Handling
- **Dynamic Children Loading**: Demonstrates how to provide children for each node using a ChildrenGetter
- **Hierarchical Data Model**: Shows proper modeling of nested data with parent-child relationships

### Visual Customization
- **Status Indicators**: Visual indication of conservation status with color-coding
- **Parent Node Highlighting**: Visual differentiation for nodes that contain children
- **Special Formatting**: Customized appearance for taxonomy ranks and scientific names

This sample is particularly useful for visualizing any hierarchical data structure such as file systems, organizational charts, product categories, or taxonomies.
