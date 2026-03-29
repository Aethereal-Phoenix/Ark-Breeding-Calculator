namespace Ark_Breeding_Calculator
{
    public class DinoStateService
    {
        // Internal list (the actual storage)
        private readonly List<Dinosaur> _dinosaurs = new();

        // Public read-only access
        public IReadOnlyList<Dinosaur> Dinosaurs => _dinosaurs;

        // Event for UI updates
        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        // Constructor (optional seed data for testing)
        public DinoStateService()
        {
            SeedTestData();
        }

        // Add a dinosaur
        public void Add(Dinosaur dino)
        {
            if (dino == null) return;

            _dinosaurs.Add(dino);
            NotifyStateChanged();
        }

        // Remove a dinosaur
        public void Remove(Dinosaur dino)
        {
            if (dino == null) return;

            _dinosaurs.Remove(dino);
            NotifyStateChanged();
        }

        // Remove by index (useful sometimes)
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _dinosaurs.Count) return;

            _dinosaurs.RemoveAt(index);
            NotifyStateChanged();
        }

        // Clear all dinosaurs
        public void Clear()
        {
            _dinosaurs.Clear();
            NotifyStateChanged();
        }

        // Optional helper: find by name
        public Dinosaur? GetByName(string name)
        {
            return _dinosaurs.FirstOrDefault(d => d.Name == name);
        }

        // Optional: replace entire list (useful later for loading data)
        public void SetAll(IEnumerable<Dinosaur> dinos)
        {
            _dinosaurs.Clear();
            _dinosaurs.AddRange(dinos);
            NotifyStateChanged();
        }

        // Seed data for testing
        private void SeedTestData()
        {
            _dinosaurs.AddRange(new List<Dinosaur>
            {
                new Dinosaur
                {
                    Species = Species.Rex,
                    Health = 10000,
                    Stamina = 11000,
                    Oxygen = 12000,
                    Food = 13000,
                    Water = 14000,
                    Weight = 15000,
                    Melee = 16000,
                    MovementSpeed = 17000,
                    Gender = Gender.Male
                },
                new Dinosaur
                {
                    Species = Species.Rex,
                    Health = 9000,
                    Stamina = 12000,
                    Oxygen = 8000,
                    Food = 14000,
                    Water = 7000,
                    Weight = 16000,
                    Melee = 6000,
                    MovementSpeed = 17000,
                    Gender = Gender.Female
                }
            });
        }
    }// End of DinoStateService class
}
