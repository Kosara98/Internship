using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    class Program
        {
        static void Main(string[] args)
        {
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));

            //Expression tree
            System.Linq.Expressions.Expression<Func<int, int>> e = x => x * x;
            Console.WriteLine(e);

            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);
            Console.WriteLine(string.Join(" ", squaredNumbers));

            //Expression lambdas
            Func<int, int, bool> testForEquality = (x, y) => x == y;
            Console.WriteLine(testForEquality(5,6));

            //Statement lambdas
            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };
            greet("World");

            //Type inference in lambda expressions
            var game = new VariableCaptureGame();

            int gameInput = 5;
            game.Run(gameInput);

            int jTry = 10;
            bool result = game.isEqualToCapturedLocalVariable(jTry);
            Console.WriteLine($"Captured local variable is equal to {jTry}: {result}");

            int anotherJ = 3;
            game.updateCapturedLocalVariable(anotherJ);

            bool equalToAnother = game.isEqualToCapturedLocalVariable(anotherJ);
            Console.WriteLine($"Another lambda observes a new value of captured variable: {equalToAnother}");
        }
    }
}
