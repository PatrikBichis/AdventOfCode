using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
    public class Day7_1 : PuzzelBase, IPuzzel
    {
        private int possibleBags = 0;
        private bool foundBag = false;

        public Day7_1(InputType input) : base(input, 7, 1)
        {

        }

        public IPuzzel Run()
        {
            var bags = new List<Bag>();

            // Create bags
            foreach(var line in Input)
            {
                var parts = line.Split("bags contain");

                bags.Add(new Bag { Name = parts[0].TrimEnd() });
            }

            // Add containing bags
            foreach (var line in Input)
            {
                var parts = line.Split("bags contain");
                if (!parts[1].Contains("no other bags."))
                {
                    var containig = parts[1].Split(',');

                    foreach (var c in containig)
                    {

                        var name = c.TrimStart().Substring(1).Replace("bags", "").Replace("bag", "").Replace(".", "").Trim();
                        var countStr = c.TrimStart().Substring(0, 1);
                        var count = int.Parse(countStr);

                        var bag = bags.FirstOrDefault(x => x.Name == parts[0].TrimEnd());

                        if (bag != null)
                        {
                            bag.Contains.Add(new Tuple<string, int>(name, count));
                        }
                    }
                }
            }

            CountBags(bags, false);

            Answer = possibleBags.ToString();

            return this;
        }

        private void CountBags(List<Bag> bags, bool showPrint)
        {
            bags.OrderBy(x => x.Name).ToList().ForEach((b) =>
            {
                foundBag = false;
                PrintBag(bags, b, 1, showPrint);
                if(b.Name != "shiny gold" && foundBag)
                {
                    possibleBags++;
                }
            });
        }

        private void PrintBag(List<Bag> bags, Bag b, int level, bool showPrint)
        {
            if (showPrint)
            {
                for (int i = 0; i < level; i++) { Console.Write("-"); }
                Console.WriteLine(b.Name);
            }

            if (b.Name == "shiny gold" && level != 1)
                foundBag = true;

            b.Contains.ForEach(x => {
                var b = bags.First(y => y.Name == x.Item1);
                PrintBag(bags, b, level + 1, showPrint);
            });
        }
    }

    public class Bag
    {
        public Bag()
        {
            Contains = new List<Tuple<string, int>>();
        }

        public string Name { get; set; }

        public int NrOfBags { get { return Contains.Sum(x => x.Item2); } }

        public List<Tuple<string, int>> Contains { get; set; }
    }
}
