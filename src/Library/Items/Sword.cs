namespace RoleplayGame
{
    public class Sword : Iitem
    {
        public int AttackValue 
        {
            get
            {
                return 20;
            } 
        }

        public bool itsMagic { get; } = false;
    }
}