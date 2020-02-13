using System;
using P1_Learning.Models;

namespace P1_Learning
{
    class Program
    {
        public delegate void Alert(int number);
        static void Main(string[] args)
        {
            //var myDelegateClass = new Delegates();
            //myDelegateClass.Test();

            //var myLambdaClass = new Lambda();
            //myLambdaClass.Test();

            Program program = new Program();
            program.Test();
        }

        public void Test()
        {
            MyLoop(TooSmall, TooBig, IsCorrect);
        }

        public void MyLoop(Alert smaller, Alert bigger, Alert valid)
        {   
            var random = new Random();
            int randomVariable = random.Next(0,100);

            while(true)
            {   
                Console.WriteLine("Podaj liczbe:");
                int number = Int32.Parse(Console.ReadLine());

                if(number < randomVariable)
                    smaller(number);
                else if(number > randomVariable)
                    bigger(number);
                else
                    valid(number);
            }
        }

        public void TooSmall(int number)
        {
            Console.WriteLine($"{number} is too small. Try again.");
        }

        public void TooBig(int number)
        {
            Console.WriteLine($"{number} is too big. Try again.");
        }

        public void IsCorrect(int number)
        {
            Console.WriteLine($"{number} is correct, you won.");
            System.Environment.Exit(0);
        }
    }
}
