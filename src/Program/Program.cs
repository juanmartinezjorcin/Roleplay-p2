using System;
using System.Text;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SpellsBook book = new SpellsBook();
            book.AddSpell(new Fireball());
            book.AddSpell(new Thunder());

            Hero gandalf = new Wizard("Mago");
            gandalf.AddItem(book); 


            Foe goblin = new Goblin();
            Foe goblin1 = new Goblin();
            Foe goblin2 = new Goblin();
            Foe goblin3 = new Goblin();
            Foe goblin4 = new Goblin();
            Foe goblin5 = new Goblin();

            Foe golem = new Golem();

            HeroVSFoe HvF = new HeroVSFoe();
            HvF.AddCharacter(goblin);
            HvF.AddCharacter(goblin1);
            HvF.AddCharacter(goblin2);
            HvF.AddCharacter(goblin3);
            HvF.AddCharacter(goblin4);
            HvF.AddCharacter(goblin5);
            HvF.AddCharacter(golem);

            HvF.AddCharacter(gandalf);

            HvF.DoEncounter();

        }
    }
}
