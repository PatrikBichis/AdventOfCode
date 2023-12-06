using aoc.Helpers;
using aoc2020;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc23.Puzzles._2023
{
    internal class Day6_1 : PuzzelBase, IPuzzel
    {
        public Day6_1(InputType test) : base(test, 6, year: 2023)
        {

        }

        public IPuzzel Run()
        {

            try
            {
                var races = new List<Race>();
                var times = new List<double>();
                var distance = new List<double>();

                for (var i = 0; i < Input.Length; i++)
                {
                    var input = Input[i];

                    if (input.Contains("Time"))
                        times = input.After(':').DoubleValuesSeparatedBy(' ');
                    else if (input.Contains("Distance"))
                        distance = input.After(':').DoubleValuesSeparatedBy(' ');
                }

                Parallel.For(0, times.Count, i =>
                {
                    races.Add(new Race(i + 1, times[i], distance[i]));
                });

                double marginOfError = 1;
                
                for(var i = 0; i<races.Count; i++)
                {
                    if(races[i].PossibleCount > 0)
                        marginOfError = (double)races[i].PossibleCount * (double)marginOfError;
                }

                Answer = marginOfError.ToString();
            }
            catch (Exception ex)
            {
                Answer = "Error: " + ex.Message;
                return this;
            }

            return this;
        }

        public class Race
        {
            public double RaceId = 0;

            public double Time = 0;

            public double Record = 0;

            public double PossibleCount = 0;

            public Race(double id, double time, double record)
            {
                RaceId = id;
                Time = time;
                Record = record;

                ValidatePossibleRecords();
            }

            public void ValidatePossibleRecords()
            {
                for (var i = 0; i < Time; i++)
                {
                    var distance = i * (Time-i);

                    if (distance > Record)
                    {
                        PossibleCount++;
                    }
                }
            }
        }
    }
}