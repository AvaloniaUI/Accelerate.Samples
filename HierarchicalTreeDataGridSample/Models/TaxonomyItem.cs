using System.Collections.Generic;

namespace HierarchicalTreeDataGridSample.Models;

/// <summary>
/// Represents an item in a taxonomic classification hierarchy.
/// </summary>
public class TaxonomyItem(
    string name,
    string scientificName,
    string commonName = "",
    string description = "",
    string habitat = "",
    string conservationStatus = "",
    string taxonomicRank = "")
{
    public string Name { get; set; } = name;
    public string ScientificName { get; set; } = scientificName;
    public string CommonName { get; set; } = commonName;
    public string Description { get; set; } = description;
    public string Habitat { get; set; } = habitat;
    public string ConservationStatus { get; set; } = conservationStatus;
    public string TaxonomicRank { get; set; } = taxonomicRank;
    public List<TaxonomyItem> Children { get; } = [];
    
    public TaxonomyItem AddChild(TaxonomyItem child)
    {
        Children.Add(child);
        return this;
    }
}
