using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
   public class Day11_1 : PuzzelBase, IPuzzel
   {

       public Day11_1(InputType input) : base(input, 11, 1)
       {

            var seats = GenerateSeats(Input);
            //seats.Print();
            var count = 0;
            do
            {
                seats.Reset();
                seats = seats.RunRules();
                count++;
                Console.WriteLine("Iteration: " + count.ToString() + ".");
                Console.WriteLine("Has stablized: " + seats.HasStabilized + ".");
                Console.WriteLine("Nr of occupied seats: " + seats.NrOfOccupiedSeats.ToString() + ".");
                //seats.Print();
            } while (!seats.HasStabilized);

            Answer = seats.NrOfOccupiedSeats.ToString();
       }

        private SeatCollection GenerateSeats(string[] input)
        {

            var seats = new SeatCollection();
            seats.X_Length = Input[0].Length;
            seats.Y_Length = Input.Length;

            seats.Seats = new Seat[Input[0].Length, Input.Length];

            for (int y = 0; y < Input.Length; y++)
            {
                for(int x = 0; x < Input[0].Length; x++)
                {
                    var seat = new Seat();
                    if (Input[y].ToArray()[x] == 'L')
                        seat.Type = SeatType.Empty;
                    else if (Input[y].ToArray()[x] == '#')
                        seat.Type = SeatType.Occupied;
                    else
                        seat.Type = SeatType.Floor;

                    seats.Seats[x, y] = seat;
                }
            }

            return seats;
        }

        public IPuzzel Run()
       {


           return this;
       }

   }

    class SeatCollection
    {
        public int X_Length { get; set; } = 0;

        public int Y_Length { get; set; } = 0;

        public void Reset()
        {
            for(int y = 0; y < Y_Length; y++)
            {
                for(int x = 0; x < X_Length; x++)
                {
                    Seats[x, y].Changed = false;
                }
            }
        }

        public void Print()
        {
            for (int y = 0; y < Y_Length; y++)
            {
                for (int x = 0; x < X_Length; x++)
                {
                    if (Seats[x, y].Type == SeatType.Empty)
                        Console.Write("L");
                    else if (Seats[x, y].Type == SeatType.Occupied)
                        Console.Write("#");
                    else if (Seats[x, y].Type == SeatType.Floor)
                        Console.Write(".");
                }
                Console.WriteLine("");
            }
        }

        public int NrOfOccupiedSeats
        {
            get
            {
                var occupiedSeats = 0;

                for (int y = 0; y < Y_Length; y++)
                {
                    for (int x = 0; x < X_Length; x++)
                    {
                        if (Seats[x, y].Type == SeatType.Occupied)
                            occupiedSeats++;
                    }
                }

                return occupiedSeats;
            }
        }

        public bool HasStabilized
        {
            get
            {
                var HasChanged = false;

                for (int y = 0; y < Y_Length; y++)
                {
                    for (int x = 0; x < X_Length; x++)
                    {
                        HasChanged = Seats[x, y].Changed;
                        if (HasChanged)
                            break;
                    }
                    if (HasChanged)
                        break;
                }

                return !HasChanged;
            }
        }

        public void UpdateItem(int x, int y, SeatType type)
        {
            if (Seats[x, y].Type != type)
            {
                Seats[x, y].Type = type;
                Seats[x, y].Changed = true;
            }
        }

        public SeatCollection RunRules()
        {
            var copy = new Seat[X_Length, Y_Length];

            for (int y = 0; y < Y_Length; y++)
            {
                for (int x = 0; x < X_Length; x++)
                {
                    var occupiedSeats = 0;

                    if (x > 0 && y > 0 && Seats[x - 1, y - 1].Type == SeatType.Occupied)
                        occupiedSeats++;

                    if (x > 0 && Seats[x - 1, y].Type == SeatType.Occupied) 
                        occupiedSeats++;

                    if (x > 0 && y + 1 < Y_Length && Seats[x - 1, y + 1].Type == SeatType.Occupied)
                        occupiedSeats++;


                    if (y > 0 && Seats[x, y - 1].Type == SeatType.Occupied)
                        occupiedSeats++;

                    //if (Seats[x, y].Type == SeatType.Occupied)
                    //    occupiedSeats++;

                    if (y + 1 < Y_Length && Seats[x, y + 1].Type == SeatType.Occupied)
                        occupiedSeats++;


                    if (x + 1 < X_Length && y > 0 && Seats[x +1, y - 1].Type == SeatType.Occupied)
                        occupiedSeats++;

                    if (x + 1 < X_Length && Seats[x + 1, y].Type == SeatType.Occupied)
                        occupiedSeats++;

                    if (x + 1 < X_Length && y + 1 < Y_Length && Seats[x + 1, y + 1].Type == SeatType.Occupied)
                        occupiedSeats++;

                    copy[x, y] = new Seat();

                    if (Seats[x, y].Type != SeatType.Floor)
                    {
                        if (occupiedSeats >= 4 && Seats[x, y].Type != SeatType.Empty)
                        {
                            copy[x, y].Type = SeatType.Empty;
                            copy[x, y].Changed = true;
                        }
                        else if (occupiedSeats == 0 && Seats[x, y].Type != SeatType.Occupied)
                        {
                            copy[x, y].Type = SeatType.Occupied;
                            copy[x, y].Changed = true;
                        }
                        else
                        {
                            copy[x, y].Type = Seats[x, y].Type;
                        }
                    }
                }
            }

            this.Seats = copy;

            return this;
        }

        public Seat[,] Seats { get; set; }
    }

    public class Seat
    {
        public SeatType Type { get; set; } = SeatType.Floor;

        public bool Changed = false;
    }

    public enum SeatType{ 
        Floor,
        Empty,
        Occupied
    }
} 