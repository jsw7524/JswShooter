using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class GameMgr
    {
        public static DataStructure GameDataStructure { get; set; }
        public static Timer GameTimer { get; set; }

        public static List<GameObject> GameObjects { get; set; }

        public static DataStructure.KD_Node KdRoot { get; set; }

        public static Dictionary<Point,GameObject> GameObjectDictionary { get; set; }

        public static void SetGameMgr(Timer t)
        {
            GameDataStructure = new DataStructure();
            GameTimer = t;
            GameObjects = new List<GameObject>();
            GameTimer.Tick += new EventHandler(RunGame);
            GameObjectDictionary = new Dictionary<Point, GameObject>();
            InitGame();
        }

        public static void InitGame()
        {
            MyShip myShip = new MyShip(300, 300);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    EnemyShip enemyShip1 = new EnemyShip(i * 30 + 300, j*30+100);
                }
                   
            }

        }

        public static void RunGame(Object myObject, EventArgs myEventArgs)
        {
            var backup0 = GameObjects.ToList();
            foreach (var gobj in backup0)
            {
                gobj.IsDeleted();
            }


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
