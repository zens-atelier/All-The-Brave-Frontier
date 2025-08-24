using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_The_Brave_Frontier
{
    class WhiteMage : Hero
    {

        public WhiteMage() 
        {
            Random rnd = new Random();
            Mag = rnd.Next(2, 9) * 25; 
            Res = rnd.Next(2, 6); 
            Atk = rnd.Next(0, 3);
            Con = rnd.Next(3, 6);
            Hp = Con * 250;
            Job = "White Mage";
        }

     
        public override void MainAbility (Hero[] party) //should heal all allies' HP
        {
            double healPoints;
            Hero hero;

            Console.WriteLine($"\n {this.Job} casts 'Divine Renewal.'");

            for (int i=0; i < 5; i++)
            {
                hero = (Hero)party[i];

                healPoints = this.TempMag + (hero.TempMag * 50);
                TempHp += healPoints;
                Console.WriteLine("\n " + hero.Job + " gains " + healPoints + " hp!");

            }
        }

        public override void Attack(Enemy enemy)
        {
            Console.WriteLine("\n \n " + enemy.Name + " takes " + TempMag + " damage");
            enemy.TempHp -= TempMag;

        }

        public override void MainAbility(Enemy enemy) { }
    }
}
