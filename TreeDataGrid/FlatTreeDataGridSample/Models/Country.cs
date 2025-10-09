namespace FlatTreeDataGridSample.Models;

internal class Country(
    string name,
    string region,
    int population,
    int area,
    double density,
    double coast,
    double? migration,
    double? infantMorality,
    int gdp,
    double? literacy,
    double? phones,
    double? birth,
    double? death)
{
    public string? Name { get; set; } = name;
    public string Region { get; private set; } = region;
    public int Population { get; private set; } = population;
    public int Area { get; private set; } = area;
    public double PopulationDensity { get; private set; } = density;
    public double CoastLine { get; private set; } = coast;
    public double? NetMigration { get; private set; } = migration;
    public double? InfantMortality { get; private set; } = infantMorality;
    public int Gdp { get; private set; } = gdp;
    public double? LiteracyPercent { get; private set; } = literacy;
    public double? Phones { get; private set; } = phones;
    public double? BirthRate { get; private set; } = birth;
    public double? DeathRate { get; private set; } = death;
}