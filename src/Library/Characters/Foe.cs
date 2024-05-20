namespace RoleplayGame
{
    public abstract class Foe : Character
    {
        int PV { get; }
        protected new int AttackValue { get; set; }
        protected new int DefenseValue { get; set; }
    }
}