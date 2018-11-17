using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    abstract class Ship : GameObject, IMovable, IShootable
    {
        public int Speed { get; set; }
        protected int HP { get; set; }
        protected int CoolDownTime { get; set; }
        protected int CoolDown { get; set; }
        public virtual void Move(int x, int y)
        {

        }

        public virtual void Shoot()
        {

        }
        public virtual bool CheckCoolDown()
        {
            if (0 >= CoolDown)
            {
                CoolDown = CoolDownTime;
                return true;
            }
            return false;
        }

        public override void DoSomething()
        {
            CoolDown--;
        }
    }
}
