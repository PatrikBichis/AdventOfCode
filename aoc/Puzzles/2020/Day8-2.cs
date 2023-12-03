using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
    public class Day8_2 : PuzzelBase, IPuzzel
    {
        public Day8_2(InputType input) : base(input, 8, 2)
        {

        }

        public IPuzzel Run()
        {
            var prg = ReadPrg(Input);
            var result = FindCorruptInstruction(prg);

            Answer = "Acc: " + result.Item1 + ", prg terminated: " + result.Item2 + ".";

            return this;
        }

        private Tuple<int, bool> FindCorruptInstruction(List<Operation> prg)
        {
            var result = new Tuple<int, bool>(-1, false);

            foreach (var op in prg)
            {
                if (op.OpCode == "nop" || op.OpCode == "jmp")
                {
                    op.OpCode = ChangeOpCode(op);

                    result = ExecutePrg(prg);

                    if (result.Item2 == true)
                        return result;
                    else
                        op.OpCode = ChangeOpCode(op);

                    ResetPrg(ref prg);
                }
            }

            return result;
        }

        private void ResetPrg(ref List<Operation> prg)
        {
            prg.ForEach(x => x.HasExecuted = false);
        }

        private string ChangeOpCode(Operation op)
        {
            if (op.OpCode == "nop")
                return "jmp";
            else if (op.OpCode == "jmp")
                return "nop";
            else
                return op.OpCode;
        }

        private Tuple<int, bool> ExecutePrg(List<Operation> prg)
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


            return new Tuple<int,bool>(accumulator, prgPointer >= prg.Count);
        }

        private List<Operation> ReadPrg(string[] prgFile)
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
}
