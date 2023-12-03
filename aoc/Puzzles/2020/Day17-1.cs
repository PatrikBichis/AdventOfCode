using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
   public class Day17_1 : PuzzelBase, IPuzzel
   {

       public Day17_1(InputType input) : base(input, 17, 1)
       {
           
       }

       public IPuzzel Run()
       {
            var grid = new List<Cube>();

            // Extract init grid from input
            ExtractGridFromInput(Input, ref grid);

            for(int i = 0; i<6; i++)
            {
                RunCycle(ref grid);
            }

            Answer = grid.Count(x => x.IsActive == true).ToString();

           return this;
       }

        private void RunCycle(ref List<Cube> grid)
        {
            var temp = grid.ToList();
            foreach(var c in grid)
            {

            }
        }

        private int CountActiveNeighbor(ref List<Cube> temp, List<Cube> grid, Cube c)
        {
            var count = 0;
            var x = -1;
            var y = 0;
            var z = 0;

            // X ------>
            // Y
            // |
            // |
            // \/

            CheckNeighbor(ref temp, grid, c, ref count, -1, -1, 0);
            CheckNeighbor(ref temp, grid, c, ref count, 0, -1, 0);
            CheckNeighbor(ref temp, grid, c, ref count, -1, 0, 0);

            CheckNeighbor(ref temp, grid, c, ref count, -1, -1, 0);
            CheckNeighbor(ref temp, grid, c, ref count, 0, -1, -1);
            CheckNeighbor(ref temp, grid, c, ref count, -1, -1, -1);

            CheckNeighbor(ref temp, grid, c, ref count, 1, 0, 0);
            CheckNeighbor(ref temp, grid, c, ref count, 0, 1, 0);
            CheckNeighbor(ref temp, grid, c, ref count, 0, 0, 1);

            CheckNeighbor(ref temp, grid, c, ref count, 1, 1, 0);
            CheckNeighbor(ref temp, grid, c, ref count, 0, 1, 1);
            CheckNeighbor(ref temp, grid, c, ref count, 1, 1, 1);

            return count;
        }

        private void CheckNeighbor(ref List<Cube> temp, List<Cube> grid, Cube c, ref int count, int x, int y, int z)
        {
            if (CheckIfNeighborExists(grid, c.X + x, c.Y + y, c.Z + z))
            {
                var n = grid.First(i => i.X == c.X + x && i.Y == c.Y + y && i.Z == c.Z + z);

                if (n.IsActive) count++;
            }
            else
            {
                temp.Add(new Cube { X = c.X + x, Y = c.Y + y, Z = c.Z + z });
            }
        }

        private bool CheckIfNeighborExists(List<Cube> grid, int x, int y, int z)
        {
            return grid.Exists(i => i.X ==  x && i.Y == y && i.Z == z);
        }

        private void ExtractGridFromInput(string[] input, ref List<Cube> grid)
        {
            var x = 0;
            var y = 0;
            foreach (var line in input)
            {
                var cubes = line.ToCharArray();

                foreach (var c in cubes)
                {
                    x = 0;
                    var newCube = new Cube { X = x, Y = y, Z = 0 };
                    newCube.IsActive = c == '.' ? false : true;
                    grid.Add(newCube);
                    x++;
                }

                y++;
            }
        }
       
   }

    class Cube
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public bool IsActive { get; set; } = false;
    }
} 