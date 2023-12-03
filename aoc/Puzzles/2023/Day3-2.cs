using aoc2020;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc23.Puzzles._2023
{
    internal class Day3_2 : PuzzelBase, IPuzzel
    {
        public Day3_2(InputType test) : base(test, 3, year: 2023)
        {

        }

        public IPuzzel Run()
        {

            var numbers = new List<Number>();
            var symbols = new List<Symbols>();

            try
            {
                var fillingNumber = false;
                var number = new Number();
                var numberString = "";

                for (var i = 0; i < Input.Length; i++)
                {
                    for (var j = 0; j < Input[i].Length; j++)
                    {
                        var c = Input[i][j];

                        // Handle part numbers
                        if (Char.IsDigit(c) && !fillingNumber)
                        {
                            numberString = "";
                            number = new Number();
                            number.X = j; number.Y = i;
                            numberString += c;
                            fillingNumber = true;
                        }
                        else if (Char.IsDigit(c) && fillingNumber)
                        {
                            numberString += c;
                        }
                        else if (!Char.IsDigit(c) && fillingNumber)
                        {
                            number.Value = int.Parse(numberString);
                            number.Length = numberString.Length;

                            numbers.Add(number);

                            numberString = "";
                            fillingNumber = false;
                        }

                        // Handle symbols
                        if (!Char.IsDigit(c) && c != '.' && c == '*')
                        {
                            symbols.Add(new Symbols
                            {
                                Character = c,
                                X = j,
                                Y = i
                            });
                        }
                    }
                }

                // Validate part numbers
                numbers.ForEach(number => number.Validate(symbols));

                var validNumbers = numbers.Where(x => x.Valid).ToList();

                var ratios = new List<int>();

                symbols.ForEach(symbol =>
                {
                    var numbers = validNumbers.Where(x=>x.SymbolX == symbol.X && x.SymbolY == symbol.Y).ToList();

                    if(numbers.Count == 2)
                    {
                        ratios.Add(numbers[0].Value * numbers[1].Value);
                    }
                });

                Answer = ratios.Sum().ToString();
            }
            catch (Exception ex)
            {
                Answer = "Error: " + ex.Message;
                return this;
            }

            return this;
        }

        public class Number
        {
            public int X = 0;
            public int Y = 0;
            public int Length = 0;
            public bool Vertical = false;
            public int Value = 0;
            public bool Valid = false;

            public int SymbolX = -1;
            public int SymbolY = -1;

            public void Validate(List<Symbols> symbols)
            {
                // Check left
                var symbol = symbols.FirstOrDefault(x => x.Y == Y && x.X == X - 1);
                if (symbol != null)
                {
                    SymbolX = symbol.X;
                    SymbolY = symbol.Y;
                    Valid = true;
                    return;
                }

                // Check above
                for (int i = X - 1; i < X + Length + 1; i++)
                {
                    symbol = symbols.FirstOrDefault(x => x.Y == Y - 1 && x.X == i);
                    if (symbol != null)
                    {
                        SymbolX = symbol.X;
                        SymbolY = symbol.Y;
                        Valid = true;
                        return;
                    }
                }

                // Check right
                symbol = symbols.FirstOrDefault(x => x.Y == Y && x.X == X + Length);
                if (symbol != null)
                {
                    SymbolX = symbol.X;
                    SymbolY = symbol.Y;
                    Valid = true;
                    return;
                }

                // Check below
                for (int i = (X - 1); i < (X + Length + 1); i++)
                {
                    symbol = symbols.FirstOrDefault(x => x.Y == Y + 1 && x.X == i);
                    if (symbol != null)
                    {
                        SymbolX = symbol.X;
                        SymbolY = symbol.Y;
                        Valid = true;
                        return;
                    }
                }
            }
        }

        public class Symbols
        {
            public int X = 0;
            public int Y = 0;
            public char Character;
        }
    }
}
