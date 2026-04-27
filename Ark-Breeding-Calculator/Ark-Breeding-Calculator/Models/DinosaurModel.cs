namespace Ark_Breeding_Calculator.Models
{
    public class DinosaurModel
    {
        #region Private Properties
        // General information
        private Species _species;
        private string _name;
        private Gender _gender;
        private MutationGeneration _generation;
        private bool _mutated;
        private StatsModel _stats;
        #endregion

        #region Public Properties
        // General information
        public Species Species { get { return _species; } set { _species = value; } }
        public string Name { get { return _name; } set => GenerateName(); }
        public Gender Gender { get { return _gender; } set { _gender = value; } }
        public MutationGeneration Generation {  get { return _generation; } set { _generation = value; } }
        public bool Mutated { get { return _mutated; } set { _mutated = value; }  }
        public StatsModel Stats { get { return _stats; } set { _stats = value; }  }
        #endregion

        #region Constructors
        public DinosaurModel()
        {
            // Default Constructor
        }
        #endregion

        #region Methods
        public string GenerationName()
        {
            return "";
        }
        public string GenerateName()
        {
            return $"{Generation} {Gender}";
        }
        #endregion
    }// End of Dinosaur Class
}
