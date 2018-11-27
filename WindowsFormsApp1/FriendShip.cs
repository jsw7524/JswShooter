using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class FriendShip:Ship
    {
        private double phase = 0;
        public override void Move(int x, int y)
        {
            this.X += Convert.ToInt32((Math.Cos(phase) * Speed));
            this.Y -= 1;
            phase += 0.1;
            SetGraph();
        }

        public FriendShip(int x, int y) : base(x, y, 10, 10, 3, 3, 1, "Bullet")
        {

        }
        public FriendShip(int x, int y, int speed) : base(x, y, 10, 10, speed, 3, 1, "Bullet")
        {

        }
        public override void DoSomething()
        {
            base.DoSomething();
            this.IsHit();

            Move(0, 0);

            Shoot();

        }

        public override void Shoot()
        {
            MyShip myship = GameMgr.GameObjects.FirstOrDefault() as MyShip;

            if (CheckCoolDown(ShipWeapon))
            {
                switch (ShipWeapon)
                {
                    case "Bullet":
                        new FriendBullet(this.X, this.Y + 20, 0, -1);
                        break;
                }
            }

        }

    }
}
