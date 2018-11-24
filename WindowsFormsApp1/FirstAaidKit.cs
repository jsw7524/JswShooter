using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class FirstAidKit: PowerUp
    {
        public FirstAidKit(int x, int y, int width=10, int height=10, int speed=1, int hp=100) : base(x, y, width, height, speed, hp)
        {
        }

    }
}
