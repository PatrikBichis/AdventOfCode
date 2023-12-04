using aoc2020;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc23.Puzzles._2023
{
    internal class Day5_1 : PuzzelBase, IPuzzel
    {
        public Day5_1(InputType test) : base(test, 5, year: 2023)
        {

        }

        public IPuzzel Run()
        {
            
            try
            {
                for (var i = 0; i < Input.Length; i++)
                {
                    
                }


                Answer = "N/A";
            }
            catch (Exception ex)
            {
                Answer = "Error: " + ex.Message;
                return this;
            }

            return this;
        }
    }
}