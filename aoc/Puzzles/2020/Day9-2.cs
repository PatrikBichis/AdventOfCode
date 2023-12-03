using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
    public class Day9_2 : PuzzelBase, IPuzzel
    {

        public Day9_2(InputType input) : base(input, 9, 2)
        {

        }

        public IPuzzel Run()
        {
            var weeknessTest = 127; 
            var weekness = 1504371145;
            var found = false;
            var index = 0;
            var count = 1;

            while (!found)
            {
                var range = new List<double>();

                for(int i = index; i<Input.Length; i++)
                {
                    range.Add(double.Parse(Input[i]));

                    if(range.Sum() == (Type == InputType.Input ? weekness : weeknessTest))
                    {
                        var a = range.Min();
                        var b = range.Max();
                        Answer = (a + b).ToString();
                        found = true;
                        break;
                    }
                }
                index++;
            }
            

            return this;
        }

    }
}
