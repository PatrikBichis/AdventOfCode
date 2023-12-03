using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
    public class Day6_2 : PuzzelBase, IPuzzel
    {
        public Day6_2(InputType input) : base(input, 6, 2)
        {

        }

        public IPuzzel Run()
        {
            var anwsers = new Dictionary<char, int>();
            var people = 0;
            var count = 0;
            var lastLine = "";
            foreach (var line in Input)
            {
                
                if (line == "")
                {
                    CountAnwsers(ref count, people, anwsers);
                    anwsers = new Dictionary<char, int>();
                    people = 0;
                }
                else
                {
                    var letters = line.ToCharArray();
                    foreach (var l in letters)
                    {
                        if (!anwsers.ContainsKey(l))
                        {
                            anwsers.Add(l, 1);
                        }
                        else anwsers[l] += 1;
                    }
                    people++;
                }
                lastLine = line;
            }

            if (lastLine != "")
            {
                CountAnwsers(ref count, people, anwsers);
            }

            Answer = count.ToString();

            return this;
        }

        private void CountAnwsers(ref int count, int people, Dictionary<char, int> anwsers)
        {
            for (int i = 0; i < anwsers.Count; i++)
            {
                if (anwsers.ElementAt(i).Value == people) count++;
            }
        }
    }
}
