using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
    public class Day8_1 : PuzzelBase, IPuzzel
    {

        public Day8_1(InputType input) : base(input, 8, 1)
        {

        }

        public IPuzzel Run()
        {
            var prg = ReadPrg(Input);
            
            Answer = ExecutePrg(prg).ToString();

            return this;
        }

        public int ExecutePrg(List<Operation> prg)
        {
            var prgPointer = 0;
            var accumulator = 0;

            while (!prg.All(x => x.HasExecuted == true) && prgPointer < prg.Count)
            {
                var opCode = prg[prgPointer].OpCode;
                var arg = prg[prgPointer].Arg;
                var pp = prgPointer;

                if (prg[pp].HasExecuted)
                    break;

                if (opCode == "nop")
                    prgPointer++;
                if (opCode == "acc")
                {
                    accumulator += arg;
                    prgPointer++;
                }
                if (opCode == "jmp")
                    prgPointer += arg;

                prg[pp].HasExecuted = true;
            }

            return accumulator;
        }

        public List<Operation> ReadPrg(string[] prgFile)
        {
            var prg = new List<Operation>();
            foreach (var line in Input)
            {
                var prgLine = line;
                var opCode = prgLine.Substring(0, 3);
                var arg = int.Parse(prgLine.Substring(3).Trim());

                prg.Add(new Operation
                {
                    OpCode = opCode,
                    Arg = arg
                });
            }

            return prg;
        }
    }

    public class Operation
    {
        public string OpCode { get; set; }

        public int Arg { get; set; }

        public bool HasExecuted { get; set; } 
    }
}
