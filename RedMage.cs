using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_The_Brave_Frontier
{
    internal class RedMage : Hero
    {
        public RedMage()
        {
            Random rnd = new Random();
            Mag = rnd.Next(4, 7) * 25;
            Res = rnd.Next(3, 9);
            Atk = rnd.Next(0, 3);
            Con = rnd.Next(3, 6);
            Hp = Con * 250;
            Job = "Red Mage";
        }

        public override void MainAbility(Hero[] party) //should increase individual stats by 10%
        {
            Hero hero;

            Console.WriteLine($"\n {this.Job} casts 'Spirit Bind.'");

            for (int i = 0; i < 5; i++)
            {
                hero = (Hero)party[i];

                hero.TempMag += this.TempMag * .10;
                hero.TempRes += this.TempRes * .10;
                hero.TempAtk += this.TempAtk * .10;
                hero.TempCon += this.TempCon * .10;
                
                Console.WriteLine("\n " + hero.Job + " gains 10% on all stats!");

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
