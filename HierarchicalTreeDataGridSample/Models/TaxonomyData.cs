using System.Collections.Generic;

namespace HierarchicalTreeDataGridSample.Models;

/// <summary>
/// Provides sample taxonomy data for the hierarchical TreeDataGrid.
/// </summary>
public static class TaxonomyData
{
    public static List<TaxonomyItem> GetSampleTaxonomy()
    {
        // Create a sample taxonomy of animals
        var animals = new List<TaxonomyItem>
        {
            // Mammals
            CreateMammals(),
            
            // Birds
            CreateBirds(),
            
            // Reptiles
            CreateReptiles(),
            
            // Amphibians
            CreateAmphibians(),
            
            // Fish
            CreateFish()
        };

        return animals;
    }

    private static TaxonomyItem CreateMammals()
    {
        var mammals = new TaxonomyItem("Mammals", "Mammalia", 
            "Mammals", 
            "Vertebrates that possess hair, three middle ear bones, and mammary glands",
            "Worldwide in terrestrial, marine, and aerial environments",
            "Various",
            "Class");

        // Primates
        var primates = new TaxonomyItem("Primates", "Primates",
            "Primates", 
            "Mammals with large brains, binocular vision, and grasping hands",
            "Forests, savannas, and mountains",
            "Various",
            "Order");
        
        // Hominidae family
        var hominidae = new TaxonomyItem("Hominidae", "Hominidae",
            "Great Apes",
            "Family of primates that includes orangutans, gorillas, chimpanzees, and humans",
            "Forests, savannas, and global (humans)",
            "Various",
            "Family");

        // Gorilla genus
        var gorilla = new TaxonomyItem("Gorilla", "Gorilla",
            "Gorillas",
            "Largest living primates with broad chest and shoulders",
            "Tropical forests of Africa",
            "Endangered",
            "Genus");

        // Gorilla species
        var westernGorilla = new TaxonomyItem("Western Gorilla", "Gorilla gorilla",
            "Western Gorilla",
            "Gorillas with brownish-gray coats and auburn chests",
            "Lowland forests and swamps in Central Africa",
            "Critically Endangered",
            "Species");
        
        var mountainGorilla = new TaxonomyItem("Mountain Gorilla", "Gorilla beringei beringei",
            "Mountain Gorilla",
            "Gorillas adapted to high-altitude living with longer hair",
            "Mountainous regions of East Africa",
            "Endangered",
            "Subspecies");
        
        gorilla.AddChild(westernGorilla).AddChild(mountainGorilla);
        
        // Homo genus (humans)
        var homo = new TaxonomyItem("Homo", "Homo",
            "Humans and extinct human species",
            "Characterized by bipedalism and large brain size",
            "Global distribution",
            "Least Concern (Homo sapiens)",
            "Genus");

        var homoSapiens = new TaxonomyItem("Modern Human", "Homo sapiens",
            "Human",
            "Only extant species of the genus Homo",
            "Global distribution across various biomes",
            "Least Concern",
            "Species");

        homo.AddChild(homoSapiens);

        // Pan genus (chimpanzees)
        var pan = new TaxonomyItem("Pan", "Pan",
            "Chimpanzees",
            "Genus containing chimpanzees and bonobos",
            "Central and West Africa",
            "Endangered",
            "Genus");

        var chimp = new TaxonomyItem("Chimpanzee", "Pan troglodytes",
            "Chimp",
            "Intelligent great ape with strong social bonds",
            "Forests and savannas of tropical Africa",
            "Endangered",
            "Species");

        var bonobo = new TaxonomyItem("Bonobo", "Pan paniscus",
            "Pygmy Chimpanzee",
            "Smaller than chimpanzees with matriarchal social structure",
            "Congo Basin, Democratic Republic of Congo",
            "Endangered",
            "Species");

        pan.AddChild(chimp).AddChild(bonobo);
        
        hominidae.AddChild(gorilla).AddChild(homo).AddChild(pan);
        primates.AddChild(hominidae);
        
        // Felidae family (cats)
        var felidae = new TaxonomyItem("Felidae", "Felidae",
            "Cats",
            "Family of mammals that includes domestic and wild cats",
            "Worldwide except Antarctica",
            "Various",
            "Family");
        
        var panthera = new TaxonomyItem("Panthera", "Panthera",
            "Big cats",
            "Genus of large wild cats capable of roaring",
            "Africa, Asia, and Americas",
            "Various",
            "Genus");
        
        var lion = new TaxonomyItem("Lion", "Panthera leo",
            "Lion",
            "Large cat with manes in males, living in prides",
            "Sub-Saharan Africa and small population in India",
            "Vulnerable",
            "Species");
        
        var tiger = new TaxonomyItem("Tiger", "Panthera tigris",
            "Tiger",
            "Largest cat species with distinctive striped pattern",
            "Various habitats in Asia",
            "Endangered",
            "Species");
        
        panthera.AddChild(lion).AddChild(tiger);
        felidae.AddChild(panthera);
        
        // Add carnivora order and add felidae to it
        var carnivora = new TaxonomyItem("Carnivora", "Carnivora",
            "Carnivores",
            "Mammals that primarily eat meat",
            "Worldwide in terrestrial and marine environments",
            "Various",
            "Order");
        
        carnivora.AddChild(felidae);
        
        mammals.AddChild(primates).AddChild(carnivora);
        
        return mammals;
    }

    private static TaxonomyItem CreateBirds()
    {
        var birds = new TaxonomyItem("Birds", "Aves",
            "Birds",
            "Warm-blooded vertebrates with feathers, beaks, and wings",
            "Worldwide in terrestrial and aquatic environments",
            "Various",
            "Class");

        // Falconiformes (birds of prey)
        var falconiformes = new TaxonomyItem("Falconiformes", "Falconiformes",
            "Birds of prey",
            "Diurnal birds of prey with sharp talons and hooked beaks",
            "Worldwide except Antarctica",
            "Various",
            "Order");
        
        var accipitridae = new TaxonomyItem("Accipitridae", "Accipitridae",
            "Hawks, Eagles, and Kites",
            "Family of birds with robust bodies and strong wings",
            "Worldwide except Antarctica",
            "Various",
            "Family");
        
        var eagle = new TaxonomyItem("Bald Eagle", "Haliaeetus leucocephalus",
            "Bald Eagle",
            "Large bird of prey with white head and brown body",
            "North America",
            "Least Concern",
            "Species");
        
        accipitridae.AddChild(eagle);
        falconiformes.AddChild(accipitridae);
        
        // Passeriformes (songbirds)
        var passeriformes = new TaxonomyItem("Passeriformes", "Passeriformes",
            "Songbirds",
            "Order containing more than half of all bird species",
            "Worldwide",
            "Various",
            "Order");
        
        var corvidae = new TaxonomyItem("Corvidae", "Corvidae",
            "Crows and Ravens",
            "Family of intelligent birds known for problem-solving",
            "Worldwide except Antarctica and parts of South America",
            "Least Concern",
            "Family");
        
        var raven = new TaxonomyItem("Common Raven", "Corvus corax",
            "Raven",
            "Large, all-black passerine bird with intelligence",
            "Northern Hemisphere",
            "Least Concern",
            "Species");
        
        corvidae.AddChild(raven);
        passeriformes.AddChild(corvidae);
        
        birds.AddChild(falconiformes).AddChild(passeriformes);
        
        return birds;
    }

    private static TaxonomyItem CreateReptiles()
    {
        var reptiles = new TaxonomyItem("Reptiles", "Reptilia",
            "Reptiles",
            "Cold-blooded vertebrates with scales or scutes",
            "All continents except Antarctica",
            "Various",
            "Class");

        // Squamata (snakes and lizards)
        var squamata = new TaxonomyItem("Squamata", "Squamata",
            "Scaled Reptiles",
            "Order including snakes, lizards, and amphisbaenians",
            "Worldwide except Antarctica",
            "Various",
            "Order");
        
        var serpentes = new TaxonomyItem("Serpentes", "Serpentes",
            "Snakes",
            "Elongated, legless, carnivorous reptiles",
            "All continents except Antarctica",
            "Various",
            "Suborder");
        
        var pythonidae = new TaxonomyItem("Pythonidae", "Pythonidae",
            "Pythons",
            "Family of non-venomous constricting snakes",
            "Africa, Asia, and Australia",
            "Various",
            "Family");
        
        var python = new TaxonomyItem("Reticulated Python", "Python reticulatus",
            "Retic",
            "One of the world's longest snakes",
            "Southeast Asia",
            "Least Concern",
            "Species");
        
        pythonidae.AddChild(python);
        serpentes.AddChild(pythonidae);
        squamata.AddChild(serpentes);
        
        reptiles.AddChild(squamata);
        
        return reptiles;
    }

    private static TaxonomyItem CreateAmphibians()
    {
        var amphibians = new TaxonomyItem("Amphibians", "Amphibia",
            "Amphibians",
            "Cold-blooded vertebrates that live part of their lives in water and part on land",
            "All continents except Antarctica",
            "Various",
            "Class");

        // Anura (frogs and toads)
        var anura = new TaxonomyItem("Anura", "Anura",
            "Frogs and Toads",
            "Order of tailless amphibians",
            "Worldwide except Antarctica",
            "Various",
            "Order");
        
        var ranidae = new TaxonomyItem("Ranidae", "Ranidae",
            "True Frogs",
            "Family of typical frogs",
            "Worldwide except Antarctica",
            "Various",
            "Family");
        
        var frog = new TaxonomyItem("American Bullfrog", "Lithobates catesbeianus",
            "Bullfrog",
            "Largest North American frog with deep call",
            "Eastern North America, introduced elsewhere",
            "Least Concern",
            "Species");
        
        ranidae.AddChild(frog);
        anura.AddChild(ranidae);
        
        amphibians.AddChild(anura);
        
        return amphibians;
    }

    private static TaxonomyItem CreateFish()
    {
        var fish = new TaxonomyItem("Fish", "Pisces (informal)",
            "Fish",
            "Aquatic vertebrates with gills and fins",
            "Aquatic habitats worldwide",
            "Various",
            "Informal grouping");

        // Sharks
        var chondrichthyes = new TaxonomyItem("Chondrichthyes", "Chondrichthyes",
            "Cartilaginous Fish",
            "Class of fish with skeletons made of cartilage",
            "Oceans worldwide",
            "Various",
            "Class");
        
        var lamniformes = new TaxonomyItem("Lamniformes", "Lamniformes",
            "Mackerel Sharks",
            "Order including great white and mako sharks",
            "Oceans worldwide",
            "Various",
            "Order");
        
        var lamnidae = new TaxonomyItem("Lamnidae", "Lamnidae",
            "Mackerel Shark Family",
            "Family of large, fast-swimming predatory sharks",
            "Oceans worldwide",
            "Various",
            "Family");
        
        var greatWhite = new TaxonomyItem("Great White Shark", "Carcharodon carcharias",
            "White Shark",
            "Large predatory shark with distinctive white underbelly",
            "Coastal and offshore waters worldwide",
            "Vulnerable",
            "Species");
        
        lamnidae.AddChild(greatWhite);
        lamniformes.AddChild(lamnidae);
        chondrichthyes.AddChild(lamniformes);
        
        // Bony fish
        var actinopterygii = new TaxonomyItem("Actinopterygii", "Actinopterygii",
            "Ray-finned Fish",
            "Class comprising the majority of fish species",
            "Aquatic habitats worldwide",
            "Various",
            "Class");
        
        var salmoniformes = new TaxonomyItem("Salmoniformes", "Salmoniformes",
            "Salmons",
            "Order including salmon, trout, and relatives",
            "Cold and temperate waters of Northern Hemisphere",
            "Various",
            "Order");
        
        var salmonidae = new TaxonomyItem("Salmonidae", "Salmonidae",
            "Salmon Family",
            "Family including salmon, trout, and char",
            "Cold waters of Northern Hemisphere",
            "Various",
            "Family");
        
        var salmon = new TaxonomyItem("Atlantic Salmon", "Salmo salar",
            "Salmon",
            "Large migratory fish that returns to freshwater to spawn",
            "North Atlantic Ocean and rivers",
            "Least Concern",
            "Species");
        
        salmonidae.AddChild(salmon);
        salmoniformes.AddChild(salmonidae);
        actinopterygii.AddChild(salmoniformes);
        
        fish.AddChild(chondrichthyes).AddChild(actinopterygii);
        
        return fish;
    }
}
