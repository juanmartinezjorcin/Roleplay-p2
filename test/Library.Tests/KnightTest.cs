using NUnit.Framework;
using RoleplayGame;

namespace RoleplayGameTests
{
    public class KnightTests
    {
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
            // Arrange
            Knight knight = new Knight("Test Knight");
            knight.Health = 120; // Establece la salud del caballero en 120

            // Act
            string expectedStats = $"|\nv\nTest Knight\n\tSalud: 120\n\tDefensa: 0\n\tAtaque: 0\n";
            string actualStats = CaptureConsoleOutput(() => knight.ShowStats());

            // Assert
            Assert.AreEqual(expectedStats, actualStats); // Verifica que la salida coincida con las estadísticas esperadas
        }

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
}
