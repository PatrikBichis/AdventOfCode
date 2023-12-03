using aoc2020;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc23.Puzzles._2022
{
    public class Day1_1 : PuzzelBase, IPuzzel
    {
        public Day1_1(InputType test) : base(test, 1, year: 2022)
        {

        }

        public IPuzzel Run()
        {
            var numbers = new List<int>();
            var calories = 0;

            for (var i = 0; i < Input.Length; i++)
            {
                if (Input[i] == "")
                {
                    numbers.Add(calories);
                    calories = 0;
                }
                else
                    calories += int.Parse(Input[i]);
            }

            numbers.Add(calories);

            Answer = numbers.Max().ToString();

            return this;
        }
    }
}
