using System;
using System.Runtime.CompilerServices;

namespace JetGameCSharpEdition
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            while (playAgain == true)
            {
                Jet.JetGenerator();

                Console.WriteLine("You are flying in a {0} with {1}% agility, {2}% cannon accuracy, {3}% missile accuracy, and {4} ECM strength."
                , Jet.PJetName, Jet.PJetAgility, Jet.PJetCannonAccuracy, Jet.PJetMissileAccuracy, Jet.PJetECM);

                Jet.TheaterGenerator();
                Jet.CombatRoller();
                bool finalChoice = true;
                while (finalChoice == true)
                {
                    Console.WriteLine("Want to play again? Y/N");
                    Char decision = Console.ReadLine()[0];
                    switch (decision)
                    {
                        case 'y':
                        case 'Y':
                            Console.WriteLine("Right on! Restarting");
                            finalChoice = false;
                            playAgain = true;
                            break;
                        case 'N':
                        case 'n':
                            Console.WriteLine("Thanks for playing!");
                            finalChoice = false;
                            playAgain = false;
                            break;
                        default:
                            Console.WriteLine("Y or N only!");
                            finalChoice = true;
                            break;
                    }
                }
            }

            }
    }
}
