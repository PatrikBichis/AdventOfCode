using aoc2020;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc23.Puzzles._2023
{
    internal class Day4_2 : PuzzelBase, IPuzzel
    {
        public Day4_2(InputType test) : base(test, 4, year: 2023)
        {

        }

        public IPuzzel Run()
        {
            var scratchcards = new List<Scratchcard>();
            var scratchcardInstances = 0;
            var totalAmountOfScratchcards = Input.Length;

            try
            {
                for (var i = 0; i < Input.Length; i++)
                {
                    var input = Input[i];

                    scratchcards.Add(new Scratchcard().ParsInput(input).CalculateMatches());
                }

                scratchcards.ForEach(x => x.CalculateNrOfInstances(scratchcards, totalAmountOfScratchcards));
             
                Answer = scratchcards.Sum(x=>x.NrOfInstances).ToString();
            }
            catch (Exception ex)
            {
                Answer = "Error: " + ex.Message;
                return this;
            }

            return this;
        }
    }

    public class Scratchcard
    {
        public string Card = "";
        public int Id = -1;
        public int Index { get { return Id - 1; } }
        public List<int> WinningNumbers = new List<int>();
        public List<int> Numbers = new List<int>();

        public int Points = 0;
        public int Matches = 0;
        public int NrOfInstances = 1;

        public bool HasPoints { get { return Points > 0; } }

        public Scratchcard ParsInput(string input)
        {
            var parts = input.Split(':');

            Card = parts[0];

            var numberStart = parts[0].LastIndexOf(" ");

            Id = int.Parse(parts[0].Substring(numberStart, parts[0].Length - numberStart));


            // Numbers
            var numberParts = parts[1].Split("|");

            foreach (var n in numberParts[0].Trim().Split(' '))
            {
                if (n != "")
                    WinningNumbers.Add(int.Parse(n.Trim()));
            }

            foreach (var n in numberParts[1].Trim().Split(' '))
            {
                if (n != "")
                    Numbers.Add(int.Parse(n.Trim()));
            }

            return this;
        }

        public Scratchcard CalculateNrOfInstances(List<Scratchcard> cards, int total)
        {
            var start = Index + 1;
            var limitedMax = (start + Matches);

            if (limitedMax > total) 
                limitedMax = total;

            for (int i = start; i < limitedMax; i++)
            {
                cards[i].CalculateNrOfInstances(cards, total);
                NrOfInstances++;
            }

            return this;
        }

        public Scratchcard CalculateMatches()
        {
            foreach (var w in WinningNumbers)
            {
                foreach (var n in Numbers)
                {
                    if (w == n)
                    {
                        Matches++;
                    }
                }
            }

            return this;
        }

        public Scratchcard CalculatePoints()
        {
            var first = true;

            foreach (var w in WinningNumbers)
            {
                foreach (var n in Numbers)
                {
                    if (w == n)
                    {
                        if (first)
                        {
                            Points = 1;
                            first = false;
                        }
                        else
                            Points = Points * 2;
                    }
                }
            }

            return this;
        }
    }
}