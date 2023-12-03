using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
   public class Day13_1 : PuzzelBase, IPuzzel
   {

       public Day13_1(InputType input) : base(input, 13, 1)
       {
           
       }

       public IPuzzel Run()
       {
            var arriveTime = double.Parse(Input[0]);
            var parts = Input[1].Split(",");
            var busses = new List<Bus>();

            foreach(var p in parts)
            {
                if(p != "x")
                {
                    busses.Add(new Bus() { Id = double.Parse(p) });
                }
            }

            foreach(var b in busses)
            {
                var count = 1;
                while(b.ErliestTime < arriveTime)
                {
                    b.ErliestTime = b.Id * count;
                    count++;
                }
            }

            var firstBus = busses.OrderBy(x => x.ErliestTime);

            Answer = (firstBus.First().Id * (firstBus.First().ErliestTime - arriveTime)).ToString();

           return this;
       }

   }

    class Bus
    {
        public double Id { get; set; }

        public double ErliestTime { get; set; }
    }
} 