using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
    public class Day1_1 : PuzzelBase, IPuzzel
    {
        public Day1_1(InputType test) : base(test, 1, 1)
        {

        }

        public IPuzzel Run()
        {
            for (var i = 0; i < Input.Length; i++)
            {
                for (var j = 0; j < Input.Length; j++)
                {
                    var a = int.Parse(Input[i]);
                    var b = int.Parse(Input[j]);
                    
                    if ((a + b) == 2020)
                    {
                        Answer = (a * b).ToString();
                        break;
                    }
                }
            }
            return this;
        }
    }
}
