using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_The_Brave_Frontier
{
    class Rogue : Hero
    {
        public Rogue()
        {
            Random rnd = new Random();
            Mag = rnd.Next(1, 5);
            Res = rnd.Next(1, 9);
            Atk = rnd.Next(7, 12) * 50;
            Con = rnd.Next(1, 5);
            Hp = Con * 250;
            Job = "Rogue";
        }

        public override void MainAbility(Enemy enemy)
        {
            Console.WriteLine($"\n {this.Job} casts 'Blood-soaked Blades.'");
            double damage = TempAtk * 100;
            enemy.TempHp -= damage;

            TempHp -= (damage * 0.25);
            Console.WriteLine("\n " + this.Job + "'s HP is decreased to " + TempHp + "!");
        }

        public override void Attack(Enemy enemy)
        {
            Console.WriteLine("\n \n " + enemy.Name + " takes " + TempAtk + " damage");
            enemy.TempHp -= TempAtk;

        }

        public override void MainAbility(Hero[] party) { }
    }
}
