namespace Ark_Breeding_Calculator.Models
{
    public class BreedingLineModel
    {
        // Private properties
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public Species Species { get; set; }

        public List<DinosaurModel> Dinosaurs { get; set; } = new();
    }
}
