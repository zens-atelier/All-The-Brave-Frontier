using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_The_Brave_Frontier
{
    public class NullHero : Hero
    {
        public NullHero() {
            Mag = 0;
            Res = 0;
            Atk = 0;
            Con = 0;
            Hp = 0;
            Job = "NULL";
        }

        public override void Attack(Enemy enemy) { }


        public override void MainAbility(Enemy enemy) { }

        public override void MainAbility(Hero[] party) { }
    }
}
