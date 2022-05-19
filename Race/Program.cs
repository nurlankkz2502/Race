using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace Race
{

    abstract class Object
    {
        protected int x;
        protected int y;

        public abstract void Create(int x, int y);
        public abstract void Delete();
        public abstract void Show();
        public abstract void Move();
    }
    class FinishLine : Object
    {
        char[,] o = new char[2, 36];
        public int Coordinate_X { get { return x; } set { x = value; } }
        public int Coordinate_Y { get { return y; } set { y = value; } }
        public override void Create(int x, int y)
        {
            Random rnd = new Random();

            Coordinate_X = -10;
            Coordinate_Y = 2;
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 36; j++)
                    o[i, j] = '|';

        }
        public override void Show()
        {
            for (int i = 0; i < 2; i++)
            {
                if ((Coordinate_X + i <= 41) && (Coordinate_X + i >= 0))
                {
                    Console.SetCursorPosition(Coordinate_Y, Coordinate_X + i);
                    for (int j = 0; j < 36; j++)
                        Console.Write(o[i, j]);
                }
            }
        }
        public override void Delete()
        {

            for (int i = 0; i < 2; i++)
            {
                if ((Coordinate_X + i <= 41) && (Coordinate_X + i >= 0))
                {
                    Console.SetCursorPosition(Coordinate_Y, Coordinate_X + i);
                    for (int j = 0; j < 36; j++)
                        Console.Write(' ');
                }
            }
        }
        public override void Move()
        {
            Coordinate_X++;
        }

    }


    class MyObstacle : Object
    {
        char[,] o = new char[2, 3];
        public int Coordinate_X { get { return x; } set { x = value; } }
        public int Coordinate_Y { get { return y; } set { y = value; } }
        public override void Create(int x, int y)
        {
            Random rnd = new Random();

            Coordinate_X = -10;
            Coordinate_Y = rnd.Next(1, 28);
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 3; j++)
                    o[i, j] = 'X';

        }
        public override void Show()
        {
            for (int i = 0; i < 2; i++)
            {
                if ((Coordinate_X + i <= 41) && (Coordinate_X + i >= 0))
                {
                    Console.SetCursorPosition(Coordinate_Y, Coordinate_X + i);
                    for (int j = 0; j < 3; j++)
                        Console.Write(o[i, j]);
                }
            }
        }
        public override void Delete()
        {

            for (int i = 0; i < 2; i++)
            {
                if ((Coordinate_X + i <= 41) && (Coordinate_X + i >= 0))
                {
                    Console.SetCursorPosition(Coordinate_Y, Coordinate_X + i);
                    for (int j = 0; j < 3; j++)
                        Console.Write(' ');
                }
            }
        }
        public override void Move()
        {
            Coordinate_X++;
        }

    }
    class MyCar : Object
    {
        public int Speed = 60; //начальная скорость машины

        public int Position;
        public bool pos = false;
        char[,] a = new char[9, 5];

        public int MoveCount = 0;

        public bool CrashCondition = false;
        public void Overtaking(MyCar Rival)
        {


            if (Rival.Coordinate_X > this.Coordinate_X)
            { this.pos = false; }
            else if (Rival.Coordinate_X < this.Coordinate_X)
            { Rival.Position--; ; this.pos = false; }


        }
        public void SamePosition(MyCar Rival)
        {
            if (Rival.Position < this.Position)
                this.Position = Rival.Position;
            else
                Rival.Position = this.Position;
            this.pos = true;
        }
        public int Coordinate_X { get { return x; } set { x = value; } }
        public int Coordinate_Y { get { return y; } set { y = value; } }
        public override void Create(int x, int y)
        {
            Coordinate_X = x;
            Coordinate_Y = y;

            a[0, 0] = ' ';
            a[0, 1] = '#';
            a[0, 2] = '#';
            a[0, 3] = '#';
            a[0, 4] = ' ';
            a[1, 0] = ' ';
            a[1, 1] = ' ';
            a[1, 2] = '#';
            a[1, 3] = ' ';
            a[1, 4] = ' ';
            a[2, 0] = '@';
            a[2, 1] = '#';
            a[2, 2] = '#';
            a[2, 3] = '#';
            a[2, 4] = '@';
            a[3, 0] = ' ';
            a[3, 1] = '/';
            a[3, 2] = '#';
            a[3, 3] = '\\';
            a[3, 4] = ' ';
            a[4, 0] = ' ';
            a[4, 1] = '#';
            a[4, 2] = '#';
            a[4, 3] = '#';
            a[4, 4] = ' ';
            a[5, 0] = ' ';
            a[5, 1] = '#';
            a[5, 2] = '#';
            a[5, 3] = '#';
            a[5, 4] = ' ';
            a[6, 0] = ' ';
            a[6, 1] = '#';
            a[6, 2] = '☺';
            a[6, 3] = '#';
            a[6, 4] = ' ';
            a[7, 0] = '@';
            a[7, 1] = '#';
            a[7, 2] = '#';
            a[7, 3] = '#';
            a[7, 4] = '@';
            a[8, 0] = '#';
            a[8, 1] = '#';
            a[8, 2] = '#';
            a[8, 3] = '#';
            a[8, 4] = '#';

        }

        public override void Show()
        {
            for (int i = 0; i < 9; i++)
            {
                if ((Coordinate_X + i <= 41) && (Coordinate_X + i >= 0))
                {
                    Console.SetCursorPosition(Coordinate_Y, Coordinate_X + i);
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(a[i, j]);
                    }
                }
            }
        }
        public override void Delete()
        {
            for (int i = 0; i < 9; i++)
            {
                if (Coordinate_X + i >= 0)
                {
                    Console.SetCursorPosition(Coordinate_Y, Coordinate_X + i);
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(' ');
                    }
                }

            }
        }
        public void Moves(int x, int pos)//движение машины противника
        {

            if (x == 500)
                MoveCount -= 10;
            if (x == 470)
                MoveCount -= 9;
            if (x == 440)
                MoveCount -= 8;
            if (x == 410)
                MoveCount -= 7;
            if (x == 380)
                MoveCount -= 6;
            if (x == 350)
                MoveCount -= 5;
            if (x == 320)
                MoveCount -= 4;
            if (x == 290)
                MoveCount -= 3;
            if (x == 260)
                MoveCount -= 2;
            if (x == 230)
                MoveCount -= 1;
            if (x == 200)
                MoveCount += 0;
            if (x == 170)
                MoveCount += 3;
            if (x == 140)
                MoveCount += 6;
            if (x == 110)
                MoveCount += 9;
            if (x == 80)
                MoveCount += 12;
            if (x == 50)
                MoveCount += 15;
            if (x == 20)
                MoveCount += 18;
            if (MoveCount > 18)
            {
                Coordinate_X++;
                MoveCount = 0;
            }
            if (MoveCount < -9)
            {
                Coordinate_X--;
                MoveCount = 0;
            }

        }
        public override void Move()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        Coordinate_X--;
                        break;
                    case ConsoleKey.DownArrow:
                        Coordinate_X++;
                        break;
                    case ConsoleKey.LeftArrow:
                        Coordinate_Y--;
                        break;
                    case ConsoleKey.RightArrow:
                        Coordinate_Y++;
                        break;
                    default:
                        break;
                }
            }
        }

    }

    abstract class Road
    {
        public abstract void ChangeCarCoordinateX(int x);
        public abstract void CreateObstacle();
        public abstract bool CollisionObstacle();
        public abstract void ShowRoad();
    }
    class MyRoad : Road
    {


        public int N = 40;
        public int M = 37;
        public bool Finish = false;
        public MyCar ride = new MyCar();
        public FinishLine line = new FinishLine();

        public MyObstacle[] ObstacleArr;//массив для хранения препятсвий 
        public MyCar[] Cars;//массив для хранения машин противников
        public int ArrObsLength = 0;
        public int ArrCarLength = 0;
        public MyRoad()
        {
            this.SetTable();
        }

        public char[,] table = new char[44, 82];
        public override void CreateObstacle()
        {
            MyObstacle New = new MyObstacle();

            New.Create(0, 0);
            ArrObsLength++;
            Array.Resize<MyObstacle>(ref ObstacleArr, ArrObsLength);
            ObstacleArr[ObstacleArr.Length - 1] = New;

        }//Создать препятсвие
        public override void ChangeCarCoordinateX(int x)
        {
            if (CarColission() == 1)//ограничение на движение направо если машина соперника справа
            {
                if ((ride.Coordinate_Y + 10 <= M + 1) && (ride.Coordinate_Y >= 2))
                    ride.Coordinate_Y = ride.Coordinate_Y + x;
                else if ((x < 0) && (ride.Coordinate_Y + 10 >= M))
                    ride.Coordinate_Y = ride.Coordinate_Y + x;
                else if ((ride.Coordinate_Y <= 2) && (x > 0))
                    ride.Coordinate_Y = ride.Coordinate_Y + x;
            }
            else if (CarColission() == -1)//ограничение на движение налево если машина соперника слева
            {
                if ((ride.Coordinate_Y + 5 <= M + 1) && (ride.Coordinate_Y >= 7))
                    ride.Coordinate_Y = ride.Coordinate_Y + x;
                else if ((x < 0) && (ride.Coordinate_Y + 5 >= M))
                    ride.Coordinate_Y = ride.Coordinate_Y + x;
                else if ((ride.Coordinate_Y <= 7) && (x > 0))
                    ride.Coordinate_Y = ride.Coordinate_Y + x;
            }
            else
            {
                if ((ride.Coordinate_Y + 5 <= M + 1) && (ride.Coordinate_Y >= 2))
                    ride.Coordinate_Y = ride.Coordinate_Y + x;
                else if ((x < 0) && (ride.Coordinate_Y + 5 >= M))
                    ride.Coordinate_Y = ride.Coordinate_Y + x;
                else if ((ride.Coordinate_Y <= 2) && (x > 0))
                    ride.Coordinate_Y = ride.Coordinate_Y + x;
            }

        }
        public void CreateCar()//создать машину соперника
        {
            if (ArrCarLength == 0 && ride.Position != 1)
            {
                while (true)
                {
                    MyCar New = new MyCar();
                    Random rnd = new Random();

                    New.Create(-9, rnd.Next(1, 24));//конструктор с параметрами координаты машины. - 9 это координата за консолью. то есть машина создается сверху над консолью
                    New.Position = ride.Position - 1;
                    New.MoveCount = 12 - ride.Position;
                    bool x = true;
                    foreach (MyObstacle obs in ObstacleArr)//так же сверху создаются препятствия и здесь идет проверка что машина не создалась на препятсвии
                    {
                        if ((obs.Coordinate_Y + 3 >= New.Coordinate_Y) && (obs.Coordinate_Y < New.Coordinate_Y + 5) && (obs.Coordinate_X + 2 > New.Coordinate_X) && (obs.Coordinate_X + 2 < New.Coordinate_X + 9))
                        {
                            x = false;
                        }
                    }
                    if ((ride.Coordinate_Y >= New.Coordinate_Y - 9) && (ride.Coordinate_Y < New.Coordinate_Y + 5) && (ride.Coordinate_X + 6 >= New.Coordinate_X) && (ride.Coordinate_X + 6 < New.Coordinate_X + 9))
                    {
                        x = false;
                    }
                    if (x == true)//если все ок добавляю машину в массив
                    {
                        ArrCarLength++;//переменная которая содержит количество машин в массиве
                        Array.Resize<MyCar>(ref Cars, ArrCarLength);
                        Cars[Cars.Length - 1] = New;
                        break;
                    }
                }
            }
        }
        public int CarColission()
        {
            if (ArrCarLength != 0)
            {
                foreach (MyCar i in Cars)
                {
                    if ((i.Coordinate_X + 9 >= ride.Coordinate_X) && (i.Coordinate_X < ride.Coordinate_X + 9) && (i.Coordinate_Y == ride.Coordinate_Y + 5))
                    {
                        return 1;//машина соперника вплотную справа от гонщика
                    }
                    else if ((i.Coordinate_X + 9 >= ride.Coordinate_X) && (i.Coordinate_X < ride.Coordinate_X + 9) && (i.Coordinate_Y + 5 == ride.Coordinate_Y))
                    {
                        return -1;//машина соперника вплотную слева от гонщика
                    }
                    else if ((i.Coordinate_Y + 5 > ride.Coordinate_Y) && (i.Coordinate_Y < ride.Coordinate_Y + 5) && (i.Coordinate_X + 9 == ride.Coordinate_X))
                    {
                        return 2;//машина соперника вплотную перед гонщиком
                    }
                    else if ((i.Coordinate_Y + 5 > ride.Coordinate_Y) && (i.Coordinate_Y < ride.Coordinate_Y + 5) && (i.Coordinate_X == ride.Coordinate_X + 9))
                    {
                        return -2;//машина соперника вплотную позади гонщика
                    }
                    else
                        return 0;//не соприкасаются
                }

            }
            return 0;//не соприкасаются
        }//Гонщик касается машины соперника
        public void CheckPosition()
        {
            if (ArrCarLength != 0)
            {
                foreach (MyCar obj in Cars)
                {
                    if (obj.Coordinate_X == ride.Coordinate_X)
                        ride.SamePosition(obj);
                    if (ride.pos == true)
                        ride.Overtaking(obj);
                }
            }
        }
        public override void ShowRoad()
        {
            for (int i = 0; i <= N + 1; i++)
            {
                for (int j = 0; j <= M + 1; j++)
                {
                    if (j == 0 || j == M + 1)
                        Console.Write("#");
                    if (j <= M)
                        Console.Write(" ");
                    else
                        Console.WriteLine();
                }

            }
        }
        public void ShowScore()
        {
            Console.SetCursorPosition(0, N + 2);

            Console.WriteLine("\t  Speed: " + ride.Speed + " km/h");
            Console.WriteLine($"\n\t  Position {ride.Position}\t");

        }
        public override bool CollisionObstacle()//проверка столкновения машины с препятсвием
        {
            foreach (MyObstacle obs in ObstacleArr)
            {
                if ((obs.Coordinate_Y > ride.Coordinate_Y - 3) && (obs.Coordinate_Y < ride.Coordinate_Y + 5) && (obs.Coordinate_X + 2 > ride.Coordinate_X) && (obs.Coordinate_X < ride.Coordinate_X + 9))
                {
                    ride.CrashCondition = true;
                    return true;
                }
            }
            return false;
        }
        public bool RivalCollision()
        {
            if (ArrCarLength != 0)
            {
                foreach (MyCar obj in Cars)
                {
                    foreach (MyObstacle obs in ObstacleArr)
                    {
                        if ((obs.Coordinate_Y > obj.Coordinate_Y - 3) && (obs.Coordinate_Y < obj.Coordinate_Y + 5) && (obs.Coordinate_X + 2 > obj.Coordinate_X) && (obs.Coordinate_X < obj.Coordinate_X + 9))
                        {
                            obj.CrashCondition = true;
                            return true;

                        }
                    }
                    return false;
                }
            }
            return false;

        }
        public void MoveRival(int x)
        {
            RivalCollision();
            foreach (MyCar obj in Cars)
            {
                obj.Delete();
                if (obj.CrashCondition == false)
                {
                    if ((obj.Coordinate_Y + 5 <= M + 1) && (obj.Coordinate_Y >= 2))
                        obj.Coordinate_Y = obj.Coordinate_Y + x;
                    else if ((x < 0) && (obj.Coordinate_Y + 5 >= M))
                        obj.Coordinate_Y = obj.Coordinate_Y + x;
                    else if ((ride.Coordinate_Y <= 2) && (x > 0))
                        obj.Coordinate_Y = obj.Coordinate_Y + x;
                }
            }

        }
        public void ChangeCarCoordinateY(int y)
        {
            if ((ride.Coordinate_X + 9 < N + 2) && (ride.Coordinate_X > 0))
            {
                if (y > 0)
                    ride.Speed = ride.Speed - 15;
                else
                    ride.Speed = ride.Speed + 15;
                ride.Coordinate_X = ride.Coordinate_X + y;
            }
            else if ((y < 0) && (ride.Coordinate_X + 9 <= N + 2))
            {
                ride.Speed = ride.Speed + 15;
                ride.Coordinate_X = ride.Coordinate_X + y;
            }
            else if ((ride.Coordinate_X <= 0) && (y > 0))
            {
                ride.Speed = ride.Speed - 15;
                ride.Coordinate_X = ride.Coordinate_X + y;
            }
        }
        public void SetTable()
        {
            for (int i = 0; i <= N + 1; i++)//заполняем края
            {
                for (int j = 0; j <= M + 1; j++)
                {
                    if (j == 0 || j == M + 1)
                        table[i, j] = '#';

                }

            }

        }//рисуем обочину
        public void RivalCheckObstale()
        {
            if (ArrCarLength != 0)
            {
                foreach (MyCar car in Cars)//перемещение машин соперников
                {
                    foreach (MyObstacle obs in ObstacleArr)
                    {
                        if ((obs.Coordinate_Y > car.Coordinate_Y - 3) && (obs.Coordinate_Y < car.Coordinate_Y + 5) && (obs.Coordinate_X + 2 > car.Coordinate_X - 5) && (obs.Coordinate_X < car.Coordinate_X + 4))
                        {
                            int x;
                            if (CarColission() != 1)
                            {
                                car.Delete();
                                x = 1;
                                if ((car.Coordinate_Y + 5 <= M + 1) && (car.Coordinate_Y >= 2))
                                    car.Coordinate_Y = car.Coordinate_Y + 1;
                                else if ((x < 0) && (ride.Coordinate_Y + 5 >= M))
                                    car.Coordinate_Y = car.Coordinate_Y + x;
                                else if ((ride.Coordinate_Y <= 2) && (x > 0))
                                    car.Coordinate_Y = car.Coordinate_Y + x;
                            }
                            else if (CarColission() != -1)
                            {
                                car.Delete();
                                x = -1;
                                if ((car.Coordinate_Y + 5 <= M + 1) && (car.Coordinate_Y >= 2))
                                    car.Coordinate_Y = car.Coordinate_Y + 1;
                                else if ((x < 0) && (ride.Coordinate_Y + 5 >= M))
                                    car.Coordinate_Y = car.Coordinate_Y + x;
                                else if ((ride.Coordinate_Y <= 2) && (x > 0))
                                    car.Coordinate_Y = car.Coordinate_Y + x;
                            }

                        }
                    }
                }
            }
        }
        public void MoveCars(int speed)
        {
            int y = 12 - ride.Position;
            RivalCollision();
            int index = 0;
            int deleteIndex = -1;
            if (ArrCarLength != 0)
                foreach (MyCar car in Cars)//перемещение машин соперников
                {
                    car.Delete();
                    if (car.CrashCondition == true)
                    {
                        car.Coordinate_X++;
                    }
                    else
                    {
                        if (CarColission() != 2)
                            car.Moves(speed, y);
                    }
                    if (car.Coordinate_X == N + 1)
                    {
                        deleteIndex = index;
                    }
                    index++;



                }
            if (deleteIndex != -1)
            {
                Array.Clear(Cars, deleteIndex, 1);
                Cars = Cars.Where(x => x != null).ToArray();
                ArrCarLength--;
            }
        }
        public void MoveObstacle()
        {

            int index = 0;
            int deleteIndex = -1;

            foreach (MyObstacle obs in ObstacleArr)
            {


                obs.Delete();
                obs.Move();
                if (obs.Coordinate_X == N + 1)
                {
                    deleteIndex = index;
                }
                index++;
            }
            if (deleteIndex != -1)
            {
                Array.Clear(ObstacleArr, deleteIndex, 1);
                ObstacleArr = ObstacleArr.Where(x => x != null).ToArray();
                ArrObsLength--;
            }


        }
        public void AtFinish()
        {
            Finish = true;
            line.Create(-1, 2);

        }
        public void MoveFinish()
        {
            if (Finish == true)
            {
                line.Delete();
                line.Move();
            }
        }
        public bool CroosLine()
        {
            if (ride.Coordinate_X + 10 == line.Coordinate_X)
            { return true; }
            else
                return false;
        }

    }
    class Controller
    {
        public MyRoad road = new MyRoad();

        public void NextStep(int a, int c, int d, int e)
        {

            road.ride.Delete();
            if (c == 1800)
            {
                road.AtFinish();

            }
            if (a == 25 && road.Finish == false)
            {
                road.CreateObstacle();
            }
            if (c % 105 == 0)
            {
                road.CreateCar();
            }
            road.MoveObstacle();
            road.MoveFinish();
            road.MoveCars(e);
            road.RivalCheckObstale();
            road.CheckPosition();
            road.ShowScore();

            Show();




        }
        public void Show()
        {
            if (road.Finish == true)
            {
                road.line.Show();
            }
            foreach (MyObstacle obs in road.ObstacleArr)
            {
                obs.Show();
            }
            if (road.ArrCarLength != 0)
                foreach (MyCar obs in road.Cars)
                {
                    obs.Show();
                }

            road.ride.Show();
        }
        public int GameOver()
        {
            if (road.CollisionObstacle())
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\t\t\t YOU SUCK!");
                Console.WriteLine($"\n\n\t\t\tPOSITION {road.ride.Position}\t");
                return 1;
            }
            else if (road.CroosLine())
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\t\t\t YOU ARE WINNER!");
                Console.WriteLine($"\n\n\t\t\tPOSITION {road.ride.Position}\t");
                return 1;
            }
            return 0;
        }
        public void MoveCar(int x)
        {
            if (x == 1)//машину налево
            {
                road.ride.Delete();
                if (road.CarColission() == -1)
                {
                    road.MoveRival(-1);
                    road.ChangeCarCoordinateX(-1);//соперник слева и дивжение налево
                }
                else if (road.CarColission() == 1)
                {
                    road.ChangeCarCoordinateX(-1);//соперник справа и дивжение налево
                }
                else
                    road.ChangeCarCoordinateX(-1);
            }
            else if (x == 2)
            {
                road.ride.Delete();
                if (road.CarColission() == 1)
                {
                    road.MoveRival(1);
                    road.ChangeCarCoordinateX(1);
                }
                else if (road.CarColission() == -1)
                {
                    road.ChangeCarCoordinateX(1);
                }
                else
                    road.ChangeCarCoordinateX(1);
            }
            else if (x == 3)//перемещние машины наверх
            {
                road.ride.Delete();
                if (road.CarColission() != 2)
                    road.ChangeCarCoordinateY(-1);
            }
            else if (x == 4)
            {
                road.ride.Delete();
                if (road.CarColission() != -2)
                    road.ChangeCarCoordinateY(1);

            }
        }
        public void MoveLeft()
        {
            MoveCar(1);
        }
        public void MoveRight()
        {
            MoveCar(2);
        }
        public void MoveUp()
        {
            MoveCar(3);
        }
        public void MoveDown()
        {
            MoveCar(4);
        }

    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\n\t\t\tTHE RACE\n\n\n\n\t\t   PRESS SPACE TO PLAY");
            var keyInfo1 = Console.ReadKey();
            if (keyInfo1.KeyChar == ' ')
            {

                Console.Clear();
                Controller game = new Controller();
                game.road.ride.Create(33, 17);
                game.road.ride.Position = 12;
                game.road.CreateObstacle();
                game.road.SetTable();
                game.road.ShowRoad();
                game.road.ride.Show();


                int ObstacleStep = 1;
                int SpeedStep = 500;
                int Finish = 1;
                int CarsStep = 1;
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo cki = Console.ReadKey(true);
                        switch (cki.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (SpeedStep > 30)
                                    if (game.road.CarColission() != 2)
                                        SpeedStep -= 30;
                                game.MoveUp();
                                break;
                            case ConsoleKey.DownArrow:
                                if (SpeedStep < 500)
                                    if (game.road.CarColission() != -2)
                                        SpeedStep += 30;
                                    else if (SpeedStep > 500)
                                        SpeedStep = 0;
                                game.MoveDown();
                                break;
                            case ConsoleKey.LeftArrow:
                                game.MoveLeft();
                                break;
                            case ConsoleKey.RightArrow:
                                game.MoveRight();
                                break;
                            default:
                                break;
                        }
                    }


                    game.NextStep(ObstacleStep, Finish, CarsStep, SpeedStep);

                    if (ObstacleStep < 25)
                        ObstacleStep++;
                    else
                        ObstacleStep = 1;
                    if (CarsStep < 105)
                        CarsStep++;
                    else
                        CarsStep = 1;

                    Finish++;
                    if (game.GameOver() == 1)
                    {
                        break;
                    }

                    Thread.Sleep(SpeedStep);
                }
            }


            Console.ReadKey();

        }
    }

}

