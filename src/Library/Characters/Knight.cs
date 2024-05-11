using System;

namespace RoleplayGame
{
    public class Knight : ICharacter
    {
        private int health = 100;

        public Knight(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public Sword Sword { get; set; }

        public Shield Shield { get; set; }

        public Armor Armor { get; set; }

        public int AttackValue
        {
            get
            {
                return Sword.AttackValue;
            }
        }

        public int DefenseValue
        {
            get
            {
                return Armor.DefenseValue + Shield.DefenseValue;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
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
            if (character.DefenseValue >= this.AttackValue) // Verificar si el ataque supera la defensa
            {
                Console.WriteLine( $"{this.Name} no dañó a {character.Name}");
            }
            else
            {
                int damage = this.AttackValue - character.DefenseValue; // Calcular el daño
                character.Health -= damage; // Restar el daño de la salud del elfo

                if (character.Health <= 0) // Verificar si el personaje sobrevivio está muerto
                {
                    Console.WriteLine( $"{character.Name} fue asesinado por {this.Name}" );
                }
                else
                {
                    Console.WriteLine( $"{character.Name} perdió {damage} de vida por el ataque de {this.Name}" );
                }
            }
        }
        public void Cure()
        {
            this.Health = 100;
        }
    }
}