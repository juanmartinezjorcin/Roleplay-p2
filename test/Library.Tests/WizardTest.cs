using NUnit.Framework;
using RoleplayGame;

namespace RoleplayGameTests
{
    public class WizardTests
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
    }
}
