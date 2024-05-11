namespace RoleplayGame
{
    public interface ICharacter
    {
        string Name { get; set; }
        int AttackValue { get; }
        int DefenseValue { get; }
        int Health { get; }

        void ShowStats();
        void Attack(int power);
        void Cure();
    }
}