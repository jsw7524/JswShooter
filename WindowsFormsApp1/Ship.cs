using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    abstract class Ship : VisibleGameObject, IShootable
    {
        

        //protected int CoolDownTime { get; set; }
        protected int CoolDown { get; set; }
        protected string ShipWeapon { get; set; }


        public Ship(int x ,int y,int width ,int height,int speed, int coolDownTime,int hp ,string shipWeapon):base(x,y,width,height,speed,hp)
        {
            ShipWeapon = shipWeapon;
            CoolDown = 0;
        }


        public virtual void Shoot()
        {

        }


        public virtual bool CheckCoolDown(string w)
        {
            if (0 >= CoolDown)
            {
                PropertyInfo myPropInfo = Type.GetType("WindowsFormsApp1."+w).GetProperty("CoolDownTime");
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
