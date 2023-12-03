using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
   public class Day15_1 : PuzzelBase, IPuzzel
   {

       public Day15_1(InputType input) : base(input, 15, 1)
       {
            
       }

        private void NextTurn(ref List<Double> spoken)
        {
            
        }

        public IPuzzel Run()
        {
            var times = 2020;
            var current = (double)0;

            foreach (var line in Input)
            {
                var parts = line.Trim().Split(',');
                var spoken = new Dictionary<double, int>();
                var count = 1;
                current = (double)0;

                foreach (var p in parts)
                {
                    spoken.Add(double.Parse(p), count);
                    current = double.Parse(p);
                    count++;
                }

                while (count < times + 1)
                {
                    if (spoken.ContainsKey(current) && spoken[current] != count - 1)
                    {
                        var a = count - 1;
                        var b = spoken[current];
                        var sum = a - b;

                        spoken[current] = count - 1;
                        current = sum;
                    }
                    else
                    {
                        if (!spoken.ContainsKey(current))
                        {
                            spoken.Add(current, count - 1);
                        }
                        current = 0;
                    }

                    count++;
                }

                Console.WriteLine("Number of time spoken: " + current.ToString());
            }

            Answer = current.ToString();

            return this;
       }
   }
} 