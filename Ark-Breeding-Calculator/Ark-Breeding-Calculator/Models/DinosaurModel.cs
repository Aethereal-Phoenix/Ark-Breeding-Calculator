namespace Ark_Breeding_Calculator.Models
{
    public class DinosaurModel
    {
        #region Private Properties
        // General information
        private Species _species;
        private string _name;
        private Gender _gender;

        // Stats
        private double _health;
        private double _stamina;
        private double _oxygen;
        private double _food;
        private double _water;
        private double _weight;
        private double _melee;
        private double _movementSpeed;

        // The generation of the Dinosaur
        private GenerationsEnumModel _generation;
        #endregion

        #region Public Properties
        // General information
        public Species Species { get { return _species; } set { _species = value; } }
        public string Name => GenerateName();
        public Gender Gender { get { return _gender; } set { _gender = value; } }

        // Stats
        public double Health { get { return _health; } set { _health = value; } }
        public double Stamina { get { return _stamina; } set { _stamina = value; } }
        public double Oxygen { get { return _oxygen; } set { _oxygen = value; } }
        public double Food { get { return _food; } set { _food = value; } }
        public double Water { get { return _water; } set { _water = value; } }
        public double Weight { get { return _weight; } set { _weight = value; } }
        public double Melee { get { return _melee; } set { _melee = value; } }
        public double MovementSpeed { get { return _movementSpeed; } set { _movementSpeed = value; } }

        // Generation of the Dinosaur
        public GenerationsEnumModel Generation { get { return _generation; } set { _generation = value; } }
        #endregion

        #region Constructors
        public DinosaurModel()
        {
            // Default Constructor
        }
        #endregion

        #region Methods
        public string GenerateName()
        {
            return $"{Generation} {Gender}";
        }
        #endregion
    }// End of Dinosaur Class
}
