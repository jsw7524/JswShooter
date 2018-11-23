using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class EnemyShip : Ship, IDrawable
    {
        public int TopLeftX { get; set; }
        public int TopLeftY { get; set; }
        public int BottomRightX { get; set; }
        public int BottomRightY { get; set; }
        public List<Point> Contour { get; set; }

        private double phase = 0;

        public override void Move(int x, int y)
        {
            this.X += Convert.ToInt32((Math.Cos(phase) * Speed));
            phase += 0.1;
            //this.Y += Math.Cos(phase) * Speed;
            SetGraph();
        }

        public EnemyShip(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Width = 10;
            this.Height = 10;
            this.Speed = 3;
            this.HP = 1;
            ShipWeapon = "Bullet";
            CoolDownTime = 30;
            CoolDown = 0;
            Contour = new List<Point>();
            Contour.Add(new Point(this.X, this.Y));
            Contour.Add(new Point(this.X, this.Y + this.Height));
            Contour.Add(new Point(this.X + this.Width, this.Y));
            Contour.Add(new Point(this.X + this.Width, this.Y + this.Height));
            ShipWeapon = "Bullet";
            SetGraph();
            foreach (var p in this.Contour)
            {
                GameMgr.GameObjectDictionary.Add(p, this);
            }
        }

        public List<GameObject> IsHit()
        {
            var ps = GameMgr.GameDataStructure.Search_KD_Tree(GameMgr.KdRoot, TopLeftX, TopLeftY, BottomRightX, BottomRightY);

            bool isDeleted = false;

            foreach (var p in ps)
            {
                var gobj = GameMgr.GameObjectDictionary[p];
                if (gobj == this)
                {
                    continue;
                }
                else if (gobj is Bullet)
                {
                    var bullet = gobj as Bullet;
                    HP-= 1;
                    bullet.HP = -1;
                }
                else if (gobj is MyShip)
                {
                    var myShip = gobj as MyShip;
                    HP -= 1;

                    gobj.HP -= 1;
                }
            }

            return null;
        }
        public override void DoSomething()
        {
            base.DoSomething();
            this.IsHit();

            Move(0,0);

            Shoot();

        }

        public override void Shoot()
        {
            MyShip myship = GameMgr.GameObjects.FirstOrDefault() as MyShip;

            if (CheckCoolDown())
            {
                switch (ShipWeapon)
                {
                    case "Bullet":
                        new Bullet(this.X, this.Y+20, (myship.X-this.X)/100, (myship.Y-this.Y)/100);
                        break;
                }
            }

        }


        public void SetGraph()
        {
            TopLeftX = this.X;
            TopLeftY = this.Y;
            BottomRightX = this.X + this.Width;
            BottomRightY = this.Y + this.Height;
            //////////////
            Contour[0].X = this.X;
            Contour[0].Y = this.Y;
            Contour[1].X = this.X;
            Contour[1].Y = this.Y + this.Height;
            Contour[2].X = this.X + this.Width;
            Contour[2].Y = this.Y;
            Contour[3].X = this.X + this.Width;
            Contour[3].Y = this.Y + this.Height;
            ///////////////
        }
    }
}
