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
        // Method to add a dino to a breeding line or create one if needed
        public void AddDinoToLine(Guid? lineId, DinosaurModel dino)
        {
            if (dino == null) return;

            if (lineId == null)
            {
                BreedingLineModel newLine = new BreedingLineModel
                {
                    Name = dino.Species.ToString(),
                    Species = dino.Species
                };

                _breedingLines.Add(newLine);
                newLine.Dinosaurs.Add(dino);
            }
            else
            {
                BreedingLineModel? line = _breedingLines.FirstOrDefault(lines => lines.Id == lineId);
                if (line == null) return;

                line.Dinosaurs.Add(dino);
            }

            NotifyStateChanged();
        }

        public void RemoveDinoFromLine(Guid lineId, DinosaurModel dino)
        {
            var line = _breedingLines.FirstOrDefault(l => l.Id == lineId);
            if (line == null || dino == null) return;

            line.Dinosaurs.Remove(dino);
            NotifyStateChanged();
        }

        public IEnumerable<DinosaurModel> GetBySpecies(SpeciesEnumModel species)
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
                Species = SpeciesEnumModel.Rex,
                Dinosaurs = new List<DinosaurModel>
                {
                    new DinosaurModel {
                        Species = SpeciesEnumModel.Rex,
                        Gender = GenderEnumModel.Male,
                        MutatedStat = MutationStatsEnumModel.None,
                        GenerationNumber = 0,
                        GenerationType = PrimaryGenerationsEnumModel.WildCaught,
                        Stats = new StatsModel{
                            Health = 10000,
                            Stamina = 11000,
                            Oxygen = 12000,
                            Food = 13000,
                            Water = 14000,
                            Weight = 15000,
                            Melee = 16000 ,
                            MovementSpeed = 17000 }
                    },
                    new DinosaurModel {
                        Species = SpeciesEnumModel.Rex,
                        Gender = GenderEnumModel.Female,
                        MutatedStat = MutationStatsEnumModel.None,
                        GenerationNumber = 0,
                        GenerationType = PrimaryGenerationsEnumModel.WildCaught,
                        Stats = new StatsModel{
                            Health = 10000,
                            Stamina = 11000,
                            Oxygen = 12000,
                            Food = 13000,
                            Water = 14000,
                            Weight = 15000,
                            Melee = 16000 ,
                            MovementSpeed = 17000 },
                    }
                }
            };

            BreedingLineModel shadowmaneLine = new BreedingLineModel
            {
                Name = "Shadowmane Line",
                Species = SpeciesEnumModel.Shadowmane,
                Dinosaurs = new List<DinosaurModel>
                {
                    new DinosaurModel {
                        Species = SpeciesEnumModel.Shadowmane,
                        Gender = GenderEnumModel.Male,
                        MutatedStat = MutationStatsEnumModel.None,
                        GenerationNumber = 0,
                        GenerationType = PrimaryGenerationsEnumModel.WildCaught,
                        Stats = new StatsModel{
                            Health = 10000,
                            Stamina = 11000,
                            Oxygen = 12000,
                            Food = 13000,
                            Water = 14000,
                            Weight = 15000,
                            Melee = 16000 ,
                            MovementSpeed = 17000 },
                    },
                    new DinosaurModel {
                        Species = SpeciesEnumModel.Shadowmane,
                        Gender = GenderEnumModel.Female,
                        MutatedStat = MutationStatsEnumModel.None,
                        GenerationNumber = 0,
                        GenerationType = PrimaryGenerationsEnumModel.WildCaught,
                        Stats = new StatsModel{
                            Health = 10000,
                            Stamina = 11000,
                            Oxygen = 12000,
                            Food = 13000,
                            Water = 14000,
                            Weight = 15000,
                            Melee = 16000 ,
                            MovementSpeed = 17000 },
                    }
                }
            };

            _breedingLines.Add(rexLine);
            _breedingLines.Add(shadowmaneLine);
        }


    }// End of DinoStateService class
}
