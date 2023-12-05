using aoc.Helpers;
using aoc2020;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
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

            var seedsValues = new List<int>();
            var seedToSoilMap = new List<MapItem>();
            var soilToFertilizerMap = new List<MapItem>();
            var fertilizerToWaterMap = new List<MapItem>();
            var waterToLightMap = new List<MapItem>();
            var lightToTemperatureMap = new List<MapItem>();
            var temperatureToHumidityMap = new List<MapItem>();
            var humidityToLocationMap = new List<MapItem>();
            var seeds = new List<Seed>();
            
            try
            {
                var lastCat = "";

                for (var i = 0; i < Input.Length; i++)
                {
                    var input = Input[i];

                    if (input.Before(':').Trim() == "seeds" && lastCat == "") {
                        seedsValues = input.After(':').ValuesSeparatedBy(' ');
                    }
                    else if (input.Before(':').Trim() == "soil-to-fertilizer map" || lastCat == "soil-to-fertilizer map")
                    {
                        lastCat = "soil-to-fertilizer map";
                        var mapValues = input.ValuesSeparatedBy(' ');

                        var destinationRangeStart = mapValues[0];
                        var sourceRangeStart = mapValues[1];
                        var RangeLength = mapValues[2];

                        for(int j = 0; j < RangeLength; j++)
                        {
                            seedToSoilMap.Add(new MapItem { source = destinationRangeStart + j, target = sourceRangeStart + j });
                        }
                    }
                }

                seedsValues.ForEach(value => seeds.Add(new Seed(value)));

                seeds.ForEach(seed => seed.ExtractDataFromMaps(
                    seedToSoilMap)
                );

                Answer = "N/A";
            }
            catch (Exception ex)
            {
                Answer = "Error: " + ex.Message;
                return this;
            }

            return this;
        }

        public class MapItem
        {
            public int source = 0;

            public int target = 0;
        }

        public class Seed
        {
            public int SeedValue = 0;

            public int Soil = 0;

            public int Fertilizer = 0;

            public int Water = 0;

            public int Light = 0;

            public int Temperature = 0;

            public int Humidity = 0;

            public int Location = 0;

            public Seed(int value)
            {
                SeedValue = value;
            }


            public void ExtractDataFromMaps(
                List<MapItem> seedToSoilMap
            )
            {
                var soil = seedToSoilMap.FirstOrDefault(x => x.source == SeedValue);
                if (soil == null) Soil = soil.target;
                else Soil = SeedValue;
            }
        }
    }
}