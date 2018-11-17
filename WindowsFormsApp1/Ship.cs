using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    abstract class Ship : GameObject, IMovable, IShootable
    {
        

        protected int CoolDownTime { get; set; }
        protected int CoolDown { get; set; }
        protected string ShipWeapon { get; set; }
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
            base.DoSomething();
            CoolDown--;
        }
    }
}
