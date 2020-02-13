using System;
using System.Threading;

namespace P1_Learning.Models
{
    public class Lambda
    {   
        // LAMBDA - () - oznacza to co funkcja przyjmuje
        // LAMBDA - Action - nie zwraca jest typu void
        private delegate int Add(int x, int y);
        public delegate void Write(string message);
        public void Test()
        {
            Action writer = () => Console.WriteLine("Writing...");
            writer();

            Action<string, int> advanceWriter = (message, number) => Console.WriteLine($"{message},{number}"); 
            advanceWriter("hello", 5);

            Func<int,int,int> adder = (x,y) => x + y; 
            // lub
            // Func<int,int,int> adder = (x,y) => { return x + y; }; 
            int result = adder(1,2);
            advanceWriter("Suma", result);

            Action<int, string> logger = (temperature, message) =>
            {
                Console.WriteLine($"Temperatura wynosi: {temperature}, {message}");
            };

            CheckTemperature(t => logger(t, "too low"), 
            t => logger(t, "optimal"), 
            t => logger(t, "too high"));
        }

         public void CheckTemperature(Action<int> tooLow, Action<int> optimal, Action<int> tooHigh)
        {
            var temperature = 10;
            var random = new Random();

            while(true)
            {
                var change = random.Next(-5,5);
                temperature += change;
                Console.WriteLine($"Temperatura: {temperature}");
                if(temperature <= 0)
                    tooLow(temperature);
                else if(temperature > 0 && temperature <= 10)
                    optimal(temperature);
                else 
                    tooHigh(temperature);

                Thread.Sleep(500);
            }
        }
    }
}