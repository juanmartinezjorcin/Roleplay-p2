using NUnit.Framework;
using System;
using RoleplayGame;

namespace RoleplayGameTests
{
    public class UnitTests
    {
        [Test]
        public void TestWizardCure()
        {
            Wizard wizard = new Wizard("Test Wizard");
            wizard.Health = 50; // Establece la salud inicial del mago en 50
            wizard.Cure(50); // Curar al mago con 50 de salud
            Assert.AreEqual(100, wizard.Health); // Verifica que la salud del mago haya sido restaurada a 100 después de curar
        }

        [Test]
        public void TestWizardShowStats()
        {
            // Arrange
            Wizard wizard = new Wizard("Test Wizard");
            wizard.Health = 80; // Establece la salud del mago en 80

            // Act
            string expectedStats = $"|\nv\nTest Wizard\n\tSalud: 80\n\tDefensa: 0\n\tAtaque: 0\n";
            string actualStats = CaptureConsoleOutput(() => wizard.ShowStats());

            // Assert
            Assert.AreEqual(expectedStats, actualStats); // Verifica que la salida coincida con las estadísticas esperadas
        }

        [Test]
        public void TestWizardGetItem()
        {
            // Arrange
            Wizard wizard = new Wizard("Test Wizard");
            SpellsBook spellsBook = new SpellsBook();

            // Act
            wizard.GetItem(spellsBook);

            // Assert
            Assert.AreSame(spellsBook, wizard.SpellsBook); // Verifica que el mago haya equipado el libro de hechizos correctamente
        }

        [Test]
        public void TestWizardRemoveItem()
        {
            // Arrange
            Wizard wizard = new Wizard("Test Wizard");
            SpellsBook spellsBook = new SpellsBook();
            wizard.GetItem(spellsBook); // Equipa un libro de hechizos al mago

            // Act
            wizard.RemoveItem(spellsBook);

            // Assert
            Assert.IsNull(wizard.SpellsBook); // Verifica que el libro de hechizos haya sido eliminado correctamente del inventario del mago
        }

        [Test]
        public void TestWizardAttackValue()
        {
            // Arrange
            Wizard wizard = new Wizard("Test Wizard");
            SpellsBook spellsBook = new SpellsBook();
            Staff staff = new Staff();
            wizard.GetItem(spellsBook); // Equipa un libro de hechizos al mago
            wizard.GetItem(staff); // Equipa un bastón al mago

            // Act
            int attackValue = wizard.AttackValue;

            // Assert
            Assert.AreEqual(spellsBook.AttackValue + staff.AttackValue, attackValue); // Verifica que el valor de ataque del mago sea igual a la suma de los valores de ataque del libro de hechizos y el bastón
        }

        [Test]
        public void TestWizardDefenseValue()
        {
            // Arrange
            Wizard wizard = new Wizard("Test Wizard");
            SpellsBook spellsBook = new SpellsBook();
            Staff staff = new Staff();
            wizard.GetItem(spellsBook); // Equipa un libro de hechizos al mago
            wizard.GetItem(staff); // Equipa un bastón al mago

            // Act
            int defenseValue = wizard.DefenseValue;

            // Assert
            Assert.AreEqual(spellsBook.DefenseValue + staff.DefenseValue, defenseValue); // Verifica que el valor de defensa del mago sea igual a la suma de los valores de defensa del libro de hechizos y el bastón
        }

        [Test]
        public void TestKnightCure()
        {
            Knight knight = new Knight("Test Knight");
            knight.Health = 50; // Establece la salud inicial del caballero en 50
            knight.Cure(50); // Curar al caballero con 50 de salud
            Assert.AreEqual(100, knight.Health); // Verifica que la salud del caballero haya sido restaurada a 100 después de curar
        }

        [Test]
        public void TestKnightShowStats()
        {
            Knight knight = new Knight("Test Knight");
            knight.Health = 120;
            string expectedStats = $"|\nv\nTest Knight\n\tSalud: 120\n\tDefensa: 0\n\tAtaque: 0\n";
            string actualStats = CaptureConsoleOutput(() => knight.ShowStats());
            Assert.AreEqual(expectedStats, actualStats); 

        [Test]
        public void TestKnightGetItem()
        {
            // Arrange
            Knight knight = new Knight("Test Knight");
            Sword sword = new Sword();

            // Act
            knight.GetItem(sword);

            // Assert
            Assert.AreSame(sword, knight.Sword); // Verifica que el caballero haya equipado la espada correctamente
        }

        [Test]
        public void TestKnightGetMagicItem()
        {
            // Arrange
            Knight knight = new Knight("Test Knight");
            SpellsBook spellsBook = new SpellsBook(); // Supongamos que SpellsBook es una clase que representa un libro de hechizos

            // Act
            knight.GetItem(spellsBook);

            // Assert
            Assert.IsNull(knight.OtherItem); // Verifica que el libro de hechizos no se haya equipado correctamente en el caballero
        }

        [Test]
        public void TestKnightRemoveItem()
        {
            // Arrange
            Knight knight = new Knight("Test Knight");
            Sword sword = new Sword();
            knight.GetItem(sword); // Equipa una espada al caballero

            // Act
            knight.RemoveItem(sword);

            // Assert
            Assert.IsNull(knight.Sword); // Verifica que la espada haya sido eliminada correctamente del inventario del caballero
        }

        [Test]
        public void TestKnightAttackValue()
        {
            // Arrange
            Knight knight = new Knight("Test Knight");
            Sword sword = new Sword();
            knight.GetItem(sword); // Equipa una espada al caballero

            // Act
            int attackValue = knight.AttackValue;

            // Assert
            Assert.AreEqual(sword.AttackValue, attackValue); // Verifica que el valor de ataque del caballero sea igual al valor de ataque de la espada
        }

        [Test]
        public void TestKnightDefenseValue()
        {
            // Arrange
            Knight knight = new Knight("Test Knight");
            Shield shield = new Shield();
            Armor armor = new Armor();
            knight.GetItem(shield); // Equipa un escudo al caballero
            knight.GetItem(armor); // Equipa una armadura al caballero

            // Act
            int defenseValue = knight.DefenseValue;

            // Assert
            Assert.AreEqual(shield.DefenseValue + armor.DefenseValue, defenseValue); // Verifica que el valor de defensa del caballero sea igual a la suma de los valores de defensa del escudo y la armadura
        }
    }
    public class DwarfTests
    {
        [Test]
        public void TestDwarfCure()
        {
            Dwarf dwarf = new Dwarf("Test Dwarf");
            dwarf.Health = 50; // Establece la salud inicial del enano en 50
            dwarf.Cure(50); // Curar al enano con 50 de salud
            Assert.AreEqual(100, dwarf.Health); // Verifica que la salud del enano haya sido restaurada a 100 después de curar
        }

        [Test]
        public void TestDwarfShowStats()
        {
            // Arrange
            Dwarf dwarf = new Dwarf("Test Dwarf");
            dwarf.Health = 80; // Establece la salud del enano en 80

            // Act
            string expectedStats = $"|\nv\nTest Dwarf\n\tSalud: 80\n\tDefensa: 0\n\tAtaque: 0\n";
            string actualStats = CaptureConsoleOutput(() => dwarf.ShowStats());

            // Assert
            Assert.AreEqual(expectedStats, actualStats); // Verifica que la salida coincida con las estadísticas esperadas
        }

        [Test]
        public void TestDwarfGetItem()
        {
            // Arrange
            Dwarf dwarf = new Dwarf("Test Dwarf");
            Axe axe = new Axe();

            // Act
            dwarf.GetItem(axe);

            // Assert
            Assert.AreSame(axe, dwarf.Axe); // Verifica que el enano haya equipado el hacha correctamente
        }
        
        [Test]
        public void TestKnightGetMagicItem()
        {
            // Arrange
            Dwarf dwarf = new Dwarf("Test Dwarf");
            SpellsBook spellsBook = new SpellsBook(); // Supongamos que SpellsBook es una clase que representa un libro de hechizos

            // Act
            dwarf.GetItem(spellsBook);

            // Assert
            Assert.IsNull(dwarf.OtherItem); // Verifica que el libro de hechizos no se haya equipado correctamente en el caballero
        }


        [Test]
        public void TestDwarfRemoveItem()
        {
            // Arrange
            Dwarf dwarf = new Dwarf("Test Dwarf");
            Axe axe = new Axe();
            dwarf.GetItem(axe); // Equipa un hacha al enano

            // Act
            dwarf.RemoveItem(axe);

            // Assert
            Assert.IsNull(dwarf.Axe); // Verifica que el hacha haya sido eliminada correctamente del inventario del enano
        }

         [Test]
        {
            // Arrange
            Dwarf dwarf = new Dwarf("Test Dwarf");
            Axe axe = new Axe();
            dwarf.GetItem(axe); // Equipa un hacha al enano
            
            // Act
            int attackValue = dwarf.AttackValue;
            
            // Assert
            Assert.AreEqual(axe.AttackValue, attackValue); // Verifica que el valor de ataque del enano sea igual al valor de ataque del hacha
        }

        [Test]
        public void TestDwarfDefenseValue()
        {
            // Arrange
            Dwarf dwarf = new Dwarf("Test Dwarf");
            Shield shield = new Shield();
            Helmet helmet = new Helmet();
            dwarf.GetItem(shield); // Equipa un escudo al enano
            dwarf.GetItem(helmet); // Equipa un casco al enano
            
            // Act
            int defenseValue = dwarf.DefenseValue;
            
            // Assert
            Assert.AreEqual(shield.DefenseValue + helmet.DefenseValue, defenseValue); // Verifica que el valor de defensa del enano sea igual a la suma de los valores de defensa del escudo y el casco
        }

        [Test]
        public void TestArcherCure()
        {
            Archer archer = new Archer("Test Archer");
            archer.Health = 50; // Establece la salud inicial del arquero en 50
            archer.Cure(50); // Curar al arquero con 50 de salud
            Assert.AreEqual(100, archer.Health); // Verifica que la salud del arquero haya sido restaurada a 100 después de curar
        }

        [Test]
        public void TestArcherShowStats()
        {
            // Arrange
            Archer archer = new Archer("Test Archer");
            archer.Health = 80; // Establece la salud del arquero en 80

            // Act
            string expectedStats = $"|\nv\nTest Archer\n\tSalud: 80\n\tDefensa: 0\n\tAtaque: 0\n";
            string actualStats = CaptureConsoleOutput(() => archer.ShowStats());

            // Assert
            Assert.AreEqual(expectedStats, actualStats); // Verifica que la salida coincida con las estadísticas esperadas
        }

        [Test]
        public void TestArcherGetItem()
        {
            // Arrange
            Archer archer = new Archer("Test Archer");
            Bow bow = new Bow();

            // Act
            archer.GetItem(bow);

            // Assert
            Assert.AreSame(bow, archer.Bow); // Verifica que el arquero haya equipado el arco correctamente
        }
        
        [Test]
        public void TestKnightGetMagicItem()
        {
            // Arrange
            Archer archer = new Archer("Test Archer");
            SpellsBook spellsBook = new SpellsBook(); // Supongamos que SpellsBook es una clase que representa un libro de hechizos

            // Act
            archer.GetItem(spellsBook);

            // Assert
            Assert.IsNull(archer.OtherItem); // Verifica que el libro de hechizos no se haya equipado correctamente en el caballero
        }

        [Test]
        public void TestArcherRemoveItem()
        {
            // Arrange
            Archer archer = new Archer("Test Archer");
            Bow bow = new Bow();
            archer.GetItem(bow); // Equipa un arco al arquero

            // Act
            archer.RemoveItem(bow);

            // Assert
            Assert.IsNull(archer.Bow); // Verifica que el arco haya sido eliminado correctamente del inventario del arquero
        }

        [Test]
        public void TestArcherAttackValue()
        {
            // Arrange
            Archer archer = new Archer("Test Archer");
            Bow bow = new Bow();
            archer.GetItem(bow); // Equipa un arco al arquero

            // Act
            int attackValue = archer.AttackValue;

            // Assert
            Assert.AreEqual(bow.AttackValue, attackValue); // Verifica que el valor de ataque del arquero sea igual al valor de ataque del arco
        }

        [Test]
        public void TestArcherDefenseValue()
        {
            // Arrange
            Archer archer = new Archer("Test Archer");
            Helmet helmet = new Helmet();
            archer.GetItem(helmet); // Equipa un casco al arquero

            // Act
            int defenseValue = archer.DefenseValue;

            // Assert
            Assert.AreEqual(helmet.DefenseValue, defenseValue); // Verifica que el valor de defensa del arquero sea igual al valor de defensa del casco
        }
    }
}
