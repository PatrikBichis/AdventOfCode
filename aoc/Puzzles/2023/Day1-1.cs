using aoc2020;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc23.Puzzles._2023
{
    public class Day1_1 : PuzzelBase, IPuzzel
    {
        public Day1_1(InputType test) : base(test, 1, year: 2023)
        {

        }

        public IPuzzel Run()
        {
            var numbers = new List<int>();

            for (var i = 0; i < Input.Length; i++)
            {
                var first = Input[i].First(x => char.IsDigit(x));
                var last = Input[i].Last(x => char.IsDigit(x));
                var sum = int.Parse(first.ToString() + last.ToString());

                numbers.Add(sum);
            }


            Answer = numbers.Sum().ToString();

            return this;
        }
    }
}
