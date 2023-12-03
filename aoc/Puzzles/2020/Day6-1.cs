using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
    public class Day6_1 : PuzzelBase, IPuzzel
    {
        public Day6_1(InputType input) : base(input, 6, 1)
        {

        }

        public IPuzzel Run()
        {
            var anwsers = new List<string>();
            var anwser = new List<char>();
            var count = 0;
            var lastLine = "";
            foreach (var line in Input)
            {
                if (line == "")
                {
                    AddAnwsers(ref anwsers, anwser);
                    anwser = new List<char>();
                }
                else
                {
                    var letters = line.ToCharArray();
                    foreach (var l in letters)
                    {
                        if (!anwser.Contains(l)) anwser.Add(l);
                    }
                }
                lastLine = line;
            }

            if (lastLine != "")
            {
                AddAnwsers(ref anwsers, anwser);
            }

            anwsers.ForEach(x =>
            {
                count += x.Length;
            });

            Answer = count.ToString();

            return this;
        }

        private void AddAnwsers(ref List<string> anwsers, List<char> anwser)
        {
            var temp = "";
            anwser.ForEach(x => { temp += x.ToString(); });
            anwsers.Add(temp);
        }
    }
}
