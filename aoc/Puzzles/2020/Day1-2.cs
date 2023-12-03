using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
    public class Day1_2 : PuzzelBase, IPuzzel
    {
        public Day1_2(InputType input) : base(input, 1, 2)
        {

        }

        public IPuzzel Run()
        {
            for (var i = 0; i < Input.Length; i++)
            {
                for (var j = 0; j < Input.Length; j++)
                {
                    for (var k = 0; k < Input.Length; k++)
                    {
                        var a = int.Parse(Input[i]);
                        var b = int.Parse(Input[j]);
                        var c = int.Parse(Input[k]);

                        if (a + b + c == 2020)
                        {
                            Answer = (a * b * c).ToString();
                            break;
                        }
                    }
                }
            }

            return this;
        }
    }
}
