using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class EnemyShipAce: EnemyShip
    {
        private double lastRad=-Math.PI;
        public EnemyShipAce(int x, int y) : base(x, y,5)
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
            double radarDistance = 2000.00;
            double[] radar = new double[360];
            var nearbyVisibleGameObjects = GameMgr.GameObjects.OfType<VisibleGameObject>().Where(a =>a!=this).Where(a=> radarDistance > MeasureDistance(X-a.X,Y-a.Y));

            double minDangerousValue = 99999999.0;
            double minRad = -Math.PI;
            for (double rad =-Math.PI; rad < Math.PI; rad += Math.PI/16)
            {
                double dangerousValue = 0.0;
                if (rad == lastRad)
                {
                    dangerousValue -= 1.0;
                }
                
                foreach (var nearbyVisibleGameObject in nearbyVisibleGameObjects)
                {
                    //var distance = Cosines(Speed, MeasureDistance(X - nearbyVisibleGameObject.X, Y - nearbyVisibleGameObject.Y), (DegreesToRad(degrees) - Math.Atan(((double)Y - nearbyVisibleGameObject.Y) / ((double)X - nearbyVisibleGameObject.X))));

                    //distanceLeft = Cosines(Speed, MeasureDistance(X - nearbyVisibleGameObject.X, Y - nearbyVisibleGameObject.Y),
                    //     Math.Abs(0 + Math.Atan2(Y - nearbyVisibleGameObject.Y, X - nearbyVisibleGameObject.X)));

                    //distanceRight = Cosines(Speed, MeasureDistance(X - nearbyVisibleGameObject.X, Y - nearbyVisibleGameObject.Y),
                    //     Math.Abs(-Math.PI + Math.Atan2(Y - nearbyVisibleGameObject.Y, X - nearbyVisibleGameObject.X)));

                    //distanceUp = Cosines(Speed, MeasureDistance(X - nearbyVisibleGameObject.X, Y - nearbyVisibleGameObject.Y),
                    //    Math.Abs(-Math.PI / 2 + Math.Atan2(Y - nearbyVisibleGameObject.Y, X - nearbyVisibleGameObject.X)));

                    //distanceDown = Cosines(Speed, MeasureDistance(X - nearbyVisibleGameObject.X, Y - nearbyVisibleGameObject.Y),
                    //    Math.Abs(+Math.PI / 2 + Math.Atan2(Y - nearbyVisibleGameObject.Y, X - nearbyVisibleGameObject.X)));

                    //rad = Math.Atan2(Y - nearbyVisibleGameObject.Y, X - nearbyVisibleGameObject.X);

                    //measureDistance = MeasureDistance(X - nearbyVisibleGameObject.X, Y - nearbyVisibleGameObject.Y);

                    var distance = Cosines(Speed, MeasureDistance(X - nearbyVisibleGameObject.X, Y - nearbyVisibleGameObject.Y),
                         Math.Abs(rad + Math.Atan2(Y - nearbyVisibleGameObject.Y, X - nearbyVisibleGameObject.X)));

                    if (nearbyVisibleGameObject is EnemyShip)
                    {
                        dangerousValue += (radarDistance / distance) * 1;
                    }
                    else if (nearbyVisibleGameObject is FriendBullet)
                    {
                        dangerousValue += (radarDistance / distance) * 2;
                    }
                    else if (nearbyVisibleGameObject is Brick)
                    {
                        //dangerousValue += (radarDistance / distance) * 0.2;
                        dangerousValue += Math.Pow(2, 60.0 / distance) * 1;
                    }
                    if (nearbyVisibleGameObject is Laser)
                    {
                        dangerousValue += (radarDistance / distance) * 100;
                    }
                    if (nearbyVisibleGameObject is MyShip)
                    {
                        dangerousValue = (radarDistance / distance) * -150;
                    }
                }
                if (minDangerousValue > dangerousValue)
                {
                    minDangerousValue = dangerousValue;
                    minRad = rad;
                }
            }
            
            this.X += -1*(int)(Speed * Math.Cos(minRad));
            this.Y += (int)(Speed * Math.Sin(minRad));
            lastRad = minRad;
            //if (this.X <= 0)
            //{
            //    this.X = 1;
            //}
            //if (this.X >= 1920)
            //{
            //    this.X = 1919;
            //}
            //if (this.Y <= 0)
            //{
            //    this.Y = 1;
            //}
            //if (this.Y >= 1080)
            //{
            //    this.Y = 1079;
            //}

            SetGraph();
        }

        public override void Shoot()
        {
            MyShip myship = GameMgr.GameObjects.FirstOrDefault() as MyShip;

            if (CheckCoolDown(ShipWeapon))
            {

                switch (ShipWeapon)
                {
                    case "Bullet":
                        new EnemyBullet(this.X, this.Y + 20, Convert.ToInt32(-1 * 2 * Math.Cos(lastRad)), Convert.ToInt32(2* Math.Sin(lastRad)) );
                        break;
                }
            }

        }
    }
}
