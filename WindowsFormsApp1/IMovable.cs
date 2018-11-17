using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    interface IMovable
    {
        int Speed { set; get; }
        void Move(int x, int y);
    }
}
