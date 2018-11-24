using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class FriendShip:Ship
    {
        public FriendShip(int x, int y,double phaseOffset, int width= 5, int height=5, int speed=3, int coolDownTime=3, int hp=50, string shipWeapon= "Bullet") :base(x, y, 5, 5, 3, 3, hp, "Bullet")
        {
            phase = phaseOffset;
        }

        public override void DoSomething()
        {
            base.DoSomething();
            this.IsHit();

            Move(0, 0);

            Shoot();

        }
        private double phase = 0;
        public override void Move(int x, int y)
        {
            MyShip myship = GameMgr.GameObjects.FirstOrDefault() as MyShip;
            this.X = myship.X+ (int)(25*Math.Cos(phase));
            this.Y = myship.Y + (int)(25 * Math.Sin(phase)); 
            phase += 0.1;
            SetGraph();
        }
        public override void Shoot()
        {
            //if (CheckCoolDown(ShipWeapon))
            //{
            //    switch (ShipWeapon)
            //    {
            //        case "Bullet":
            //            new Bullet(this.X, this.Y - 20, 0,-1);
            //            break;
            //    }
            //}

        }

    }
}
