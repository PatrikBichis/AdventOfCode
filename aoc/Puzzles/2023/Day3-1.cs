using aoc2020;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc23.Puzzles._2023
{
    internal class Day3_1 : PuzzelBase, IPuzzel
    {
        public Day3_1(InputType test) : base(test, 3, year: 2023)
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
                    for (var j=0; j< Input[i].Length; j++)
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
                        else if(Char.IsDigit(c) && fillingNumber)
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
                        if(!Char.IsDigit(c) && c != '.')
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

                Answer = validNumbers.Sum(x => x.Value).ToString();
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

            public void Validate(List<Symbols> symbols) 
            { 
                // Check above
                for(int i = X-1; i < X + Length + 1; i++)
                {
                    if (symbols.FirstOrDefault(x => x.Y == Y - 1 && x.X == i) != null)
                    {
                        Valid = true;
                        return;
                    }
                }

                // Check left
                if (symbols.FirstOrDefault(x => x.Y == Y && x.X == X - 1) != null)
                {
                    Valid = true;
                    return;
                }

                // Check right
                if (symbols.FirstOrDefault(x => x.Y == Y && x.X == X + Length) != null)
                {
                    Valid = true;
                    return;
                }

                // Check below
                for (int i = (X - 1); i < (X + Length + 1); i++)
                {
                    if (symbols.FirstOrDefault(x => x.Y == Y + 1 && x.X == i) != null)
                    {
                        Valid = true;
                        return;
                    }
                }
            }
        }

        public class  Symbols
        {
            public int X = 0;
            public int Y = 0;
            public char Character;
        }
    }
}