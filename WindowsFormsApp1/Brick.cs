using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Brick : VisibleGameObject, IMovable
    {
        public Brick(int x, int y) : base(x, y, 5, 5, 0, 2)
        {

        }

        public override void DoSomething()
        {

            base.DoSomething();
            this.IsHit();
            Move(0, 0);
            SetGraph();
            //Debug.Print(this.HP.ToString());
        }

        public void Move(int x, int y)
        {
            this.Y += 1;
        }

    }
}
