using System;

namespace Arena
{
    /// <summary>
    /// Třída pro vytvoření hrací kostky
    /// </summary>
    class Dice
    {
        /// <summary>
        /// Proměnná pro určení poštu stěn hrací kostky
        /// </summary>
        private int sidesQuantity;

        /// <summary>
        /// Proměnná pro generování náhodných čísel
        /// </summary>
        private Random random;

        /// <summary>
        /// Konstruktor bez vstupních parametrů, vytvoří hrací kostku se 6ti stranami
        /// </summary>
        public Dice()
        {
            sidesQuantity = 6;
            random = new Random();
        }

        /// <summary>
        /// Konstruktor s jedním vstupním parametrem. Definuje počet stěn hrací kostky
        /// </summary>
        /// <param name="sidesQuantity">
        /// Počet stěn hrací kostky
        /// </param>
        public Dice(byte sidesQuantity)
        {
            this.sidesQuantity = sidesQuantity;
            random = new Random();
        }

        /// <summary>
        /// Metoda, která vrací počet stěn hrací kostky
        /// </summary>
        /// <returns>
        /// Počet stěn hrací kostky
        /// </returns>
        public int GetDiceSidesQuantity()
        {
            return sidesQuantity;
        }

        /// <summary>
        /// Vykoná hod kostkou
        /// </summary>
        /// <returns>
        /// Číslo od 1 do počtu stěn hrací kostky
        /// </returns>
        public int Throw()
        {
            return random.Next(1, sidesQuantity + 1);
        }

        /// <summary>
        /// Vrací textovou reprezentaci hrací kostky
        /// </summary>
        /// <returns>
        /// Textová reprezentace hrací kostky
        /// </returns>
        public override string ToString()
        {
            return String.Format($"Kostka se {sidesQuantity} stěnami");
        }
    }
}
