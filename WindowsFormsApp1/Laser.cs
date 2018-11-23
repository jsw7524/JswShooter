using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Laser:Weapon, IMovable
    {
        public int Ax { get; set; }
        public int Ay { get; set; }
        static public int CoolDownTime { get; set; } = 1;
        public Laser(int x, int y, int ax, int ay) : base(x, y-200, 5, 190, 10, 1,1)
        {
            Ax = ax;
            Ay = ay;
        }
        public void Move(int x, int y)
        {
            this.X += x * Speed;
            this.Y += y * Speed;
            SetGraph();
        }


        public override void DoSomething()
        {
            base.DoSomething();
            this.Move(Ax, Ay);
            IsHit();
        }
        public override List<GameObject> IsHit()
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
                gobj.HP = -1;
            }

            return null;
        }

    }
}
