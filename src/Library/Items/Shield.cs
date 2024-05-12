namespace RoleplayGame
{
    public class Shield : Iitem
    {
        public int DefenseValue
        {
            get
            {
                return 14;
            }
        }


        public bool itsMagic { get; } = false;
    }
}