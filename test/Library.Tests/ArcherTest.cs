using NUnit.Framework;
using RoleplayGame;

namespace RoleplayGameTests
{
    public class ArcherTests
    {
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
            knight.GetItem(spellsBook);

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
