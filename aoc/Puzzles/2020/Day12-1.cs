using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
   public class Day12_1 : PuzzelBase, IPuzzel
   {

       public Day12_1(InputType input) : base(input, 12, 1)
       {
           
       }

       public IPuzzel Run()
       {
            var east = 0;
            var north = 0;
            var south = 0;
            var west = 0;
            var direction = 0; //0:east, 1:south, 2:west, 3:north

            //           /\ 
            //          north 3
            // <- west 2        east 0 ->
            //          south 1
            //           \/

            foreach (var line in Input)
            {
                var cmd = line.Substring(0, 1);
                var value = int.Parse(line.Substring(1, line.Length-1));

                
                if(cmd == "R" || cmd == "L")
                {
                    direction = Turn(cmd, value, direction);
                }
                else if (direction == 0 && cmd == "F")
                {
                    east += value;
                }
                else if(direction == 1 && cmd == "F")
                {
                    south += value;
                }
                else if (direction == 2 && cmd == "F")
                {
                    west += value;
                }
                else if (direction == 3 && cmd == "F")
                {
                    north += value;
                }
                else if (cmd == "E")
                {
                    east += value;
                }
                else if (cmd == "S")
                {
                    south += value;
                }
                else if (cmd == "W")
                {
                    west += value;
                }
                else if (cmd == "N")
                {
                    north += value;
                }
            }

            Answer = (Math.Abs(east - west) + Math.Abs(north - south)).ToString();

           return this;
       }

        //           /\ 
        //          north 3
        // <- west 2        east 0 ->
        //          south 1
        //           \/
        private int Turn(string cmd, int value, int direction)
        {
            if (cmd == "R" || cmd == "L")
            {
                if (cmd == "R" && value == 90)
                {
                    var d = direction + 1;
                    if (d > 3)
                    {
                        if (d == 4)
                            return 0;
                        if (d == 5)
                            return 1;
                        if (d == 6)
                            return 2;
                    }

                    return d;
                }
                if (cmd == "R" && value == 180)
                {
                    var d = direction + 2;
                    if (d > 3)
                    {
                        if (d == 4)
                            return 0;
                        if (d == 5)
                            return 1;
                        if (d == 6)
                            return 2;
                    }

                    return d;
                }
                if (cmd == "R" && value == 270)
                {
                    var d = direction + 3;
                    if (d > 3)
                    {
                        if (d == 4)
                            return 0;
                        if (d == 5)
                            return 1;
                        if (d == 6)
                            return 2;
                    }

                    return d;
                }
                if (cmd == "L" && value == 90)
                {
                    var d = direction - 1;
                    if(d<0)
                    {
                        if (d == -3)
                            return 1;
                        if (d == -2)
                            return 2;
                        if (d == -1)
                            return 3;
                    }
                    else
                        return d;
                }
                if (cmd == "L" && value == 180)
                {
                    var d = direction - 2;
                    if (d < 0)
                    {
                        if (d == -3)
                            return 1;
                        if (d == -2)
                            return 2;
                        if (d == -1)
                            return 3;
                    }
                    else
                        return d;
                }
                if (cmd == "L" && value == 270)
                {
                    var d = direction - 3;
                    if (d < 0)
                    {
                        if (d == -3)
                            return 1;
                        if (d == -2)
                            return 2;
                        if (d == -1)
                            return 3;
                    }
                    else
                        return d;
                }
            }

            return direction;
        }
   }
} 