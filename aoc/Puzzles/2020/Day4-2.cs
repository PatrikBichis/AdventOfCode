using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc2020
{
    public class Day4_2 : PuzzelBase, IPuzzel
    {
        public Day4_2(InputType input) : base(input, 4, 2)
        {
            Console.WriteLine(Regex.IsMatch("578918570", @"^[0-9]{9}$"));
        }

        public IPuzzel Run()
        {
            var NrOfValidCred = 0;
            var credentials = ExtractCredentials(Input);

            var nrOfValid = credentials.Count(x => x.Valid == true);

            Answer = nrOfValid.ToString();

            return this;
        }

        private List<Credential_v2> ExtractCredentials(string[] input)
        {
            var list = new List<Credential_v2>();
            var item = new Credential_v2();
            var last = "";
            var count = 0;

            foreach (var l in input)
            {
                if (l == String.Empty) count++;

                if (last != String.Empty && l == String.Empty)
                {
                    list.Add(item);
                    item = new Credential_v2();
                }
                else
                {
                    var parts = l.Split(' ');
                    foreach (var p in parts)
                    {
                        UpdateParams(ref item, p);
                    }
                }
                last = l;
            }

            if (last != "")
            {
                if(list.Count > 0 && !list.Last().Equals(item))
                    list.Add(item);
            }

            Console.WriteLine(count);
            Console.WriteLine(list.Count);

            return list;
        }

        private void UpdateParams(ref Credential_v2 item, string p)
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

    public class Credential_v2
    {
        public bool hasByr { get; set; }
        public bool hasIyr { get; set; }
        public bool hasEyr { get; set; }
        public bool hasHgt { get; set; }
        public bool hasHcl { get; set; }
        public bool hasEcl { get; set; }
        public bool hasPid { get; set; }
        public bool hasCid { get; set; }

        public bool validByr {
            get
            {
                if (Regex.IsMatch(byr, @"^[0-9][0-9][0-9][0-9]$"))
                {
                    var year = int.Parse(byr);
                    return year >= 1920 && year <= 2002;
                }
                return false;
            }
        }
        public bool validIyr
        {
            get
            {
                if (Regex.IsMatch(iyr, @"^[0-9][0-9][0-9][0-9]$"))
                {
                    var year = int.Parse(iyr);
                    return year >= 2010 && year <= 2020;
                }
                return false;
            }
        }
        public bool validEyr
        {
            get
            {
                if (Regex.IsMatch(eyr, @"^[0-9][0-9][0-9][0-9]$"))
                {
                    var year = int.Parse(eyr);
                    return year >= 2020 && year <= 2030;
                }
                return false;
            }
        }
        public bool validHgt
        {
            get
            {
                if (hgt.Contains("cm"))
                {
                    var a = int.Parse(hgt.Replace("cm", ""));
                    return a >= 150 && a <= 193;
                }
                else if(hgt.Contains("in"))
                {
                    var a = int.Parse(hgt.Replace("in", ""));
                    return a >= 59 && a <= 76;
                }
                return false;
            }
        }
        public bool validHcl
        {
            get
            {
                return Regex.IsMatch(hcl, @"^[#]([0-9]|[a-f]){6}$");
            }
        }
        public bool validEcl
        {
            get
            {
               return ecl == "amb" ||
                        ecl == "blu" ||
                        ecl == "brn" ||
                        ecl == "gry" ||
                        ecl == "grn" ||
                        ecl == "hzl" ||
                        ecl == "oth";
            }
        }
        public bool validPid
        {
            get
            {
               return  Regex.IsMatch(pid, @"^[0-9]{9}$");
            }
        }

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
                var valid = hasByr &&
                       hasEcl &&
                       hasEyr &&
                       hasHcl &&
                       hasHgt &&
                       hasIyr &&
                       hasPid &&
                       validByr &&
                       validEcl &&
                       validEyr &&
                       validHcl &&
                       validHgt &&
                       validIyr &&
                       validPid;
                return valid;
            }
        }
    }
}

