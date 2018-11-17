using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class GameMgr
    {
        public static DataStructure GameDataStructure { get; set; }
        public Timer GameTimer { get; set; }

        public static List<GameObject> GameObjects { get; set; }

        public static DataStructure.KD_Node KdRoot { get; set; }

        public GameMgr(Timer t)
        {
            GameDataStructure = new DataStructure();
            GameTimer = t;
            GameObjects = new List<GameObject>();
            GameTimer.Tick += new EventHandler(RunGame);

            InitGame();
        }

        public void InitGame()
        {
            MyShip myShip = new MyShip(300, 300);
        }

        public void RunGame(Object myObject, EventArgs myEventArgs)
        {
            GameDataStructure.Points.Clear();

            var backup1 = GameObjects.ToList();
            foreach (var gobj in backup1)
            {
                if (gobj is IDrawable)
                {
                    var g = gobj as IDrawable;
                    GameDataStructure.Points.AddRange(g.Contour);
                }
            }
            KdRoot=GameDataStructure.Make_KD_Tree(GameDataStructure.Points, 0, 0, 1920, 1080, DataStructure.Axis.X);

            var backup2 = GameObjects.ToList();
            foreach (var gobj in backup2)
            {
                gobj.DoSomething();
            }
        }

    }

}
