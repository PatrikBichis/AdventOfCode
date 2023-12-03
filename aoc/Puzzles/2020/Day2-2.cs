using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
    public class Day2_2 : PuzzelBase, IPuzzel
    {
        public Day2_2(InputType input) : base(input, 2, 2)
        {

        }

        public IPuzzel Run()
        {
            var validPasswords = 0;
            foreach (var line in Input)
            {
                var parts = line.Split(':');
                var letters = parts[1].Trim().ToCharArray();
                var cmdParts = parts[0].Split(' ');
                var letter = Convert.ToChar(cmdParts[1].Trim()[0]);
                var min_max = cmdParts[0].Split('-');

                var min = int.Parse(min_max[0]);
                var max = int.Parse(min_max[1]);

                var letterCount = 0;

                if (letters[min - 1] == letter)
                    letterCount++;

                if(letters[max - 1] == letter)
                    letterCount++;

                if (letterCount == 1)
                    validPasswords++;
            }

            Answer = validPasswords.ToString();

            return this;
        }

    }
}
