using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    abstract class Ship : VisibleGameObject, IMovable, IShootable
    {
        

        //protected int CoolDownTime { get; set; }
        protected int CoolDown { get; set; }
        protected string ShipWeapon { get; set; }


        public Ship(int x ,int y,int width ,int height,int speed, int coolDownTime,int hp ,string shipWeapon):base(x,y,width,height,speed,hp)
        {
            ShipWeapon = shipWeapon;
            //CoolDownTime = coolDownTime;

            CoolDown = 0;
        }

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
                PropertyInfo myPropInfo = Type.GetType("WindowsFormsApp1.Bullet").GetProperty("CoolDownTime");
                CoolDown = Convert.ToInt32(myPropInfo.GetValue(this,null)); ;
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
