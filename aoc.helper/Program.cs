using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc.helper
{
    class Program
    {
        private static string inputPath = "../../../../Input/";
        private static string puzzlePath = "../../../../Puzzles/";

        static void Main(string[] args)
        {
            var key = ConsoleKey.A;

            while (key != ConsoleKey.Escape)
            {
                if (key == ConsoleKey.D1)
                {
                    CheckAndCreateInputFiles(inputPath);
                    CheckAndCreatePuzzleFiles(puzzlePath);
                }
                if (key == ConsoleKey.D2)
                {
                    CheckAndCreateInputFiles(inputPath);
                }
                if (key == ConsoleKey.D3)
                {
                    CheckAndCreatePuzzleFiles(puzzlePath);
                }

                PrintMenu();

                key = Console.ReadKey().Key;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("AOC CLI");
            Console.WriteLine("---------------------");
            Console.WriteLine("");
            Console.WriteLine("1. Generate all files");
            Console.WriteLine("2. Generate input files");
            Console.WriteLine("3. Generate c# files");
            Console.WriteLine("");
            Console.WriteLine("Press esc to exit...");
        }

        private static void CheckAndCreatePuzzleFiles(string path)
        {
            var files = Directory.EnumerateFiles(path).ToList();

            for (var i = 1; i < 26; i++)
            {
                for (var j = 1; j < 3; j++)
                {
                    if (!files.Contains(path + "Day" + i + "-" + j + ".cs"))
                    CreatePuzzleFileFile(i, j, true, path);
                }
            }
        }

        private static void CreatePuzzleFileFile(int day, int part, bool v, string path)
        {
            var file = "Day" + day + "-" + part + ".cs";
            Console.WriteLine("Created " + file + ".");

            string classFile =
                "using System; " + Environment.NewLine +
                "using System.Collections.Generic;" + Environment.NewLine +
                "using System.Linq;" + Environment.NewLine +
                "using System.Text;" + Environment.NewLine +
                "using System.Threading.Tasks;" + Environment.NewLine +
                "" + Environment.NewLine +
                "namespace aoc2020" + Environment.NewLine +
                "{" + Environment.NewLine +
                "   public class Day" + day + "_" + part + " : PuzzelBase, IPuzzel" + Environment.NewLine +
                "   {" + Environment.NewLine +
                "" + Environment.NewLine +
                "       public Day" + day + "_" + part + "(InputType input) : base(input, " + day + ", " + part + ")" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "           " + Environment.NewLine +
                "       }" + Environment.NewLine +
                "" + Environment.NewLine +
                "       public IPuzzel Run()" + Environment.NewLine +
                "       {" + Environment.NewLine +
                "" + Environment.NewLine +
                "" + Environment.NewLine +
                "           return this;" + Environment.NewLine +
                "       }" + Environment.NewLine +
                "" + Environment.NewLine +
                "   }" + Environment.NewLine +
                "} ";

            File.WriteAllText(path + file, classFile);
        }

        private static void CheckAndCreateInputFiles(string path)
        {
            var files = Directory.EnumerateFiles(path).ToList();

            for (var i = 1; i < 26; i++)
            {
                if (!files.Contains(path + i + "-input.txt"))
                    CreateInputFile(i, true, path);

                if (!files.Contains(path + i + "-test.txt"))
                    CreateInputFile(i, false, path);
            }
        }

        private static void CreateInputFile(int day, bool input, string path)
        {
            var file = day + (input ? "-input.txt" : "-test.txt");
            Console.Write("WriteLine " + file + ".");
            File.Create(path + file);
        }
    }
}
