using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    public class Day5_2 : PuzzelBase, IPuzzel
    {
        public Day5_2(InputType input) : base(input, 5, 2)
        {
            
        }
        public IPuzzel Run()
        {
            var seatIds = new List<int>();

            Console.WriteLine(DecodingSeatId("FBFBBFFRLR ").ToString());
            Console.WriteLine(DecodingSeatId("BFFFBBFRRR ").ToString());
            Console.WriteLine(DecodingSeatId("FFFBBBFRRR ").ToString());
            Console.WriteLine(DecodingSeatId("BBFFBBFRLL ").ToString());

            foreach (var line in Input)
            {
                seatIds.Add(DecodingSeatId(line));
            }

            seatIds.Sort();

            var lastSeat = 0;
            foreach (int l in seatIds)
            {
                Console.WriteLine(l);

                if(lastSeat != 0)
                {
                    if(l - lastSeat > 1)
                    {
                        Console.WriteLine((l - 1).ToString() + " <-- Missing seat");
                        Answer = (l - 1).ToString();
                        break;
                    }
                }

                lastSeat = l;
            }


            return this;
        }

        private int DecodingSeatId(string boardingPass)
        {
            var seatId = -1;
            var chars = boardingPass.Trim().ToCharArray();
            var range = 64;
            var row = -1;
            var col = -1;
            var rowUp = 127;
            var rowLo = 0;
            var colUp = 7;
            var colLo = 0;

            for (int i = 0; i < 7; i++)
            {
                if (i < 6)
                {
                    if (chars[i] == 'F')
                    {
                        rowUp = rowUp - range;
                    }
                    else if (chars[i] == 'B')
                    {
                        rowLo = rowLo + range;
                    }
                }
                else
                {
                    if (chars[i] == 'F')
                        row = rowLo;
                    else if (chars[i] == 'B')
                        row = rowUp;
                }
                range = range / 2;
            }

            //Console.WriteLine("Row: " + row.ToString());

            range = 4;

            for (int i = 7; i < 10; i++)
            {
                if (i < 9)
                {
                    if (chars[i] == 'L')
                    {
                        colUp = colUp - range;
                    }
                    else if (chars[i] == 'R')
                    {
                        colLo = colLo + range;
                    }
                }
                else
                {
                    if (chars[i] == 'L')
                        col = colLo;
                    else if (chars[i] == 'R')
                        col = colUp;
                }
                range = range / 2;
            }

            //Console.WriteLine("Col: " + col.ToString());

            seatId = row * 8 + col;

            return seatId;
        }
    }
}
