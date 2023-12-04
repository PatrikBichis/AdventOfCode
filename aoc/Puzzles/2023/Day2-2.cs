using aoc2020;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc23.Puzzles._2023
{
    public class Day2_2 : PuzzelBase, IPuzzel
    {
        public Day2_2(InputType test) : base(test, 2, year: 2023)
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

                    var green = 0; var red = 0; var blue = 0;

                    foreach (var s in sets)
                    {
                        var cubes = s.Trim().Split(',');

                        foreach (var c in cubes)
                        {
                            var info = c.Trim().Split(' ');
                            var value = int.Parse(info[0].Trim());
                            
                            if (info[1].Trim() == "green")
                                if(green < int.Parse(info[0].Trim()))
                                    green = int.Parse(info[0].Trim());
                            if (info[1].Trim() == "red")
                                if (red < int.Parse(info[0].Trim()))
                                    red = int.Parse(info[0].Trim());
                            if (info[1].Trim() == "blue")
                                if (blue < int.Parse(info[0].Trim()))
                                    blue = int.Parse(info[0].Trim());
                        }
                    }

                    r.Validate(red, green, blue);

                    revealse.Add(r);
                }

                var posibleGames = revealse.Where(x => x.Possible).ToList();

                Answer = posibleGames.Sum(x => x.PowerValue).ToString();
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

            public int PowerValue = int.MaxValue;

            public int Id = 0;

            public bool Validate(int red, int green, int blue) {

                PowerValue = red * green * blue;

                Red = red;
                Blue = blue;
                Green = green;

                var parts = GameId.Split(' ');

                Id = int.Parse(parts[1].Trim());

                return Possible;
            }

            public void Reset() { Red = 0; Green = 0; Blue = 0; }
        }
    }
}
