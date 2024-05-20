using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace RoleplayGame
{
    public class EncounterTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Curar()
        {
            Dwarf gimli = new Dwarf("Gimli");
            gimli.Cure();
            Assert.That(gimli.Health, Is.EqualTo(200));
            
        }

        [Test]
        public void HeroWins()
        {
            SpellsBook book2 = new SpellsBook();
            book2.AddSpell(new Fireball());
            book2.AddSpell(new Thunder());

            Hero gandalf = new Wizard("Gandalf");
            gandalf.AddItem(book2);
            gandalf.AddItem(new Staff());
            gandalf.AddItem(new Staff());

            Hero legolas = new Archer("Legolas");
            legolas.AddItem(new Bow());
            legolas.AddItem(new Bow());
            legolas.AddItem(new Bow());
            legolas.AddItem(new Bow());

            Foe goblin = new Goblin();

            HeroVSFoe encounter = new HeroVSFoe();
            encounter.AddCharacter(gandalf);
            encounter.AddCharacter(goblin);
            encounter.AddCharacter(legolas);

            Assert.That(encounter.foes[0].Name == "Goblin");
            Assert.That(encounter.heroes[0].Name == "Gandalf");
            Assert.That(encounter.heroes[1].Name == "Legolas");
        
            encounter.DoEncounter(); 
        
            //Assert.That(encounter.DoEncounter(), "Heroes wins!");
        }
        
        [Test]
        public void Foes()
        {
            Hero knight = new Knight("Faramir");
            
            Foe goblin = new Goblin();
            Foe golem = new Golem();

            goblin.AddItem(new Axe());
            goblin.AddItem(new Axe());
            goblin.AddItem(new Axe());

            golem.AddItem(new Sword());
            golem.AddItem(new Sword());
            golem.AddItem(new Sword());

            HeroVSFoe encounter = new HeroVSFoe();
            encounter.AddCharacter(knight);
            encounter.AddCharacter(goblin);
            encounter.AddCharacter(golem);

            Assert.That(encounter.foes[0].Name == "Goblin");
            Assert.That(encounter.foes[1].Name == "Golem");
            Assert.That(encounter.heroes[0].Name == "Faramir");
            
            encounter.DoEncounter(); 
            
            //Assert.That(encounter.DoEncounter(), "Foes wins!");
        } 
        
    }
}