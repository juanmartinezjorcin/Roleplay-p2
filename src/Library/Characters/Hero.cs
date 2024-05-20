using System;

namespace RoleplayGame
{
    public abstract class Hero : ICharacter
    {
        private int health;

        public string Name { get; set; }
        public Iitem OtherItem { get; set; }

        public abstract int AttackValue { get; }
        public abstract int DefenseValue { get; }
        public abstract int MaxHealth { get; }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value < 0)
                {
                    this.health = 0;
                }
                else
                {
                    this.health = value > MaxHealth ? MaxHealth : value;
                }
            }
        }

        public void ShowStats()
        {
            Console.WriteLine($"|\nv\n{this.Name}");
            Console.WriteLine($"\tSalud: {this.Health}");
            Console.WriteLine($"\tDefensa: {this.DefenseValue}");
            Console.WriteLine($"\tAtaque: {this.AttackValue}\n");
        }

        public void Attack(ICharacter character)
        {
            if (character.DefenseValue >= this.AttackValue)
            {
                Console.WriteLine($"{this.Name} no dañó a {character.Name}");
            }
            else
            {
                int damage = this.AttackValue - character.DefenseValue;
                character.Health -= damage;

                if (character.Health <= 0)
                {
                    Console.WriteLine($"{character.Name} fue asesinado por {this.Name}");
                }
                else
                {
                    Console.WriteLine($"{character.Name} perdió {damage} de vida por el ataque de {this.Name}");
                }
            }
        }

        public void Cure(int curacion)
        {
            this.Health += curacion;
        }

        public void GetItem(Iitem item)
        {

        }

        protected abstract void EquipItem(Iitem item);

        public void RemoveItem(Iitem item)
        {

        }
    }
}
