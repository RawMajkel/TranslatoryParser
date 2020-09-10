using Sprache;
using System;
using TranslatoryParser.Common;

namespace TranslatoryParser.App
{
    class Program
    {
        static void Main(string[] args)
        {
            while (Prompt(out string expression))
            {
                Console.Clear();

                try
                {
                    var parsed = Parser.ParseExpression(expression);
                    Console.WriteLine("Parsed expression: {0}", parsed);
                    Console.WriteLine("Result: {0}", parsed.Compile()());
                }
                catch (ParseException ex)
                {
                    Console.WriteLine("There was a problem with your input: {0}", ex.Message);
                }

                Console.WriteLine();
            }
        }

        static bool Prompt(out string value)
        {
            Console.Write("Enter a numeric expression (1 + 15), or 'q' to quit: ");
            var line = Console.ReadLine();

            Console.WriteLine(Environment.NewLine);

            if (line.ToLowerInvariant().Trim() == "q")
            {
                value = null;
                return false;
            }
            else
            {
                value = line;
                return true;
            }
        }
    }
}
