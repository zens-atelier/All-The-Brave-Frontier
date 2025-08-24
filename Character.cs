using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_The_Brave_Frontier
{
    public abstract class Character
    {
        public double Mag { get; set; }
        public double Res { get; set; }
        public double Atk { get; set; }
        public double Con { get; set; }
        public double Hp  { get; set; }

        public double TempMag { get; set; }
        public double TempRes { get; set; }
        public double TempAtk { get; set; }
        public double TempCon { get; set; }
        public double TempHp { get; set; }

        public Character(){}

    }
}
