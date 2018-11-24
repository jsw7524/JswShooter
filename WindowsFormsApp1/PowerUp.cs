using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class PowerUp : VisibleGameObject
    {
        public PowerUp(int x, int y, int width, int height, int speed, int hp) : base(x, y, width, height, speed, hp)
        {
        }

        public override void DoSomething()
        {

            base.DoSomething();
            Move(0, 0);
            SetGraph();
        }

        public override void Move(int x, int y)
        {
            this.Y += 1;
        }
    }
}
