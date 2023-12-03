using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
   public class Day14_1 : PuzzelBase, IPuzzel
   {

       public Day14_1(InputType input) : base(input, 14, 1)
       {
           
       }

       public IPuzzel Run()
       {
            string mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X";
            var memory = new Dictionary<int, int>();


            WriteToMemory(ref memory, 8, ApplyMask(mask, 11));
            WriteToMemory(ref memory, 7, ApplyMask(mask, 101));
            WriteToMemory(ref memory, 8, ApplyMask(mask, 0));

            Answer = memory.Sum(x => x.Value).ToString();



            return this;
       }

        private void WriteToMemory(ref Dictionary<int,int> memory, int index, int value)
        {
            if (memory.ContainsKey(index))
                memory[index] = value;
            else
                memory.Add(index, value);
        }

        private int ApplyMask(string mask, int value)
        {
            value = value.SetBitTo0(1);
            value = value.SetBitTo1(6);

            return value;
        }

        static string GetIntBinaryString(int n)
        {
            char[] b = new char[36];
            int pos = 35;
            int i = 0;

            while (i < 36)
            {
                if ((n & (1 << i)) != 0)
                    b[pos] = '1';
                else
                    b[pos] = '0';
                pos--;
                i++;
            }
            return new string(b);
        }

    }

    static class BitExtensions
    {
        public static int SetBitTo1(this int value, int position)
        {
            // Set a bit at position to 1.
            return value |= (1 << position);
        }

        public static int SetBitTo0(this int value, int position)
        {
            // Set a bit at position to 0.
            return value & ~(1 << position);
        }

        public static bool IsBitSetTo1(this int value, int position)
        {
            // Return whether bit at position is set to 1.
            return (value & (1 << position)) != 0;
        }

        public static bool IsBitSetTo0(this int value, int position)
        {
            // If not 1, bit is 0.
            return !IsBitSetTo1(value, position);
        }
    }

} 