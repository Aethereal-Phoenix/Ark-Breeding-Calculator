namespace Ark_Breeding_Calculator
{
    public class DefaultData
    {
        private List<Dinosaur> _dinoList;

        public List<Dinosaur> DinoList = new()
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
        };
    }
}
