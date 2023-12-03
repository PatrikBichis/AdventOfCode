using aoc2020;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace aoc23.Puzzles._2023
{
    public class Day1_2 : PuzzelBase, IPuzzel
    {
        public Day1_2(InputType test) : base(test, 1, year: 2023)
        {

        }

        public IPuzzel Run()
        {
            var numbers = new List<int>();
            var digitsAsLetter = new List<DigitAsLetter>()
            {
                new DigitAsLetter("one", "1"),
                new DigitAsLetter("two", "2"),
                new DigitAsLetter("three", "3"),
                new DigitAsLetter("four", "4"),
                new DigitAsLetter("five", "5"),
                new DigitAsLetter("six", "6"),
                new DigitAsLetter("seven", "7"),
                new DigitAsLetter("eight", "8"),
                new DigitAsLetter("nine", "9"),
            };

            var letters = new List<string>()
            {
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine",
            };


            for (var i = 0; i < Input.Length; i++)
            {
                var item = base.Input[i];

                digitsAsLetter.ForEach(x => x.Reset());

                letters.ForEach(y =>
                {
                    var letter = digitsAsLetter.FirstOrDefault(x => x.Letter == y);
                    if (letter != null) {
                        letter.FirstIndexOf = item.IndexOf(y);
                        letter.LastIndexOf = item.LastIndexOf(y);
                    }
                });

                digitsAsLetter.ForEach(x => x.Validate());

                var firstLetter = digitsAsLetter.Where(x => x.FirstFound).OrderBy(x => x.FirstIndexOf).FirstOrDefault(x => x.FirstFound);
                var lastLetter = digitsAsLetter.Where(x => x.LastFound).OrderByDescending(x => x.LastIndexOf).FirstOrDefault(x => x.LastFound);

                var temp = item.ToString();

                var firstDigi = item.IndexOf(item.First(x => char.IsDigit(x)));
                var lastDigi = item.LastIndexOf(item.Last(x => char.IsDigit(x)));

                var first = firstLetter == null || firstDigi < firstLetter.FirstIndexOf ? item.First(x => char.IsDigit(x)).ToString() : firstLetter.Digit;
                var last = lastLetter == null || lastDigi > lastLetter.LastIndexOf ? item.Last(x => char.IsDigit(x)).ToString() : lastLetter.Digit;

                var sum = int.Parse(first + last);

                numbers.Add(sum);
            }

            Answer = numbers.Sum().ToString();

            return this;
        }
    }

    internal class DigitAsLetter
    {
        public bool FirstFound = false;
        public bool LastFound = false;
        public int FirstIndexOf = 0;
        public int LastIndexOf = 0;
        public string Digit = "0";
        public string Letter = "";

        public DigitAsLetter(string name, string digit)
        {
            Digit = digit;
            Letter = name;
        }

        public void Reset()
        {
            FirstFound = false;
            LastFound = false;
            FirstIndexOf = int.MaxValue;
            LastIndexOf = int.MinValue;
        }

        public void Validate()
        {
            FirstFound = false;
            LastFound = false;

            if (FirstIndexOf >= 0) 
                FirstFound = true;
            else FirstIndexOf = int.MaxValue;

            if (LastIndexOf >= 0) 
                LastFound = true;
            else LastIndexOf = int.MinValue;
        }
    }
}
