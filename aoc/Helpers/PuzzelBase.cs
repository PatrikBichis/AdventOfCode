using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
    public class PuzzelBase
    {
        public string[] Input { get; set; }

        public string Answer { get; set; } = "";

        private int _inputId = 0;
        private int _partId = 0;
        private InputType _type;
        public InputType Type
        {
            get { return _type; }
        }

        public PuzzelBase(InputType test, int inputId, int partId = 1, int year = 2020)
        {
            _inputId = inputId;
            _partId = partId;
            _type = test;

            if (test == InputType.Input)
            {
                Input = File.ReadAllLines("./Input/" + year.ToString() + "/" + inputId + "-input.txt");
            }
            else
            {
                Input = File.ReadAllLines("./Input/" + year.ToString() + "/" + inputId + "-test.txt");
            }
        }

        public void Print()
        {
            if(_partId == 0)
                Console.WriteLine("Day"+ _inputId + " : " + Answer);
            else
                Console.WriteLine("Day" + _inputId + "-" + _partId + " : " + Answer);
        }
    }
}
