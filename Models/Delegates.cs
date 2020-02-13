using System;
using System.Threading;

namespace P1_Learning.Models
{
    public class Delegates
    {
        // DELEGATE - it can be use to callback's / it is a function pointer
        // DELEGATE - it is like a variable to which we can assign a function
        // DELEGATE - it can be use as parametr in function
        // DELEGATE - it can reference to multi functions
        // ctrl + c - terminate terminal
        private delegate int Add(int x, int y);
        public delegate void Write(string message);
         public delegate void Alert(int change);
        public void Test()
        {
            Add add = Addition;
            Write write = Console.WriteLine;
            Write write2 = WriteMessage;

            int result = add(5,3);

            write($"{result}");
            write("Hello from delegate...");
            write2("Hello from delegate2");
            CheckTemperature(TooLowAlert, OptimalAlert, TooHighAlert);
        }

        public void TooLowAlert(int change)
        {
            Console.WriteLine($"Temperature is too low {change}");
        }

        public void OptimalAlert(int change)
        {
            Console.WriteLine($"Temperature is optimal {change}");
        }

        public void TooHighAlert(int change)
        {
            Console.WriteLine($"Temperature is too high {change}");
        }
        public void CheckTemperature(Alert tooLow, Alert optimal, Alert tooHigh)
        {
            var temperature = 10;
            var random = new Random();

            while(true)
            {
                var change = random.Next(-5,5);
                temperature += change;
                Console.WriteLine($"Temperatura: {temperature}");
                if(temperature <= 0)
                    tooLow(change);
                else if(temperature > 0 && temperature <= 10)
                    optimal(change);
                else 
                    tooHigh(change);

                Thread.Sleep(500);
            }
        }
        private int Addition(int x, int y)
        {
            return x + y;
        }   

        private void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}