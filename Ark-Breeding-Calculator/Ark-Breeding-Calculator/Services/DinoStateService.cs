using Ark_Breeding_Calculator.Models;

namespace Ark_Breeding_Calculator.Services
{
    // Service that manages all breeding line state in-memory.
    // Acts as a central store for adding/removing lines and dinosaurs,
    // and notifies the UI when data changes.
    public class DinoStateService
    {
        // Internal mutable list of breeding lines
        private readonly List<BreedingLineModel> _breedingLines = new();

        // Public read-only view of breeding lines
        public IReadOnlyList<BreedingLineModel> BreedingLines => _breedingLines;

        // Event triggered whenever state changes (used to refresh UI)
        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();

        // Initialize with test data
        public DinoStateService()
        {
            SeedTestData();
        }

        // Adds a new breeding line
        public void AddBreedingLine(BreedingLineModel line)
        {
            if (line == null) return;

            _breedingLines.Add(line);
            NotifyStateChanged();
        }

        // Removes a breeding line by ID
        public void RemoveBreedingLine(Guid lineId)
        {
            var line = _breedingLines.FirstOrDefault(l => l.Id == lineId);
            if (line == null) return;

            _breedingLines.Remove(line);
            NotifyStateChanged();
        }

        // Adds a dinosaur to a specific breeding line
        public void AddDinoToLine(Guid lineId, DinosaurModel dino)
        {
            var line = _breedingLines.FirstOrDefault(l => l.Id == lineId);
            if (line == null || dino == null) return;

            line.Dinosaurs.Add(dino);
            NotifyStateChanged();
        }

        // Removes a dinosaur from a specific breeding line
        public void RemoveDinoFromLine(Guid lineId, DinosaurModel dino)
        {
            var line = _breedingLines.FirstOrDefault(l => l.Id == lineId);
            if (line == null || dino == null) return;

            line.Dinosaurs.Remove(dino);
            NotifyStateChanged();
        }

        // Returns all dinosaurs across all lines of a given species
        public IEnumerable<DinosaurModel> GetBySpecies(Species species)
        {
            return _breedingLines
                .Where(l => l.Species == species)
                .SelectMany(l => l.Dinosaurs);
        }

        #region Seed data for testing
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
        #endregion
    }// End of DinoStateService class
}
