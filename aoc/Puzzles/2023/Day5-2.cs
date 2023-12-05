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
    internal class Day5_2 : PuzzelBase, IPuzzel
    {
        public Day5_2(InputType test) : base(test, 5, year: 2023)
        {

        }

        public IPuzzel Run()
        {

            var seedsValues = new List<double>();
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
                var currentCat = "";

                for (var i = 0; i < Input.Length; i++)
                {
                    var input = Input[i];

                    //Console.WriteLine("Line " + (i + 1) + ": " + Input[i]);

                    if (input != "")
                    {
                        if (input.Contains("seeds"))
                        {
                            currentCat = "seeds";
                        }

                        if (currentCat == "seeds")
                        {
                            seedsValues = input.After(':').DoubleValuesSeparatedBy(' ');
                        }
                        else if (currentCat == "seed-to-soil map")
                        {
                            seedToSoilMap = ExtractValuesToMap(input, seedToSoilMap);
                        }
                        else if (currentCat == "soil-to-fertilizer map")
                        {
                            soilToFertilizerMap = ExtractValuesToMap(input, soilToFertilizerMap);
                        }
                        else if (currentCat == "fertilizer-to-water map")
                        {
                            fertilizerToWaterMap = ExtractValuesToMap(input, fertilizerToWaterMap);
                        }
                        else if (currentCat == "water-to-light map")
                        {
                            waterToLightMap = ExtractValuesToMap(input, waterToLightMap);
                        }
                        else if (currentCat == "light-to-temperature map")
                        {
                            lightToTemperatureMap = ExtractValuesToMap(input, lightToTemperatureMap);
                        }
                        else if (currentCat == "temperature-to-humidity map")
                        {
                            temperatureToHumidityMap = ExtractValuesToMap(input, temperatureToHumidityMap);
                        }
                        else if (currentCat == "humidity-to-location map")
                        {
                            humidityToLocationMap = ExtractValuesToMap(input, humidityToLocationMap);
                        }

                        if (input.Contains("seed-to-soil map"))
                        {
                            currentCat = "seed-to-soil map";
                        }
                        if (input.Contains("soil-to-fertilizer map"))
                        {
                            currentCat = "soil-to-fertilizer map";
                        }
                        if (input.Contains("fertilizer-to-water map"))
                        {
                            currentCat = "fertilizer-to-water map";
                        }
                        if (input.Contains("water-to-light map"))
                        {
                            currentCat = "water-to-light map";
                        }
                        if (input.Contains("light-to-temperature map"))
                        {
                            currentCat = "light-to-temperature map";
                        }
                        if (input.Contains("temperature-to-humidity map"))
                        {
                            currentCat = "temperature-to-humidity map";
                        }
                        if (input.Contains("humidity-to-location map"))
                        {
                            currentCat = "humidity-to-location map";
                        }
                    }
                    else currentCat = "";
                }

                Console.WriteLine("Generating pars");

                var pars = new List<Tuple<double, double>>();
                for (int j = 0; j < seedsValues.Count; j += 2)
                {
                    pars.Add(new Tuple<double, double>(seedsValues[j], seedsValues[j + 1]));
                }

                Console.WriteLine("Generating seeds");

                var lowestLocation = double.MaxValue;

                Parallel.ForEach(pars, p =>
                {
                    Parallel.For((long)p.Item1, (long)(p.Item1 + p.Item2), d =>
                    {

                        var location = new Seed(d).ExtractDataFromMaps(
                                        seedToSoilMap,
                                        soilToFertilizerMap,
                                        fertilizerToWaterMap,
                                        waterToLightMap,
                                        lightToTemperatureMap,
                                        temperatureToHumidityMap,
                                        humidityToLocationMap
                                    );

                        if (location < lowestLocation)
                            lowestLocation = location;

                        Console.WriteLine($"Seed {p.Item1} : {lowestLocation} : {(p.Item1 + p.Item2)}/{d}");
                    });
                });

                Console.WriteLine("Get min location" + Environment.NewLine);

                Answer = lowestLocation.ToString();
            }
            catch (Exception ex)
            {
                Answer = "Error: " + ex.Message;
                return this;
            }

            return this;
        }

        public List<MapItem> ExtractValuesToMap(string valueString, List<MapItem> map)
        {
            var mapValues = valueString.DoubleValuesSeparatedBy(' ');

            var destinationRangeStart = mapValues[0];
            var sourceRangeStart = mapValues[1];
            var RangeLength = mapValues[2];

            map.Add(new MapItem { source = sourceRangeStart, target = destinationRangeStart, range = RangeLength });

            return map;
        }

        public class MapItem
        {

            public double source = 0;

            public double target = 0;

            public double range = 0;
        }

        public class Seed
        {
            public double SeedValue = 0;

            public double Soil = 0;

            public double Fertilizer = 0;

            public double Water = 0;

            public double Light = 0;

            public double Temperature = 0;

            public double Humidity = 0;

            public double Location = 0;

            public Seed(double value)
            {
                SeedValue = value;
            }

            private double ExtractValueFromMap(double sourceValue, List<MapItem> map)
            {
                var foundMap = map.FirstOrDefault(x => sourceValue >= x.source && sourceValue <= (x.source + x.range));
                if (foundMap != null)
                    return sourceValue + (foundMap.target - foundMap.source);
                else
                    return sourceValue;
            }

            public double ExtractDataFromMaps(
                List<MapItem> seedToSoilMap,
                List<MapItem> soilToFertilizerMap,
                List<MapItem> fertilizerToWaterMap,
                List<MapItem> waterToLightMap,
                List<MapItem> lightToTemperatureMap,
                List<MapItem> temperatureToHumidityMap,
                List<MapItem> humidityToLocationMap
            )
            {
                Soil = ExtractValueFromMap(SeedValue, seedToSoilMap);
                Fertilizer = ExtractValueFromMap(Soil, soilToFertilizerMap);
                Water = ExtractValueFromMap(Fertilizer, fertilizerToWaterMap);
                Light = ExtractValueFromMap(Water, waterToLightMap);
                Temperature = ExtractValueFromMap(Light, lightToTemperatureMap);
                Humidity = ExtractValueFromMap(Temperature, temperatureToHumidityMap);
                Location = ExtractValueFromMap(Humidity, humidityToLocationMap);

                return Location;
            }
        }
    }
}