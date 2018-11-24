using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public static class GameMgr
    {
        public static DataStructure GameDataStructure { get; set; }
        public static Timer GameTimer { get; set; }

        public static List<GameObject> GameObjects { get; set; }

        public static DataStructure.KD_Node KdRoot { get; set; }

        public static Dictionary<Point, GameObject> GameObjectDictionary { get; set; }

        public static int OffSetX { get; set; }
        public static int OffSetY { get; set; }
        public static void SetGameMgr(Timer t)
        {
            OffSetX = 0;
            OffSetY = 0;
            GameDataStructure = new DataStructure();
            GameTimer = t;
            GameObjects = new List<GameObject>();
            GameTimer.Tick += new EventHandler(RunGame);
            GameObjectDictionary = new Dictionary<Point, GameObject>();
            InitGame();
        }


        class PlotEnemy
        {
            public int time;
            public string enemyType;
            public int x;
            public int y;
        }
        class Plot
        {
            public List<PlotEnemy> Enemies;
        }

        static Plot GamePlot = new Plot();

        public static void InitGame()
        {
            GamePlot = JsonConvert.DeserializeObject<Plot>(File.ReadAllText("PLOT.txt"));
            GamePlot.Enemies = GamePlot.Enemies.OrderBy(t => t.time).ToList();

            MyShip myShip = new MyShip(300, 300);
            //new FriendShip(myShip.X , myShip.Y,0);
            new FriendShip(myShip.X, myShip.Y, 0);
            new FriendShip(myShip.X, myShip.Y, 1 * 2 * Math.PI / 12);
            new FriendShip(myShip.X, myShip.Y, 2 * 2 * Math.PI / 12);
            new FriendShip(myShip.X, myShip.Y, 3 * 2 * Math.PI / 12);
            new FriendShip(myShip.X, myShip.Y, 4 * 2 * Math.PI / 12);
            new FriendShip(myShip.X, myShip.Y, 5 * 2 * Math.PI / 12);

            new FriendShip(myShip.X, myShip.Y, 6 * 2 * Math.PI / 12);
            new FriendShip(myShip.X, myShip.Y, 7 * 2 * Math.PI / 12);
            new FriendShip(myShip.X, myShip.Y, 8 * 2 * Math.PI / 12);
            new FriendShip(myShip.X, myShip.Y, 9 * 2 * Math.PI / 12);
            new FriendShip(myShip.X, myShip.Y, 10 * 2 * Math.PI / 12);
            new FriendShip(myShip.X, myShip.Y, 11 * 2 * Math.PI / 12);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    EnemyShip enemyShip1 = new EnemyShip(i * 30 + 300, j * 30 + 100);
                }
            }

            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Brick brick = new Brick(i * 5 + 200, j * 5 + 200);
                }
            }

        }

        public static void RunGame(Object myObject, EventArgs myEventArgs)
        {
            OffSetX++;
            OffSetY++;

            foreach (var gp in GamePlot.Enemies)
            {
                if (gp.time == OffSetY)
                {
                    switch (gp.enemyType)
                    {
                        case "EnemyShip":
                            new EnemyShip(gp.x, gp.y);
                            break;
                        case "FirstAidKit":
                            new FirstAidKit(gp.x, gp.y);
                            break;
                        case "PowerUpBullet":
                            new PowerUpBullet(gp.x, gp.y);
                            break;
                    }
                }
            }

            var backup0 = GameObjects.ToList();
            foreach (var gobj in backup0)
            {
                gobj.IsDeleted();
            }
            GameDataStructure.Points.Clear();

            var backup1 = GameObjects.ToList();
            foreach (var gobj in backup1)
            {
                if (gobj is VisibleGameObject)
                {
                    var g = gobj as VisibleGameObject;
                    GameDataStructure.Points.AddRange(g.Contour);
                }
            }
            KdRoot = GameDataStructure.Make_KD_Tree(GameDataStructure.Points, 0, 0, 1920, 1080, DataStructure.Axis.X);

            var backup2 = GameObjects.ToList();
            foreach (var gobj in backup2)
            {
                gobj.DoSomething();
            }
        }

    }

}
