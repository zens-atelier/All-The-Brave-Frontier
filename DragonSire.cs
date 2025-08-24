using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace All_The_Brave_Frontier
{
    class DragonSire : Enemy
    {
        public DragonSire()
        {
            Mag = 30;
            Res = 30;
            Atk = 30;
            Con = 70;
            Hp = Con * 500;
            Name = "DragonSire";
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
            Attack(hero3);

            Hero hero4 = (Hero)party[3];
            Attack(hero4);

            Hero hero5 = (Hero)party[4];
            MainAbility(hero5);
        }
        public override void MainAbility(Hero hero)
        {
            Console.WriteLine($"\n {this.Name} casts 'Breath of Life.'");
            double damage = this.Atk * 50;
            hero.TempHp -= damage;
            Console.WriteLine("\n " + hero.Job + " takes " + damage + " damage!");

            double heal = this.Mag * 100;
            this.TempHp += heal;
            Console.WriteLine("\n " + this.Name + " recovers " + heal + " HP!");

            double increase_Status_Percentage = .10; //increase stat by 10%

            TempMag += TempMag * increase_Status_Percentage;
            TempRes += TempRes * increase_Status_Percentage;
            TempAtk += TempAtk * increase_Status_Percentage;
            TempCon += TempCon * increase_Status_Percentage;

            Console.WriteLine("\n " + this.Name + "'s stats increased by 10%");


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
