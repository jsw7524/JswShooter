using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Weapon:VisibleGameObject
    {
        protected int Damage { get; set; }
        //static public int CoolDownTime { get; set; }
        public Weapon(int x, int y, int width, int height, int speed, int hp,int coolDownTime) : base(x, y, width, height, speed, hp)
        {
            //CoolDownTime = coolDownTime;
        }

    }
}
