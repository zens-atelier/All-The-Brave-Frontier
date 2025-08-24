using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace All_The_Brave_Frontier
{
    class SkeletalDragon : Enemy
    {
        public SkeletalDragon()
        {
            Random rnd = new Random();
            Mag = rnd.Next(23, 28);
            Res = rnd.Next(20, 28);
            Atk = rnd.Next(16, 24);
            Con = rnd.Next(30, 51);
            Hp = Con * 500;
            Name = "Skeletal Dragon";
            DefeatCounter = 0;

            TempMag = Mag;
            TempRes = Res;
            TempAtk = Atk;
            TempCon = Con;
            TempHp = Hp;
        }

        public override void ExecuteGambit(Hero[] party)
        {

            Hero hero1 = (Hero)party[0];
            Attack(hero1);

            Hero hero2 = (Hero)party[1];
            Attack(hero2);

            Hero hero3 = (Hero)party[2];
            MainAbility(hero3);

            Hero hero4 = (Hero)party[3];
            MainAbility(hero4);

            Hero hero5 = (Hero)party[4];
            Console.WriteLine($"\n {Name} skipped {hero5.Job}!");
        }
        public override void MainAbility(Hero hero)
        {
            Console.WriteLine($"\n {this.Name} casts 'Boneshard Barrage.'");
            double damage = this.Mag * 100;
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
