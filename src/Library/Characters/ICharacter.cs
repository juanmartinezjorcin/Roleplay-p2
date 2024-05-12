namespace RoleplayGame
{
    public interface ICharacter
    {
        string Name { get; set; }
        int AttackValue { get; }
        int DefenseValue { get; }
        int Health { get; set;}

        Iitem OtherItem { get; set; }

        void ShowStats();
        void Attack(ICharacter character);
        void Cure();

        void GetItem(Iitem item);

        void RemoveItem(Iitem iitem);
    }
}