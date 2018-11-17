using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class MyShip : Ship, IDrawable
    {

        public MyShip(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Width = 10;
            this.Height = 10;
            this.Speed = 3;
            ShipWeapon = "Bullet";
            CoolDownTime = 30;
            CoolDown = 0;
            Contour = new List<Point>();
            Instructions = new Queue<Keys>();
            SetGraph();
        }

        public Queue<Keys> Instructions;

        public int TopLeftX { get; set; }
        public int TopLeftY { get; set; }
        public int BottomRightX { get; set; }
        public int BottomRightY { get; set; }
        public List<Point> Contour { get; set; }

        public string ShipWeapon { get; set; }
        //public override bool CheckCoolDown()
        //{
        //    if (0 >= CoolDown)
        //    {
        //        CoolDown = CoolDownTime;
        //        return true;
        //    }
        //    return false;
        //}
        public override void DoSomething()
        {
            base.DoSomething();
            if (Instructions.Count > 0)
            {
                var instr = Instructions.Dequeue();
                switch (instr)
                {
                    case Keys.W:
                        this.Move(0, -1);
                        break;
                    case Keys.S:
                        this.Move(0, 1);
                        break;
                    case Keys.A:
                        this.Move(-1, 0);
                        break;
                    case Keys.D:
                        this.Move(1, 0);
                        break;
                    case Keys.Space:
                        this.Shoot();
                        break;
                }
            }
        }

        public override void Shoot()
        {
            if (CheckCoolDown())
            {
                switch (ShipWeapon)
                {
                    case "Bullet":
                        new Bullet(this.X, this.Y - 10);
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

        public void SetGraph()
        {
            TopLeftX = this.X;
            TopLeftY = this.Y;
            BottomRightX = this.X + this.Width;
            BottomRightY = this.Y + this.Height;
            Contour.Add(new Point(this.X, this.Y));
            Contour.Add(new Point(this.X, this.Y + this.Height));
            Contour.Add(new Point(this.X + this.Width, this.Y));
            Contour.Add(new Point(this.X + this.Width, this.Y + this.Height));
        }

        public List<GameObject> IsHit()
        {
            //GameMgr.Search_KD_Tree(root, 150, 150, 350, 350);
            return null;
        }
    }
}
