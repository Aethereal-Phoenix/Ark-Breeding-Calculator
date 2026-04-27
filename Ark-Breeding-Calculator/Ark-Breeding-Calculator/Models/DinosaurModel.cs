namespace Ark_Breeding_Calculator.Models
{
    public class DinosaurModel
    {
        #region Private Properties
        // General information
        private string _name;
        private SpeciesEnumModel _species;
        private GenderEnumModel _gender;
        private bool _mutated;
        private MutationStatsEnumModel _mutatedStat;
        private MutationGenerationEnumModel _generationNumber;
        private PrimaryGenerationsEnumModel _generationType;
        private StatsModel _stats;
        #endregion

        #region Public Properties
        // General information
        public string Name { get { return _name; } set => GenerateName(); }
        public SpeciesEnumModel Species { get { return _species; } set { _species = value; } }
        public GenderEnumModel Gender { get { return _gender; } set { _gender = value; } }
        public bool Mutated { get { return _mutated; } set { _mutated = value; } }
        public MutationStatsEnumModel MutatedStat { get { return _mutatedStat; } set { _mutatedStat = value; }  }
        public MutationGenerationEnumModel GenerationNumber {  get { return _generationNumber; } set { _generationNumber = value; } }
        public PrimaryGenerationsEnumModel GenerationType { get { return _generationType; } set { _generationType = value; } }
        public StatsModel Stats { get { return _stats; } set { _stats = value; } }
        #endregion

        #region Constructors
        public DinosaurModel()
        {
            Stats = new StatsModel();
        }
        #endregion

        #region Methods
        public string GenerationName()
        {
            return "";
        }
        public string GenerateName()
        {
            string name = $"{_species} {_gender} ";

            return name;
        }
        #endregion
    }// End of Dinosaur Class
}
