using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace aoc2020
{
    public class Day3_1 : PuzzelBase, IPuzzel
    {
        public Day3_1(InputType input) : base(input, 3, 1)
        {

        }

        public IPuzzel Run()
        {
            var numberOfTrees = 0;
            
            var maxY = Input.Length;
            var maxX = Input.Length * 3;
            var _x = 0;
            var _y = 0;

            foreach(var l in Input)
            {
                var extended = "";
                var extendTo = Input.Length / l.Length * 3;
                for (var i = 0; i < extendTo+3; i++)
                    extended += l.Trim();

                var points = extended.ToCharArray();

                if (points[_x] == '#')
                    numberOfTrees++;
                _x += 3;
                _y++;
            }

            Answer = numberOfTrees.ToString();

            return this;
        }

    }
}
