using System;

namespace RoleplayGame 
{
    public class Archer : Hero
    {
        private int health = 120;

        public Archer(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        
        public Bow Bow { get; set; }

        public Helmet Helmet { get; set; }

        public Iitem OtherItem { get; set; }

        public int AttackValue
        {
            get
            {
                return Bow.AttackValue;
            }
        }

        public int DefenseValue
        {
            get
            {
                return Helmet.DefenseValue;
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
                if(value < 0)
                {
                this.health = 0;
                }
                else
                {
                this.health = value > 150 ? 150 : value;
                }
                
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

        public void Cure(int curacion)
        {
            this.Health += curacion;
        }

        public void GetItem(Iitem item)
        {
            if (item.itsMagic)
            {
                Console.WriteLine("El personaje no puede equipar este item");
            
            }
            else
            {
                if (item is Bow && this.Bow == null)
                {
                    this.Bow = (Bow)item;
                }
                else if (item is Helmet && this.Helmet == null)
                {
                    this.Helmet = (Helmet)item;
                }
                else if (this.OtherItem == null)
                {
                this.OtherItem = item;
                }
                else
                {
                 Console.WriteLine("El personaje no puede equipar este item");
                }
            }
            
        }

        public void RemoveItem(Iitem item)
        {
            if (item is Helmet && this.Helmet == item)
            {
                this.Helmet = null;
            }
            else if (item is Bow && this.Bow == item)
            {
                this.Bow = null;
            }
            else if (this.OtherItem == item)
            {
                this.OtherItem = null;
            }
            else
            {
                Console.WriteLine("El objeto no está equipado en este personaje.");
            }
        }



    }
}