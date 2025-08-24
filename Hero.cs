using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_The_Brave_Frontier
{
    public abstract class Hero : Character
    {
        public string Job { get; set; }
        public int Level { get; set; }
        public Hero() {
            Level = 1;
        }

        public abstract void Attack(Enemy enemy);

        public abstract void MainAbility(Enemy enemy);

        public abstract void MainAbility(Hero[] party);

    }
}
