using Ark_Breeding_Calculator.Models;

namespace Ark_Breeding_Calculator.Services
{
    public class DinoStateService
    {
        // Internal readonly list of all breeding lines
        private readonly List<BreedingLineModel> _breedingLines = new();

        // Public readonly list of all breeding lines
        public IReadOnlyList<BreedingLineModel> BreedingLines => _breedingLines;

        // Event for UI updates
        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        // Constructor (optional seed data for testing)
        public DinoStateService()
        {
            SeedTestData();
        }

        // Add a dinosaur
        public void AddBreedingLine(BreedingLineModel line)
        {
            if (line == null) return;

            _breedingLines.Add(line);
            NotifyStateChanged();
        }

        // Remove a dinosaur
        public void RemoveBreedingLine(Guid lineId)
        {
            var line = _breedingLines.FirstOrDefault(l => l.Id == lineId);
            if (line == null) return;

            _breedingLines.Remove(line);
            NotifyStateChanged();
        }

        public void AddDinoToLine(Guid lineId, DinosaurModel dino)
        {
            var line = _breedingLines.FirstOrDefault(l => l.Id == lineId);
            if (line == null || dino == null) return;

            line.Dinosaurs.Add(dino);
            NotifyStateChanged();
        }

        public void RemoveDinoFromLine(Guid lineId, DinosaurModel dino)
        {
            var line = _breedingLines.FirstOrDefault(l => l.Id == lineId);
            if (line == null || dino == null) return;

            line.Dinosaurs.Remove(dino);
            NotifyStateChanged();
        }

        public IEnumerable<DinosaurModel> GetBySpecies(Species species)
        {
            return _breedingLines
                .Where(l => l.Species == species)
                .SelectMany(l => l.Dinosaurs);
        }

        // Seed data for testing
        private void SeedTestData()
        {
            BreedingLineModel rexLine = new BreedingLineModel
            {
                Name = "Rex Line",
                Species = Species.Rex,
                Dinosaurs = new List<DinosaurModel>
                {
                    new DinosaurModel { 
                        Species = Species.Rex,
                        Health = 10000,
                        Stamina = 11000,
                        Oxygen = 12000,
                        Food = 13000,
                        Water = 14000,
                        Weight = 15000,
                        Melee = 16000,
                        MovementSpeed = 17000,
                        Gender = Gender.Male },
                    new DinosaurModel { 
                        Species = Species.Rex, 
                        Health = 10000,
                        Stamina = 11000,
                        Oxygen = 12000,
                        Food = 13000,
                        Water = 14000,
                        Weight = 15000,
                        Melee = 16000,
                        MovementSpeed = 17000, 
                        Gender = Gender.Female }
                }
            };

            BreedingLineModel shadowmaneLine = new BreedingLineModel
            {
                Name = "Shadowmane Line",
                Species = Species.Shadowmane,
                Dinosaurs = new List<DinosaurModel>
                {
                    new DinosaurModel { 
                        Species = Species.Shadowmane,
                        Health = 10000, 
                        Stamina = 11000, 
                        Oxygen = 12000, 
                        Food = 13000, 
                        Water = 14000, 
                        Weight = 15000, 
                        Melee = 16000, 
                        MovementSpeed = 17000,
                        Gender = Gender.Male },
                    new DinosaurModel { 
                        Species = Species.Shadowmane,
                        Health = 10000,
                        Stamina = 11000,
                        Oxygen = 12000,
                        Food = 13000,
                        Water = 14000,
                        Weight = 15000,
                        Melee = 16000,
                        MovementSpeed = 17000,
                        Gender = Gender.Female }
                }
            };

            _breedingLines.Add(rexLine);
            _breedingLines.Add(shadowmaneLine);
        }
    }// End of DinoStateService class
}
