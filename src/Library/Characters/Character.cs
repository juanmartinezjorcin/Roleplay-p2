using System;
using System.Collections.Generic;

namespace RoleplayGame
{
    //ejemplo documentacion diseño de clase base y derivada
    //https://learn.microsoft.com/es-es/dotnet/csharp/fundamentals/tutorials/inheritance
    public abstract class Character : ICharacter 
    {
        public int VP { get; set;}
        private int health = 100;
        protected List<IItem> items = new List<IItem>();

        public string Name { get; set; }
        
        public int AttackValue
        {
            //get item values
            get
            {
                int value = 0;
                foreach (IItem item in this.items)
                {
                    if (item is IAttackItem)
                    {
                        value += (item as IAttackItem).AttackValue;
                    }
                }
                return value;
            }
        }

        public int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in this.items)
                {
                    if (item is IDefenseItem)
                    {
                        value += (item as IDefenseItem).DefenseValue;
                    }
                }
                return value;
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


        public void Attack(ICharacter character)
        {
            if (character.DefenseValue < this.AttackValue)
            {
                Console.WriteLine($"{this.Name} attacks {character.Name} with 🗡️  {this.AttackValue}");
                character.Health -= this.AttackValue - character.DefenseValue;
                if (character.Health == 0)
                {
                    Console.WriteLine($"{this.Name} defeated 💀 {character.Name}");
                }
                else
                {
                    Console.WriteLine($"{character.Name} now has ❤️ {character.Health}");
                }
            }
            else
            {
                Console.WriteLine($"{character.Name} blocks 🛡️  {this.Name} attack!");
            }
        } 

        public void Cure()
        {
            this.Health += 100;
            Console.WriteLine($"Someone cured {this.Name} 💗 and now has ❤️ {this.Health}");
        }

        public void AddItem(IItem item)
        {
            this.items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            this.items.Remove(item);
        } 
    }
}