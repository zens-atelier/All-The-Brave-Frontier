using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace All_The_Brave_Frontier
{
    class Goblin :  Enemy
    {
        public Goblin()
        {
            Random rnd = new Random();
            Mag = rnd.Next(8, 17);
            Res = rnd.Next(5, 21);
            Atk = rnd.Next(2, 9);
            Con = rnd.Next(12, 21);
            Hp = Con * 500;
            Name = "Goblin";
            DefeatCounter = 0;

            TempMag = Mag;
            TempRes = Res;
            TempAtk = Atk;
            TempCon = Con;
            TempHp = Hp;
        }

        public override void ExecuteGambit(Hero[] party)
        {
            double damage = 0;

            Hero hero1 = (Hero)party[0];
            Attack(hero1);

            Hero hero2 = (Hero)party[1];
            Attack(hero2);

            Hero hero3 = (Hero)party[2];
            Console.WriteLine($"\n {Name} skipped {hero3.Job}!");

            Hero hero4 = (Hero)party[3];
            MainAbility(hero4);

            Hero hero5 = (Hero)party[4];
            Console.WriteLine($"\n {Name} skipped {hero5.Job}!");

        }

        public override void MainAbility(Hero hero)
        {
            Console.WriteLine($"\n {this.Name} casts 'Goblin Swipes.'");
            double damage = (hero.Atk * 25) + (this.Atk * 25);
            hero.TempHp -= damage;
            Console.WriteLine("\n " + hero.Job + " takes " + damage + " damage!");
        }

        private void Attack(Hero hero)
        {
            double damage = 0;
            damage = TempAtk * 50;
            hero.TempHp -= damage;
            Console.WriteLine($"\n {Name} used Attack on {hero.Job}! Dealt " + damage + " damage");
        }
    }
}
