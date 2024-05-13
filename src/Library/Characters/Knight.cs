using System;

namespace RoleplayGame
{
    public class Knight : ICharacter
    {
        private int health = 180;

        public Knight(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public Sword Sword { get; set; }

        public Shield Shield { get; set; }

        public Armor Armor { get; set; }

        public Iitem OtherItem { get; set; }

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
                if(value < 0) //revisamos que el valor si el valor menor a 0 y si lo es cambio health
                {
                this.health = 0;
                }
                else // si no es menor a 0
                {
                this.health = value > 180 ? 180 : value; // veo que no supere el valor maximo de salud de la clase
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
                if (item is Sword && this.Sword == null)// veo que tipo de objeto es item y si hay un item equipado
                {
                    this.Sword = (Sword)item;
                }
                else if (item is Shield && this.Shield == null)
                {
                    this.Shield = (Shield)item;
                }
                else if (item is Armor && this.Armor == null)
                {
                    this.Armor = (Armor)item;
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
            if (item is Sword && this.Sword == item)//verifico el tipo del item y que no halla ningun otro equipado
            {
                this.Sword = null;
            }
            else if (item is Armor && this.Armor == item)
            {
                this.Armor = null;
            }
            else if (item is Shield && this.Shield == item)
            {
                this.Shield = null;
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