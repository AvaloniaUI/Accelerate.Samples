namespace HierarchicalTreeDataGridSample.Models;

/// <summary>
/// A simple hierarchical node, mirroring the model from the bug report: a record with a
/// name and an array of children.
/// </summary>
public record TreeNode(string Name, TreeNode[] Children);
