using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class MyShip : Ship
    {

        public MyShip(int x, int y) : base(x,y,10,10,3,3,100, "Laser")
        {
            


        }

        public Queue<Keys> Instructions;


        public override List<GameObject> IsHit()
        {
            base.IsHit();
            var ps = GameMgr.GameDataStructure.Search_KD_Tree(GameMgr.KdRoot, TopLeftX, TopLeftY, BottomRightX, BottomRightY);

            bool isDeleted = false;

            foreach (var p in ps)
            {
                var gobj = GameMgr.GameObjectDictionary[p];
                if (gobj == this)
                {
                    continue;
                }
                else if (gobj is FirstAidKit)
                {
                    var firstAaidKit = gobj as FirstAidKit;
                    HP = 100;
                    firstAaidKit.HP -= 1;
                }
                else if (gobj is PowerUpBullet)
                {
                    var powerUpBullet = gobj as PowerUpBullet;
                    ShipWeapon = "Bullet";
                    powerUpBullet.HP -= 1;
                }
            }

            return null;
        }

        public override void DoSomething()
        {        
            base.DoSomething();
            this.IsHit();
            Debug.Print(this.HP.ToString());

        }

        public void SetXY(int x, int y)
        {
            this.X = x;
            this.Y = y;
            SetGraph();
        }
        public override void Shoot()
        {

            if (CheckCoolDown(ShipWeapon))
            {
                switch (ShipWeapon)
                {
                    case "Bullet":
                        new Bullet(this.X, this.Y - 10,0,-1);
                        break;
                    case "Laser":
                        new Laser(this.X, this.Y - 10, 0, -1);
                        break;
                }
            }
        }

        public override void Move(int x, int y)
        {
            this.X += x * Speed;
            this.Y += y * Speed;
            SetGraph();
        }
    }
}
