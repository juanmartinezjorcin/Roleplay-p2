namespace RoleplayGame
{
    public class Staff : Iitem
    {
        public int AttackValue 
        {
            get
            {
                return 100;
            } 
        }

        public int DefenseValue
        {
            get
            {
                return 100;
            }
        }
        public bool itsMagic { get; } = true;
    }
}