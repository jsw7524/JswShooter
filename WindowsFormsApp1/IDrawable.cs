using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    interface IDrawable
    {
        int TopLeftX { get; set; }
        int TopLeftY { get; set; }
        int BottomRightX { get; set; }
        int BottomRightY { get; set; }

        List<Point> Contour { get; set; }

        void SetGraph();

        List<GameObject> IsHit();

    }
}
