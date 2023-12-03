using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
    public class Day2_1 : PuzzelBase, IPuzzel
    {
        public Day2_1(InputType input) : base(input, 2, 1)
        {

        }

        public IPuzzel Run()
        {
            var validPasswords = 0;
            foreach(var line in Input)
            {
                var parts = line.Split(':');
                var letters = parts[1].Trim().ToCharArray();
                var cmdParts = parts[0].Split(' ');
                var letter = Convert.ToChar(cmdParts[1].Trim()[0]);
                var min_max = cmdParts[0].Split('-');

                var min = int.Parse(min_max[0]);
                var max = int.Parse(min_max[1]);

                var letterCount = 0;
                foreach(var l in letters)
                {
                    if (l == letter) letterCount++;
                }

                if (letterCount >= min && letterCount <= max)
                    validPasswords++;
            }

            Answer = validPasswords.ToString();

            return this;
        }

    }
}
