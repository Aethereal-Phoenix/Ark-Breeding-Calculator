namespace Ark_Breeding_Calculator.Models
{
    public class BreedingLineModel
    {
        // Private properties
        
        // Unique ID for every single breeding line 
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public SpeciesEnumModel Species { get; set; }
        // List of all Dinosaurs in the BreedingLine
        public List<DinosaurModel> Dinosaurs { get; set; } = new();
    }
}
