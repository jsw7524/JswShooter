using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    abstract class Ship : VisibleGameObject, IMovable, IShootable
    {
        

        protected int CoolDownTime { get; set; }
        protected int CoolDown { get; set; }
        protected string ShipWeapon { get; set; }
        //public int TopLeftX { get; set ; }
        //public int TopLeftY { get; set ; }
        //public int BottomRightX { get; set ; }
        //public int BottomRightY { get ; set ; }
        //public List<Point> Contour { get ; set ; }=new List<Point>();

        public Ship(int x ,int y,int width ,int height,int speed, int coolDownTime,int hp ,string shipWeapon):base(x,y,width,height,speed,hp)
        {
            ShipWeapon = shipWeapon;
            CoolDownTime = coolDownTime;

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
