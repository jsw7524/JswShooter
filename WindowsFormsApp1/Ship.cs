using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    abstract class Ship : GameObject, IMovable, IShootable, IDrawable
    {
        

        protected int CoolDownTime { get; set; }
        protected int CoolDown { get; set; }
        protected string ShipWeapon { get; set; }
        public int TopLeftX { get; set ; }
        public int TopLeftY { get; set ; }
        public int BottomRightX { get; set ; }
        public int BottomRightY { get ; set ; }
        public List<Point> Contour { get ; set ; }=new List<Point>();

        public Ship(int x ,int y,int width ,int height,int speed, int coolDownTime,int hp ,string shipWeapon):base(x,y,width,height,speed,hp)
        {
            ShipWeapon = shipWeapon;
            CoolDownTime = coolDownTime;

            CoolDown = 0;
            //Contour = new List<Point>();
            Contour.Add(new Point(this.X, this.Y));
            Contour.Add(new Point(this.X, this.Y + this.Height));
            Contour.Add(new Point(this.X + this.Width, this.Y));
            Contour.Add(new Point(this.X + this.Width, this.Y + this.Height));
            //Instructions = new Queue<Keys>();
            SetGraph();
            foreach (var p in this.Contour)
            {
                GameMgr.GameObjectDictionary.Add(p, this);
            }
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
                    HP -= 1;
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
    }
}
