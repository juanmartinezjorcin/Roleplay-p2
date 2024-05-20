using System;

namespace RoleplayGame
{
    public abstract class Hero : Character
    {
        public  Hero () : base()
        {
            this.VP = 0;
        }
        public void checkForVP(Character character)
        {
            if (character.Health == 0)
            {
                this.VP += character.VP;
                Console.WriteLine($"{this.Name} defeated {character.Name} and earned: 🌟 {character.VP} victory points!");
            }
        }
    }
        
}
