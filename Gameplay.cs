using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace All_The_Brave_Frontier
{
    public class Gameplay
    {

        public Hero[] Party;
        public ArrayList Barracks;
        public Enemy Opponent;

        public Gameplay()
        {
            Party = new Hero[5];
            Barracks = new ArrayList();
        }

        //generate 25 units
        public void Generate25Units()
        {
            Hero hero;

            Random rnd = new Random();
            int random;

            for (int i = 0; i < 25; i++)
            {
                random = rnd.Next(1, 6);

                switch (random)
                {
                    case 1:
                        hero = new BlackMage();
                        Barracks.Add(hero);
                        Console.WriteLine("\n  [" + i + "] Hired " + hero.Job);
                        break;
                    case 2:
                        hero = new Constable();
                        Barracks.Add(hero);
                        Console.WriteLine("\n  [" + i + "] Hired " + hero.Job);
                        break;
                    case 3:
                        hero = new RedMage();
                        Barracks.Add(hero);
                        Console.WriteLine("\n  [" + i + "] Hired " + hero.Job);
                        break;
                    case 4:
                        hero = new Rogue();
                        Barracks.Add(hero);
                        Console.WriteLine("\n  [" + i + "] Hired " + hero.Job);
                        break;
                    case 5:
                        hero = new WhiteMage();
                        Barracks.Add(hero);
                        Console.WriteLine("\n  [" + i + "] Hired " + hero.Job);
                        break;
                    default:
                        Console.WriteLine("\n Wrong parameter in unit generation.");
                        break;

                }

            }
        }

        //view every Hero in Barracks
        public void ViewBarracks()
        {
            int i = 1;
            foreach (Hero hero in this.Barracks)
            {
                double avg = GetAverage(hero);
                Console.WriteLine("\n [" + i +"] " + hero.Job + " LVL: " + hero.Level + "AVG: " + avg);
                Console.WriteLine("\n HP: "+ hero.Hp);
                Console.WriteLine("\n ATK: "+ hero.Atk);
                Console.WriteLine("\n CON: "+ hero.Con);
                Console.WriteLine("\n MAG: "+ hero.Mag);
                Console.WriteLine("\n RES: "+ hero.Res);
                Console.WriteLine("\n");

                i++;
            }
        }

        //view every Hero in Party
        public void ViewParty()
        {
            int i = 1;
            foreach (Hero hero in this.Party)
            {
                double avg = GetAverage(hero);
                Console.WriteLine("\n [" + i +"] " + hero.Job + " LVL: " + hero.Level + "      AVG: " + avg);
                Console.WriteLine("\n HP: "+ hero.Hp);
                Console.WriteLine("\n ATK: "+ hero.Atk);
                Console.WriteLine("\n CON: "+ hero.Con);
                Console.WriteLine("\n MAG: "+ hero.Mag);
                Console.WriteLine("\n RES: "+ hero.Res);
                Console.WriteLine("\n");

                i++;
            }
        }

        //combine units - auto merge characters
        public void MergeUnits()
        {
            for (int i = 0; i < Barracks.Count; i++)
            {
                for (int j = 1; j < Barracks.Count; j++)
                {
                    //Hero baseHero = (Hero)Barracks[i];
                    Hero baseHero = (Hero)Barracks[i];
                    double avgBaseHero = GetAverage(baseHero);

                    Hero materialHero = (Hero)Barracks[j];
                    double avgMaterialHero = GetAverage(materialHero);

                    //check if same job
                    if (baseHero.Job == materialHero.Job && (baseHero.Job != "NULL" || materialHero.Job != "NULL")) {
                        //check which avg is higher; lower avg gets absorbed

                        if (avgBaseHero > avgMaterialHero)
                        {
                            baseHero.Atk += avgMaterialHero * .10;
                            baseHero.Con += avgMaterialHero * .10;
                            baseHero.Mag += avgMaterialHero * .10;
                            baseHero.Res += avgMaterialHero * .10;
                            baseHero.Hp  += baseHero.Con * 250;
                            baseHero.Level++;
                            
                            Barracks[j] = new NullHero();
                        }
                        else if (avgBaseHero < avgMaterialHero)
                        {
                            materialHero.Atk += avgBaseHero * .10;
                            materialHero.Con += avgBaseHero * .10;
                            materialHero.Mag += avgBaseHero * .10;
                            materialHero.Res += avgBaseHero * .10;
                            materialHero.Hp += materialHero.Con * 250;
                            materialHero.Level++;

                            Barracks[i] = new NullHero();
                        }
                    }

                }
            }
        }
        //from Barracks automatically send units to Party
        public void SetParty() 
        {
            int i = 0;
            foreach (Hero hero in this.Barracks)
            {
                if (hero.Job != "NULL") 
                {
                    Party[i] = hero;
                    i++;
                }
            }
            Console.WriteLine("\n Party has been set.");

        }

        private double GetAverage(Hero hero) 
        {
            double avg = (hero.Mag + hero.Res + hero.Con + hero.Atk) / 4;
            return avg;
        }

        //arrange party
        public void ArrangeParty()
        {
            Console.WriteLine("\n Sort your party");

            int i = 0;

            foreach (Hero hero in this.Party)
            {
                Console.WriteLine("\n [" + i + "]" + hero.Job + "   HP: " + hero.TempHp);
                i++;
            }

            Console.WriteLine("\n Please select a unit");
            int firstChoice = int.Parse(Console.ReadLine());
            Hero x = (Hero)this.Party[firstChoice];

            int j = 0;
            foreach (Hero hero in this.Party)
            {
                if (firstChoice != j)
                    Console.WriteLine("\n [" + j + "]" + hero.Job + "   HP: " + hero.TempHp);
                j++;
            }

            Console.WriteLine("\n Selected [" + firstChoice + "]. Please select a unit you want replaced. ");
            int secondChoice = int.Parse(Console.ReadLine());
            Hero y = (Hero)this.Party[secondChoice];

            this.Party[firstChoice] = y;
            this.Party[secondChoice] = x;
        }


        //menu option: fight, main ability, flee
        public void Fight()
        {
            ResetStats();

            bool partyDown = false;
            bool foeDown = false;
            bool flee = false;
            Char choice = ' ';

            do
            {
                //check if all units in party is down at the beginning of round. 
                int countDead = 0;
                foreach (Hero hero in this.Party)
                {
                    if (hero.TempHp <= 0)
                        countDead++;

                    if (countDead == 5)
                    {
                        partyDown = true;
                        Console.WriteLine("\n All units are down. " + Opponent.Name + "wins the battle.");
                        break;
                    }
                }
                countDead = 0;

                //check if opponent's hp is <= 0
                if (Opponent.TempHp <= 0)
                {
                    foeDown = true;
                    Console.WriteLine("\n " + Opponent.Name + " is down. You win the battle.");
                    break;
                }

                //show HP of party and opponent
                ShowHp(this.Party, Opponent);

                //loop through alive party units then activate gambit
                
                foreach (Hero hero in this.Party)
                {
                    if (hero.TempHp > 0)
                    {
                        Console.WriteLine("\n \n [1] Fight");
                        Console.WriteLine("\n [2] Main Ability");
                        Console.WriteLine("\n [3] Flee");

                        Console.WriteLine("\n \n What would you like to do?");
                        choice = Console.ReadKey().KeyChar;

                        switch (choice)
                        {
                            case '1':
                                Console.WriteLine("\n Decided to attack.");
                                hero.Attack(Opponent);

                                break;
                            case '2':
                                Console.WriteLine("\n Decided to use Main Ability.");
                                if (hero.Job != "White Mage") 
                                { 
                                    hero.MainAbility(Opponent);
                                    break;
                                }

                                hero.MainAbility(Party);
                                break;
                            case '3':
                                Console.WriteLine("\n You chose to flee");
                                flee = true;
                                break;
                            default:
                                Console.WriteLine("\n Choose Again.");
                                break;
                        }
                    }
                }

                //enemy gambit
                if (Opponent.TempHp > 0)
                    Opponent.ExecuteGambit(Party);

            } while (partyDown == false || foeDown == false || flee == false);
        }


        //generate enemy from choices 1-4
        public void generateEnemy ()
        {
            Char choice = ' ';

            do
            {
                Console.WriteLine("\n \n [1] Goblin");
                Console.WriteLine("\n [2] LizardMan");
                Console.WriteLine("\n [3] Skeletal Dragon");
                Console.WriteLine("\n [4] DragonSire");
                Console.WriteLine("\n [5] Exit. Back to Main Menu.");

                Console.WriteLine("Please choose an opponent");
                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        Console.WriteLine("\n Preparing Encounter: Goblin");
                        Opponent = new Goblin();
                        choice = 'x';
                        break;
                    case '2':
                        Console.WriteLine("\n Preparing Encounter: LizardMan");
                        Opponent = new LizardMan();
                        choice = 'x';

                        break;
                    case '3':
                        Console.WriteLine("\n Preparing Encounter: Skeletal Dragon");
                        Opponent = new SkeletalDragon();
                        choice = 'x';

                        break;
                    case '4':
                        Console.WriteLine("\n Preparing Encounter: DragonSire");
                        Opponent = new DragonSire();
                        choice = 'x';

                        break;
                    case '5':
                        Console.WriteLine("\n Back to main menu.");
                        choice = 'x';
                        break;
                    default:
                        Console.WriteLine("\n Choose Again.");
                        break;
                }
            } while (choice != 'x');

        }

        //reset Temp stats - party
        private void ResetStats() 
        {
            foreach (Hero hero in this.Barracks)
            {
                hero.TempAtk = hero.Atk;
                hero.TempCon = hero.Con;
                hero.TempMag = hero.Mag;
                hero.TempRes = hero.Res;
                hero.TempHp = hero.Hp;
            }
        }

        //show HP party and enemy at start of round
        private void ShowHp(Hero[] party, Enemy enemy) 
        {
            int i = 0;
            foreach (Hero hero in party)
            {
                Console.WriteLine("\n [" + (i + 1) + "]" + hero.Job + "   HP: " + hero.TempHp);
                i++;
            }

            Console.WriteLine("\n \n " + enemy.Name + "   HP: " + enemy.TempHp);
            i = 0;
        }


    }
}
