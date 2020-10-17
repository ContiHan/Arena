using System;

namespace Arena
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice tenSidedDice = new Dice(10);
            Warrior thrall = new Warrior("Thrall", 120, 20, 10, tenSidedDice);
            Mage jaeden = new Mage("Jaeden", 80, 15, 10, tenSidedDice, 40, 60);
            WarRoom trziste = new WarRoom(thrall, jaeden, tenSidedDice);

            trziste.GameMatch();

            Console.ReadKey();
        }
    }
}
