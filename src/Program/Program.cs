using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            SpellsBook book = new SpellsBook();
            book.Spells = new Spell[]{ new Spell() };

            Wizard gandalf = new Wizard("Gandalf");
            Staff staff = new Staff();
            gandalf.GetItem(staff);
            gandalf.SpellsBook = book;

            Dwarf gimli = new Dwarf("Gimli");
            Axe axe = new Axe();
            gimli.GetItem(new Axe());
            Helmet helmet = new Helmet();
            gimli.GetItem(helmet);
            Shield shield = new Shield();
            gimli.GetItem(new Shield());

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
            Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.AttackValue}");

            gandalf.Attack(gimli);

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

            gimli.Cure(int.MaxValue);

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
        }
    }
}
