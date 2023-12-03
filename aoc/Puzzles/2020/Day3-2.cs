using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
    public class Day3_2 : PuzzelBase, IPuzzel
    {
        public Day3_2(InputType input) : base(input, 3, 2)
        {

        }

        public IPuzzel Run()
        {
            double a = CheckNrOfTrees(1, 1);
            Console.WriteLine(a);

            double b = CheckNrOfTrees(3, 1);
            Console.WriteLine(b);

            double c = CheckNrOfTrees(5, 1);
            Console.WriteLine(c);

            double d = CheckNrOfTrees(7, 1);
            Console.WriteLine(d);

            double e = CheckNrOfTrees(1, 2);
            Console.WriteLine(e);

            Answer = (a*b*c*d*e).ToString();
            return this;
        }


        private int CheckNrOfTrees(int slopeX, int slopeY)
        {
            var numberOfTrees = 0;

            var maxY = Input.Length;
            var maxX = Input.Length * slopeX;
            var _x = 0;
            var _y = 0;

            for(var i = 0; i<maxY; i += slopeY)
            {
                var extended = "";
                var extendTo = Input.Length / Input[i].Trim().Length * slopeX;
                for (var j= 0; j < extendTo + slopeX; j++)
                    extended += Input[i].Trim();

                var points = extended.ToCharArray();

                if (points[_x] == '#')
                    numberOfTrees++;
                _x += slopeX;
                _y++;
            }

            return numberOfTrees;
        }
    }
}