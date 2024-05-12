namespace RoleplayGame
{
    public class Helmet : Iitem
    {
        public int DefenseValue
        {
            get
            {
                return 18;
            }
        }
        
        public bool itsMagic { get; } = false;
    }
}