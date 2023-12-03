using aoc2020;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc23.Puzzles._2023
{
    public class Day2_1 : PuzzelBase, IPuzzel
    {
        public Day2_1(InputType test) : base(test, 2, year: 2023)
        {

        }

        public IPuzzel Run()
        {
            try
            {
                var revealse = new List<Reveals>();


                for (var i = 0; i < Input.Length; i++)
                {
                    var row = Input[i];


                    var r = new Reveals();

                    var game = row.Split(":")[0].Trim();

                    r.GameId = game;

                    row = row.Replace(game + ":", "");

                    var sets = row.Split(';');

                    foreach (var s in sets)
                    {
                        var cubes = s.Trim().Split(',');

                        foreach (var c in cubes)
                        {
                            var info = c.Trim().Split(' ');

                            if (info[1].Trim() == "green")
                                r.Green += int.Parse(info[0].Trim());
                            if (info[1].Trim() == "red")
                                r.Red += int.Parse(info[0].Trim());
                            if (info[1].Trim() == "blue")
                                r.Blue += int.Parse(info[0].Trim());
                        }

                        r.Validate();
                        r.Reset();
                    }

                    revealse.Add(r);
                }

                //revealse.ForEach(x => x.Validate());

                var posibleGames = revealse.Where(x => x.Possible).ToList();

                Answer = posibleGames.Sum(x => x.Id).ToString();
            }
            catch(Exception ex)
            {
                Answer = "Error: " + ex.Message;
                return this;
            }

            return this;
        }

        private class Reveals{
            
            public int Red = 0;
            
            public int Green = 0;
            
            public int Blue = 0;

            public bool Possible = true;

            public string GameId = String.Empty;

            public int Id = 0;

            public void Validate() { 
                if(Red <= 12 && Green <= 13 && Blue <= 14 && Possible)
                    Possible = true;
                else
                    Possible = false;


                var parts = GameId.Split(' ');

                Id = int.Parse(parts[1].Trim());
            }

            public void Reset() { Red = 0; Green = 0; Blue = 0; }
        }
    }
}
