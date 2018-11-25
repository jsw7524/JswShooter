using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class EnemyShipAce: EnemyShip
    {
        public EnemyShipAce(int x, int y) : base(x, y,100)
        {
        }
        double MeasureDistance(double a, double b)
        {
            return Math.Sqrt(a * a + b * b);
        }

        double DegreesToRad(double degrees)
        {
            var tmp = Math.PI * degrees / 180.0;

            return tmp;
        }

        double Cosines(double a, double b, double rad)
        {
            return Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(rad));
        }

        public double distanceUp;
        public double distanceDown;
        public double distanceLeft;
        public double distanceRight;
        public double rad;
        public double measureDistance;
        public override void Move(int x, int y)
        {
            double radarDistance = 1000.00;
            double[] radar = new double[360];
            var nearbyVisibleGameObjects = GameMgr.GameObjects.OfType<VisibleGameObject>().Where(a =>a!=this).Where(a=> radarDistance > MeasureDistance(X-a.X,Y-a.Y));

            for (double degrees =0; degrees<360; degrees+=1.0)
            {
                double dangerousValue = 0.0;
                foreach(var nearbyVisibleGameObject in nearbyVisibleGameObjects)
                {
                    //var distance=Cosines(Speed, MeasureDistance(X - nearbyVisibleGameObject.X, Y - nearbyVisibleGameObject.Y), (DegreesToRad(degrees)- Math.Atan(((double)Y - nearbyVisibleGameObject.Y)/ ((double)X - nearbyVisibleGameObject.X))));

                    distanceLeft = Cosines(Speed, MeasureDistance(X - nearbyVisibleGameObject.X, Y - nearbyVisibleGameObject.Y), 
                         Math.Atan2(Y-nearbyVisibleGameObject.Y, X-nearbyVisibleGameObject.X ));

                    distanceRight = Cosines(Speed, MeasureDistance(X - nearbyVisibleGameObject.X, Y - nearbyVisibleGameObject.Y),
                         Math.PI-Math.Atan2(Y - nearbyVisibleGameObject.Y, X - nearbyVisibleGameObject.X) );

                    distanceUp = Cosines(Speed, MeasureDistance(X - nearbyVisibleGameObject.X, Y - nearbyVisibleGameObject.Y),
                        Math.PI/2-Math.Atan2(Y - nearbyVisibleGameObject.Y, X - nearbyVisibleGameObject.X));

                    distanceDown = Cosines(Speed, MeasureDistance(X - nearbyVisibleGameObject.X, Y - nearbyVisibleGameObject.Y),
                        +Math.PI / 2 + Math.Atan2(Y - nearbyVisibleGameObject.Y, X - nearbyVisibleGameObject.X));

                    rad= Math.Atan2(Y - nearbyVisibleGameObject.Y, X - nearbyVisibleGameObject.X);

                    measureDistance = MeasureDistance(X - nearbyVisibleGameObject.X, Y - nearbyVisibleGameObject.Y);

                    //distanceUp = Cosines(Speed, MeasureDistance(X - nearbyVisibleGameObject.X, Y - nearbyVisibleGameObject.Y),
                    //    Math.PI - Math.Atan2(Y - nearbyVisibleGameObject.Y, X - nearbyVisibleGameObject.X));

                    //if (nearbyVisibleGameObject is EnemyShip)
                    //{
                    //    dangerousValue += (radarDistance / distance) * 1;
                    //}
                    //else if (nearbyVisibleGameObject is Bullet)
                    //{
                    //    dangerousValue += (radarDistance / distance) * 2;
                    //}
                    //else if (nearbyVisibleGameObject is Brick)
                    //{
                    //    dangerousValue += (radarDistance / distance) * 0.01;
                    //}
                    //if (nearbyVisibleGameObject is Laser)
                    //{
                    //    dangerousValue += (radarDistance / distance) * 100;
                    //}
                    //if (nearbyVisibleGameObject is MyShip)
                    //{
                    //    dangerousValue = (radarDistance * 100.00 / distance);
                    //}
                }
                radar[(int)degrees] = dangerousValue;
            }
            //////////////////
            double min = radar[45];
            double minIndex = 45;
            for (int i=0;i<360;i++)
            {
                if (min > radar[i])
                {
                    min = radar[i];
                    minIndex = i;
                }
            }
            ////////////////////
            
            //this.X += (int)(Speed * Math.Cos(DegreesToRad(minIndex)));
            //this.Y += (int)(Speed * Math.Sin(DegreesToRad(minIndex)));
            SetGraph();
        }

        public override void DoSomething()
        {
            //base.DoSomething();
            //this.IsHit();

            Move(0, 0);

            //Shoot();

        }
    }
}
