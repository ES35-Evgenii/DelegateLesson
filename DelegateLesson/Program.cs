using System;

namespace DelegateLesson
{
    public class Car
    {
        int speed = 0; //поле
        public delegate void TooFast(int currentSpeed); //делегат "Слишком быстро", передаем int "текущую скорость"

        private TooFast tooFast; //поле делегата

        public void Start()
        {
            speed = 10;
        }

        public void Accelerate()
        {
            speed += 10; //при каждом вызове метода скорость будет увеличиваться на 10 единиц

            if (speed > 80)
                tooFast(speed); //при скорость более 80 будет вызван делегат в который передается текущая скорость
        }

        public void Stop()
        {
            speed = 0;
        }

        public int ShowSpeed()
        {
            return speed;
        }

        public void RegisterOnTooFast(TooFast tooFast)
        {
            this.tooFast += tooFast;
        }
    }

    class Program
    {
        static Car car;

        static void Main(string[] args)
        {
            car = new Car();
            car.RegisterOnTooFast(HandleOnTooFast);//"подписка" на события

            car.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Скорость = {car.ShowSpeed()}");
                car.Accelerate();
            }


            Console.ReadLine();
        }

        private static void HandleOnTooFast(int speed)
        {
            Console.WriteLine($"О, я понял, текущая скорость = {speed}! Вызываю метод остановки!");
            car.Stop();
        }
    }
}
