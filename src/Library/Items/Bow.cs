namespace RoleplayGame
{
    public class Bow : Iitem
    {
        public int AttackValue 
        {
            get
            {
                return 15;
            } 
        }
        
        public bool itsMagic { get; } = false;
    }
}