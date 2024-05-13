using System;

namespace RoleplayGame
{
    public class Armor : Iitem
    {
        public int DefenseValue
        {
            get
            {
                return 25;
            }
            
        }

        public bool itsMagic { get; } = false;
    }
}