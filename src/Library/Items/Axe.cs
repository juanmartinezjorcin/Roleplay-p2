namespace RoleplayGame
{
    public class Axe : Iitem
    {   
        public int AttackValue 
        {
            get
            {
                return 25;
            } 
        }
        
        public bool itsMagic { get; } = false;
    }
}