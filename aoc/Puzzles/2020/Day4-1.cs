using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
    public class Day4_1 : PuzzelBase, IPuzzel
    {
        public Day4_1(InputType input) : base(input, 4, 1)
        {
            
        }

        public IPuzzel Run()
        {
            var NrOfValidCred = 0;
            var credentials = ExtractCredentials(Input);

            var nrOfValid = credentials.Count(x => x.Valid == true) ;

            Answer = nrOfValid.ToString();

            return this;
        }

        private List<Credential> ExtractCredentials(string[] input)
        {
            var list = new List<Credential>();
            var item = new Credential();

            foreach(var l in input)
            {
                if(l == String.Empty)
                {
                    list.Add(item);
                    item = new Credential();
                }
                else
                {
                    var parts = l.Split(' ');
                    foreach(var p in parts)
                    {
                        UpdateParams(ref item, p);
                    }
                }
            }

            return list;
        } 

        private void UpdateParams(ref Credential item, string p)
        {
            var param = p.Split(':');

            if (param[0] == "byr") { item.byr = param[1]; item.hasByr = true; }
            if (param[0] == "iyr") { item.iyr = param[1]; item.hasIyr = true; }
            if (param[0] == "eyr") { item.eyr = param[1]; item.hasEyr = true; }
            if (param[0] == "hgt") { item.hgt = param[1]; item.hasHgt = true; }
            if (param[0] == "hcl") { item.hcl = param[1]; item.hasHcl = true; }
            if (param[0] == "ecl") { item.ecl = param[1]; item.hasEcl = true; }
            if (param[0] == "pid") { item.pid = param[1]; item.hasPid = true; }
            if (param[0] == "cid") { item.cid = param[1]; item.hasCid = true; }
        }
    }

    public class Credential
    {
        public bool hasByr { get; set; }
        public bool hasIyr { get; set; }
        public bool hasEyr { get; set; }
        public bool hasHgt { get; set; }
        public bool hasHcl { get; set; }
        public bool hasEcl { get; set; }
        public bool hasPid { get; set; }
        public bool hasCid { get; set; }

        public string byr { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        public string cid { get; set; }

        public bool Valid
        {
            get
            {
                return hasByr && hasEcl && hasEyr && hasHcl && hasHgt && hasIyr && hasPid;
            }
        }
    }
}
