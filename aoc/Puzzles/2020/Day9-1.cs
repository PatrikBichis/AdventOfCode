using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
    public class Day9_1 : PuzzelBase, IPuzzel
    {

        public Day9_1(InputType input) : base(input, 9, 1)
        {
            
        }

        public IPuzzel Run()
        {
            Answer = FindWeakness(25, Input).ToString();

            return this;
        }


        public int FindWeakness(int preamble, string[] input)
        {
            for (var x = 0; x < input.Length; x++)
            {
                var preambleNum = input.Skip(x).Take(preamble).ToList();
                var n = input.Skip(x + preamble).Take(1).First();
                var found = false;
                for (var i = 0; i < preambleNum.Count; i++)
                {
                    for (var j = 0; j < preambleNum.Count; j++)
                    {
                        if (preambleNum[i] != preambleNum[j])
                        {
                            if (double.Parse(n) == double.Parse(preambleNum[i]) + double.Parse(preambleNum[j]))
                                found = true;
                        }
                    }
                }

                if (!found)
                    return int.Parse(n);
            }

            return -1;
        }
    }
}
