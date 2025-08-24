using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_The_Brave_Frontier
{
    class Constable : Hero
    {
        public Constable()
        {
            Random rnd = new Random();
            Mag = rnd.Next(2, 4);
            Res = rnd.Next(4, 8);
            Atk = rnd.Next(5, 9) * 50;
            Con = rnd.Next(8, 13);
            Hp = Con * 250;
            Job = "Constable";
        }

        public override void MainAbility(Enemy enemy)
        {
            Console.WriteLine($"\n {this.Job} casts 'Take and Receive.'");
            double damage = (TempAtk * 100) - (enemy.TempCon * 20);
            Console.WriteLine("\n " + enemy.Name + " takes " + damage + " damage!");
            enemy.TempHp -= damage;

            damage = (enemy.TempAtk * 50) - (this.TempCon * 50);
            this.TempHp -= damage;

            Console.WriteLine("\n " + this.Job + " takes " + damage + " damage!");
        }

        public override void Attack(Enemy enemy)
        {
            Console.WriteLine("\n \n " + enemy.Name + " takes " + TempAtk + " damage");
            enemy.TempHp -= TempAtk;

        }

        public override void MainAbility(Hero[] party) { }
    }
}
