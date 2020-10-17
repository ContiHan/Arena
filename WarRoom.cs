using System;
using System.Threading;

namespace Arena
{
    class WarRoom
    {
        /// <summary>
        /// První bojovník arény
        /// </summary>
        private Warrior warrior1;
        /// <summary>
        /// Druhý bojovník arény
        /// </summary>
        private Warrior warrior2;
        /// <summary>
        /// Hrací kostka
        /// </summary>
        private Dice dice;

        /// <summary>
        /// Konstruktor arény
        /// </summary>
        /// <param name="warrior1">
        /// První bojovník arény
        /// </param>
        /// <param name="warrior2">
        /// Druhý bojovník arény
        /// </param>
        /// <param name="dice">
        /// 
        /// Hrací kostka</param>
        public WarRoom(Warrior warrior1, Warrior warrior2, Dice dice)
        {
            this.warrior1 = warrior1;
            this.warrior2 = warrior2;
            this.dice = dice;
        }

        private void PrintWarrior(Warrior warrior)
        {
            Console.WriteLine($"{warrior}\n" +
                  $"HP: {warrior.GraphicHpBar()}");
            if (warrior is Mage)
            {
                Console.WriteLine($"MP: {((Mage)warrior).GraphicManaBar()}");
            }
        }

        /// <summary>
        /// Vypíše do konzole text ARÉNA a stav zdraví bojovníků
        /// </summary>
        private void DrawStats()
        {
            Console.Clear();
            Console.WriteLine
                (@"
                     _____  ______       _______ _    _            _____  ______ _   _          
                    |  __ \|  ____|   /\|__   __| |  | |     /\   |  __ \|  ____| \ | |   /\    
                    | |  | | |__     /  \  | |  | |__| |    /  \  | |__) | |__  |  \| |  /  \   
                    | |  | |  __|   / /\ \ | |  |  __  |   / /\ \ |  _  /|  __| | . ` | / /\ \  
                    | |__| | |____ / ____ \| |  | |  | |  / ____ \| | \ \| |____| |\  |/ ____ \ 
                    |_____/|______/_/    \_\_|  |_|  |_| /_/    \_\_|  \_\______|_| \_/_/    \_\                                                                           
                ");
            Console.WriteLine("Stavy bojovníků:\n");
            PrintWarrior(warrior1);
            Console.WriteLine();
            PrintWarrior(warrior2);
            Console.WriteLine();
        }

        /// <summary>
        /// Vypíše do konzole stav z boje
        /// </summary>
        /// <param name="combatLog">
        /// Zpráva z boje
        /// </param>
        private void PrintCombatLog(string combatLog)
        {
            Console.WriteLine(combatLog);
            Thread.Sleep(250);
        }

        /// <summary>
        /// Logika pro rozhodnutí, kdo z bojovníků začíná. Pokud padne na kostce hodnota 1 - půlka počtu stěn kostky, začíná 2. bojovník
        /// </summary>
        /// <returns>
        /// Vrací True, pokud padne první polovina čísel hrací kostky
        /// </returns>
        private bool Warrior2Starts()
        {
            return (dice.Throw() <= dice.GetDiceSidesQuantity() / 2);
        }

        /// <summary>
        /// Samotný boj bojovníků, který se vypíše do konzole
        /// </summary>
        public void GameMatch()
        {
            // prohození pořadí prvního útoku
            if (Warrior2Starts())
            {
                SwapWarriorOrder();
            }

            Console.WriteLine($"Vítejte v aréně!\n" +
                              $"Dnes se utkají {warrior1} a {warrior2}\n" +
                              $"Zápas může začít...");
            Console.ReadKey();

            // smyčka pro samotný boj
            while (warrior1.Alive() && warrior2.Alive())
            {
                Fight(warrior1, warrior2);
                if (warrior2.Alive())
                {
                    Fight(warrior2, warrior1);
                }
            }
        }

        /// <summary>
        /// Prohodí pořadí bojovníků
        /// </summary>
        private void SwapWarriorOrder()
        {
            Warrior tempWarrior = warrior2;
            warrior2 = warrior1;
            warrior1 = tempWarrior;
        }

        /// <summary>
        /// Metoda pro samotný boj, přejímá útočníka a obránce jako vstupní parametry
        /// </summary>
        /// <param name="attacker">
        /// útočník
        /// </param>
        /// <param name="deffender">
        /// obránce
        /// </param>
        private void Fight(Warrior attacker, Warrior deffender)
        {
            // útok na obránce
            attacker.Attack(deffender);
            DrawStats();
            Thread.Sleep(250);
            PrintCombatLog(attacker.LastCombatMessage());
            PrintCombatLog(deffender.LastCombatMessage());
            Thread.Sleep(1000);
        }
    }
}
