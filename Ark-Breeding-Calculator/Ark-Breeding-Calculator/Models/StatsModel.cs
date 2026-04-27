namespace Ark_Breeding_Calculator.Models
{
    public class StatsModel
    {
        // Stats
        private double _health;
        private double _stamina;
        private double _oxygen;
        private double _food;
        private double _water;
        private double _weight;
        private double _melee;
        private double _movementSpeed;

        // Stats
        public double Health { get { return _health; } set { _health = value; } }
        public double Stamina { get { return _stamina; } set { _stamina = value; } }
        public double Oxygen { get { return _oxygen; } set { _oxygen = value; } }
        public double Food { get { return _food; } set { _food = value; } }
        public double Water { get { return _water; } set { _water = value; } }
        public double Weight { get { return _weight; } set { _weight = value; } }
        public double Melee { get { return _melee; } set { _melee = value; } }
        public double MovementSpeed { get { return _movementSpeed; } set { _movementSpeed = value; } }
    }
}
