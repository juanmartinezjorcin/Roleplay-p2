using System;

namespace RoleplayGame
{
    public class Wizard : ICharacter
    {
        private int health = 100;

        public Wizard(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public SpellsBook SpellsBook { get; set; }

        public Staff Staff { get; set; }

        public int AttackValue
        {
            get
            {
                return SpellsBook.AttackValue + Staff.AttackValue;
            }
        }

        public int DefenseValue
        {
            get
            {
                return SpellsBook.DefenseValue + Staff.DefenseValue;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        public void ShowStats()
        {
            // Su nombre.
            Console.WriteLine($"|\nv\n{this.Name}");
            // Su salud.
            Console.WriteLine($"\tSalud: {this.Health}");
            // Su defensa.
            Console.WriteLine($"\tDefensa: {this.DefenseValue}");
            // Su ataque.
            Console.WriteLine($"\tAtaque: {this.AttackValue}\n");
        }

        public void Attack(ICharacter character)
        {
            if (elf.Defense >= this.Attack) // Verificar si el ataque supera la defensa del elfo
            {
                return $"{this.Name} no dañó a {elf.Name}";
            }
            else
            {
                int damage = this.Attack - character.DefenseValue; // Calcular el daño
                elf.Health -= damage; // Restar el daño de la salud del elfo

                if (elf.Health <= 0) // Verificar si el elfo está muerto
                {
                    return $"{elf.Name} fue asesinado por {wizard.Name}";
                }
                else
                {
                    return $"{elf.Name} perdió {damage} de vida por el ataque de {wizard.Name}";
                }
            }
        }

        public void Cure()
        {
            this.Health = 100;
        }
    }
}