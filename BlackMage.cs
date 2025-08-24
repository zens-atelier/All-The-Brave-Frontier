using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_The_Brave_Frontier
{
    class BlackMage : Hero
    {
        public BlackMage()
        {
            Random rnd = new Random();
            Mag = rnd.Next(4, 11) * 25;
            Res = rnd.Next(3, 9); 
            Atk = rnd.Next(0, 2); 
            Con = rnd.Next(1, 4);
            Hp = Con* 250;
            Job = "Black Mage";
        }

     
        public override void MainAbility(Enemy enemy)
        {
            Console.WriteLine($"\n {this.Job} casts 'Astral Hurricane.'");
            double damage = (TempMag * 100) - (enemy.TempRes * 80);
            enemy.TempHp -= damage;

            Console.WriteLine("\n \n " + enemy.Name + " takes " + damage+ " damage");

            TempCon -= (TempCon * 0.2);
            Console.WriteLine("\n " + this.Job + "'s Mag is decreased to " + TempCon + "!");
        }

        public override void Attack(Enemy enemy) 
        {
            Console.WriteLine("\n \n " + enemy.Name + " takes " + TempMag + " damage");
            enemy.TempHp -= TempMag;

        }

        public override void MainAbility(Hero[] party) { }
    }
}
