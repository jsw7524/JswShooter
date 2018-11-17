using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class GameObject
    {
        public int ID { get; }
        static int number;
        public int HP { get; set; }
        public int Speed { get; set; }
        protected int X { get; set; }
        protected int Y { get; set; }
        protected int Height { get; set; }
        protected int Width { get; set; }

        public GameObject()
        {
            ID = number;
            number++;
            GameMgr.GameObjects.Add(this);
        }

        public virtual void DoSomething()
        {


        }

        public void IsDeleted()
        {
            if (HP <= 0)
            {
                if (this is IDrawable)
                {
                    var g = this as IDrawable;
                    foreach (var p in g.Contour)
                    {
                        GameMgr.GameObjectDictionary.Remove(p);
                    }
                }
                GameMgr.GameObjects.Remove(this);
            }

        }

    }
}
