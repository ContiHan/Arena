using System;

namespace Arena
{
    class Warrior
    {
        /// <summary>
        /// Jméno bojivníka
        /// </summary>
        protected string name;
        /// <summary>
        /// Aktuální život v HP
        /// </summary>
        protected int health;
        /// <summary>
        /// Maximální život v HP
        /// </summary>
        protected int maxHealth;
        /// <summary>
        /// Útok v HP
        /// </summary>
        protected int attack;
        /// <summary>
        /// Obrana v HP
        /// </summary>
        protected int defence;
        /// <summary>
        /// Instance hrací kostky
        /// </summary>
        protected Dice dice;
        /// <summary>
        /// Informační zprávy z boje
        /// </summary>
        private string combatLog;

        /// <summary>
        /// Vytvoří instanci bojovníka
        /// </summary>
        /// <param name="name">
        /// Jméno bojivníka
        /// </param>
        /// <param name="health">
        /// Život v HP
        /// </param>
        /// <param name="attack">
        /// Útok v HP
        /// </param>
        /// <param name="defence">
        /// Obrana v HP
        /// </param>
        /// <param name="dice">
        /// Hrací kostka
        /// </param>
        public Warrior(string name, int health, int attack, int defence, Dice dice)
        {
            this.name = name;
            this.health = health;
            this.maxHealth = health;
            this.attack = attack;
            this.defence = defence;
            this.dice = dice;
        }

        /// <summary>
        /// Vrací textovou reprezentaci bojovníka
        /// </summary>
        /// <returns>
        /// Textová reprezentaci bojovníka
        /// </returns>
        public override string ToString()
        {
            return name;
        }

        /// <summary>
        /// Vrací pravdu, pokud je bojovník naživu
        /// </summary>
        /// <returns>
        /// Bojovník je naživu
        /// </returns>
        public bool Alive()
        {
            return (health > 0);
        }

        /// <summary>
        /// Vrací grafickou reprezentaci atributů bojovníka
        /// </summary>
        /// <returns>
        /// Grafická reprezentace atributu bojovníka
        /// </returns>
        protected string GraphicAttributeBar(int currentAttributeValue, int maxAttributeValue)
        {
            string bar = "[";
            int barLenght = 20;
            double attributeQuantity = Math.Round(((double)currentAttributeValue / maxAttributeValue) * barLenght);
            if (attributeQuantity == 0 && Alive())
            {
                attributeQuantity = 1;
            }
            for (int i = 0; i < attributeQuantity; i++)
            {
                bar += "#";
            }
            bar = bar.PadRight(barLenght + 1);
            bar += "]";
            return bar;
        }


        /// <summary>
        /// Vrací grafickou reprezentaci života bojovníka
        /// </summary>
        /// <returns>
        /// Grafická reprezentace života bojovníka
        /// </returns>
        public string GraphicHpBar()
        {
            return GraphicAttributeBar(health, maxHealth);
        }

        /// <summary>
        /// Metoda, která přejímá hodnotu úderu a na základě obrany vypočítá, o kolik bojovník přišel života
        /// </summary>
        /// <param name="hit">
        /// Přejatý parametr hodnoty úderu
        /// </param>
        public void DefendYourself(int hit)
        {
            int injury = hit - (defence + dice.Throw());
            if (injury > 0)
            {
                health -= injury;
                combatLog = $"{name} obdržel poškození za {injury} HP";
                if (health <= 0)
                {
                    health = 0;
                    combatLog += " a zemřel";
                }
            }
            else
            {
                combatLog = $"{name} odrazil útok";
            }
            SetCombatMessage(combatLog);
        }

        /// <summary>
        /// Metoda, která vypočítá hodnotu úderu, vyvolá metodu obrany a vypočitá skutečné zranění
        /// </summary>
        /// <param name="enemy">
        /// Vstupní parametr, jméno nepřítele, na kterého útočíme
        /// </param>
        public virtual void Attack(Warrior enemy)
        {
            int hit = attack + dice.Throw();
            SetCombatMessage($"{name} útočí s úderem za {hit} HP");
            enemy.DefendYourself(hit);
        }

        /// <summary>
        /// Uloží zprávu z boje do privátní proměnné
        /// </summary>
        /// <param name="combatLog">
        /// Proměnná pro zprávu z boje
        /// </param>
        protected void SetCombatMessage(string combatLog)
        {
            this.combatLog = combatLog;
        }

        /// <summary>
        /// Vrací zprávu z boje
        /// </summary>
        /// <returns>
        /// Zpráva z boje (combat log)
        /// </returns>
        public string LastCombatMessage()
        {
            return combatLog;
        }
    }
}
