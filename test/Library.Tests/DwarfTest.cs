using NUnit.Framework;
using RoleplayGame;

namespace RoleplayGameTests
{
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
    }
}
