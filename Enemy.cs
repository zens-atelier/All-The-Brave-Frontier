using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_The_Brave_Frontier
{
   public abstract class Enemy : Character
    {
        public string Name { get; set; }
        public int DefeatCounter { get; set; }

        public Enemy() { }

        public abstract void ExecuteGambit(Hero[] party);
        public abstract void MainAbility(Hero hero);

        //private void Attack(Hero hero);

    }
}
