namespace RoleplayGame
{
    public class Staff: IAttackItem, IDefenseItem
    {
        public int AttackValue 
        {
            get
            {
                return 120;
            } 
        }

        public int DefenseValue
        {
            get
            {
                return 100;
            }
        }
    }
}