namespace HolyKingdom
{
    public class Person
    {
        public string Name { get; private set; }
        public float HP { get; private set; }// heals points
        public float MP { get; private set; }// mana points
        public float SP { get; private set; }// stamina points
        public Elementary.Stats Stats { get; private set; } // not encapsulation 

        public Person(float HP, float MP, float SP, Elementary.Stats stats, string name)
        {
            this.HP = HP;
            this.MP = MP;
            this.Stats = stats;
            this.Name = name;
            this.SP = SP;
        }
        public void TakeDamage(Elementary.ElementaryElements DamageElements, Elementary.ElementaryElements DefenseElements, out bool isDead, out List<string> takesDamage)
        {
            Elementary.ElementaryElements subtractionElementaryElements = Elementary.ElementaryElements.GetSubtractionElementaryElements(DefenseElements, DamageElements);

            takesDamage = new List<string>();

            if (subtractionElementaryElements.Physical > 0)
                takesDamage.Add($"Получено {subtractionElementaryElements.Physical} физического урона");

            if (subtractionElementaryElements.Fiery > 0)
                takesDamage.Add($"Получено {subtractionElementaryElements.Fiery} огненого урона");

            if (subtractionElementaryElements.Ice > 0)
                takesDamage.Add($"Получено {subtractionElementaryElements.Ice} ледяного урона");

            if (subtractionElementaryElements.Dark > 0)
                takesDamage.Add($"Получено {subtractionElementaryElements.Dark} демонического урона");

            if (subtractionElementaryElements.Holy > 0)
                takesDamage.Add($"Получено {subtractionElementaryElements.Holy} святого урона");

            if (takesDamage.Count == 0)
                takesDamage.Add("Вы не получили урона");



            isDead = (HP < 0);
        }
        public void TrySpendingMana(float manaUsed, out bool isSpend)
        {
            if (MP - manaUsed > 0)
                MP -= manaUsed;

            isSpend = (MP < 0);
        }
        public void TrySpendingStamina(float staminaUsed, out bool isSpend)
        {
            if (SP - staminaUsed > 0)
                SP -= staminaUsed;

            isSpend = (SP < 0);
        }
    }
}
