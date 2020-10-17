using System;

namespace Arena
{
    class Mage : Warrior
    {
        /// <summary>
        /// Mana v MP
        /// </summary>
        private int mana;
        /// <summary>
        /// Max mana v MP
        /// </summary>
        private int maxMana;
        /// <summary>
        /// Magický útok v HP
        /// </summary>
        private int magicAttack;

        /// <summary>
        /// Vytvoří instanci mága
        /// </summary>
        /// <param name="name">
        /// Jméno mága
        /// </param>
        /// <param name="health">
        /// Život mága v HP
        /// </param>
        /// <param name="attack">
        /// Útok mága v HP
        /// </param>
        /// <param name="defence">
        /// Obrana mága v HP
        /// </param>
        /// <param name="dice">
        /// Hrací kostka
        /// </param>
        /// <param name="mana">
        /// Stav many
        /// </param>
        /// <param name="magicAttack">
        /// Magický útok v HP
        /// </param>
        public Mage(string name, int health, int attack, int defence, Dice dice, int mana, int magicAttack) : base (name, health, attack, defence, dice)
        {
            this.mana = mana;
            this.maxMana = mana;
            this.magicAttack = magicAttack;
        }

        /// <summary>
        /// Metoda, která vypočítá hodnotu úderu, vyvolá metodu obrany a vypočitá skutečné zranění
        /// </summary>
        /// <param name="enemy">
        /// Vstupní parametr, jméno nepřítele, na kterého útočíme
        /// </param>
        public override void Attack(Warrior enemy)
        {
            if (mana >= maxMana)
            {
                int hit = magicAttack + dice.Throw();
                SetCombatMessage($"{name} použil magii za {hit} HP");
                enemy.DefendYourself(hit);
                mana = 0;
            }
            else
            {
                base.Attack(enemy);
                mana += 10;
                ManaOverflowControl();
            }
        }

        /// <summary>
        /// Just check to not overflow mana points
        /// </summary>
        private void ManaOverflowControl()
        {
            if (mana > maxMana)
            {
                mana = maxMana;
            }
        }

        /// <summary>
        /// Vrací grafickou reprezentaci many bojovníka
        /// </summary>
        /// <returns>
        /// Grafická reprezentace many bojovníka
        /// </returns>
        public string GraphicManaBar()
        {
            return GraphicAttributeBar(mana, maxMana);
        }
    }
}
