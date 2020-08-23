using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace JetGameCSharpEdition
{
    class Jet
    {

        static public double PJetAgility { get; set; }
        static public double PJetCannonAccuracy { get; set; }
        static public double PJetMissileAccuracy { get; set; }
        static public String PJetName { get; set; }
        static public double PJetECM { get; set; }


        //story generator
        static public void TheaterGenerator()
        {
            Random theaterPicker = new Random();
            string[] theater = { "Iraq", "Iran", "North Korea", "The South China Sea", "Afghistan" };
            int theaterIndex = theaterPicker.Next(theater.Length);
            Console.WriteLine("Today your mission is in {0}. After refueling off of the tanker, you begin your air combat patrol and encounter a Mig-21"
                , theater[theaterIndex]);
        }

        //Sets the attributes of a jet based on presidental era
        static public void JetGenerator()
        {
            bool invalidInput = true;
            while (invalidInput)
            {
                Console.WriteLine("Pick your president to determine which jet you get: (C)linton, (B)ush, (O)bama, (T)rump");
                Char presDecision = Console.ReadLine()[0];
                switch (presDecision)
                {
                    case 'c':
                    case 'C':
                        {
                            Console.WriteLine("You serve under Bill Clinton, 42th President of the United States, 1992 - 2000");
                            Jet.PJetName = "F-15A";
                            Jet.PJetAgility = .35;
                            Jet.PJetCannonAccuracy = .75;
                            Jet.PJetMissileAccuracy = .50;
                            Jet.PJetECM = .25;
                            Enemy.EJetAgility = .30;
                            Enemy.EJetAccuracy = .50;
                            Enemy.EJetECM = .25;
                            Enemy.EJetName = "Mig-21";
                            invalidInput = false;
                            break;
                        }

                    case 'B':
                    case 'b':
                        {
                            Console.WriteLine("You serve under George W. Bush, 43th President of the United States, 2000 - 2008");
                            Jet.PJetName = "F-15C";
                            Jet.PJetAgility = .50;
                            Jet.PJetCannonAccuracy = .85;
                            Jet.PJetMissileAccuracy = .65;
                            Jet.PJetECM = .30;
                            Enemy.EJetAgility = .30;
                            Enemy.EJetAccuracy = .50;
                            Enemy.EJetECM = .25;
                            Enemy.EJetName = "Mig-21";
                            invalidInput = false;
                            break;
                        }
                    case 'O':
                    case 'o':
                        {
                            Console.WriteLine("You serve under Barack Obama, 44th President of the United States, 2008 - 2016");
                            Jet.PJetName = "F-22";
                            Jet.PJetAgility = .50;
                            Jet.PJetCannonAccuracy = .85;
                            Jet.PJetMissileAccuracy = .65;
                            Jet.PJetECM = .50;
                            Enemy.EJetAgility = .30;
                            Enemy.EJetAccuracy = .50;
                            Enemy.EJetECM = .25;
                            Enemy.EJetName = "Mig-21";
                            invalidInput = false;
                            break;
                        }
                    case 't':
                    case 'T':
                        {
                            Console.WriteLine("You serve under Donald Trump, 45th President of the United States, 2016 - 2024");
                            Jet.PJetName = "F-35A";
                            Jet.PJetAgility = .50;
                            Jet.PJetCannonAccuracy = .95;
                            Jet.PJetMissileAccuracy = .90;
                            Jet.PJetECM = .75;
                            Enemy.EJetAgility = .30;
                            Enemy.EJetAccuracy = .50;
                            Enemy.EJetECM = .25;
                            Enemy.EJetName = "Mig-21";
                            invalidInput = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Entry! Try again!");
                            invalidInput = true;
                            break;
                        }

                }
            }

        }

        public static void CombatRoller()
        {
            bool isalive = true;
            Random attackRoll = new Random();
            while (isalive == true)
            {
                Console.WriteLine("Do you attack with (C)annons or (M)issiles?");
                Char attackChoice = Console.ReadLine()[0];

                switch (attackChoice)
                {
                    case 'c':
                    case 'C':
                        double cannonHitChance = Jet.PJetCannonAccuracy * Enemy.EJetAgility * 100;
                        Console.WriteLine("Hit Chance is {0}", cannonHitChance);
                        double cannonAttackRoll = attackRoll.NextDouble() * 100;
                        Console.WriteLine("Attack roll was {0}", cannonAttackRoll);
                        if (cannonAttackRoll <= cannonHitChance)
                        {
                            Console.WriteLine("You shred up the MIG with your cannon fire and save the free world!");
                            isalive = false;
                        }
                        else
                        {
                            Console.WriteLine("You Missed!");
                            double enemyHitChance = Enemy.EJetAccuracy * Jet.PJetAgility * 100;
                            Console.WriteLine("Enemy attacks now! hit chance is {0}", enemyHitChance);
                            double enemyCannonAttack = attackRoll.NextDouble() * 100;
                            Console.WriteLine("Attack Roll was {0}", enemyCannonAttack);
                            if (enemyCannonAttack <= Enemy.EJetAccuracy)
                            {
                                Console.WriteLine("You die to shitty 3rd world equipment!");
                                isalive = false;
                            }
                            else
                            {
                                Console.WriteLine("The Enemy Jet Misses also!");
                                isalive = true;
                            }
                            
        

                        }
                        break;

                    case 'm':
                    case 'M':
                        double missileHitChance = Jet.PJetMissileAccuracy * Enemy.EJetECM * 100;
                        Console.WriteLine("Hit Chance is {0}", missileHitChance);
                        double missileAttackRoll = attackRoll.NextDouble() * 100;
                        Console.WriteLine("Attack roll was {0}", missileAttackRoll);
                        if (missileAttackRoll <= missileHitChance)
                        {
                            Console.WriteLine("You blow up the mig with an AIM-120C and save the free world!");
                            isalive = false;
                        }
                        else
                        {
                            Console.WriteLine("You Missed!");
                            double enemyHitChance = Enemy.EJetAccuracy * Jet.PJetECM * 100;
                            Console.WriteLine("Enemy attacks now! hit chance is {0}", enemyHitChance);
                            double enemyCannonAttack = attackRoll.NextDouble() * 100;
                            Console.WriteLine("Attack Roll was {0}", enemyCannonAttack);
                            if (enemyCannonAttack <= Enemy.EJetAccuracy)
                            {
                                Console.WriteLine("You die to shitty 3rd world equipment!");
                                isalive = false;
                            }
                            else
                            {
                                Console.WriteLine("The Enemy Jet Misses also!");
                                isalive = true;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter a valid attack");
                        isalive = true;
                        break;

                }
            }
        }
    } 

    class Enemy : Jet
    {
        static public double EJetAgility { get; set; }
        static public double EJetAccuracy { get; set; }
        static public double EJetECM { get; set; }
        static public String EJetName { get; set; }
    }
}
