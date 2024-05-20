using NUnit.Framework;
using System.Collections.Generic;

namespace RoleplayGame
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Curar()
        {
            Dwarf gimli = new Dwarf("Gimli");
            gimli.Cure();
            Assert.That(gimli.Health, Is.EqualTo(200));
            
        }
/*         [Test]
        public void Curar()
        {
            Dwarf gimli = new Dwarf("Gimli");
            gimli.Cure();
            Assert.That(gimli.Health, Is.EqualTo(100));
        } */
        [Test]
        public void Atacar()
        {
            SpellsBook book = new SpellsBook();
            book.AddSpell(new Fireball());
            book.AddSpell(new Thunder());

            Wizard gandalf = new Wizard("Gandalf");
            gandalf.AddItem(book);

            Dwarf gimli = new Dwarf("Gimli");

            /* gimli.DefenseItem = new List<IDefenseItem>() {new Helmet(), new Shield()} ;
            gimli.AttackItem = new Axe(); */
            

            int gimliStartHealth = gimli.Health;  // vida con la que arranca gimli
            
            //gimli.Attack(gandalf.AttackValue);
            gandalf.Attack(gimli);

            Assert.That(gimli.Health, Is.EqualTo(0));
            //Assert.That(gimli.Health, Is.EqualTo(gimliStartHealth -= gandalf.AttackValue - gimli.DefenseValue));
        }
        
        [Test]
        public void Test3()
        {
            Assert.Pass();
        }
        
        
    }

    
}