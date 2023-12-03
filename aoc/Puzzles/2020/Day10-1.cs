//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace aoc2020
//{
//    public class Day10_1 : PuzzelBase, IPuzzel
//    {

//        public Day10_1(InputType input) : base(input, 10, 1)
//        {

//        }

//        public IPuzzel Run()
//        {
//            var last = 0;
//            var jolts1 = 0;
//            var jolts3 = 0;
//            var charges = new List<int>();
//            var ranges = new List<List<int>>();

//            ranges.Add(new List<int> { 0 });

//            foreach (var i in Input)
//                charges.Add(int.Parse(i));

//            charges.Sort();

//            for(var i = 0; i< charges.Count; i++) {
//            {
//                var a = charges[i];
//                var b = (i + 1) < charges.Count ?  charges[i + 1] : -1;
//                var c = (i + 3) < charges.Count ? charges[i + 3] : -1;

//                //if (a != -1)
//                //{

//                //}    
//                //else if (b != -1)
//                //{

//                //}
//                //else if (c != -1)
//                //{

//                //}  
//                //else
//                //    break;

//                //    last = a;
//            }

//            jolts3++;

//            Answer = (jolts1 * jolts3).ToString();

//            return this;
//        }

//    }
//}
