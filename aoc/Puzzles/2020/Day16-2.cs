using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2020
{
   public class Day16_2 : PuzzelBase, IPuzzel
   {

       public Day16_2(InputType input) : base(input, 16, 2)
       {
           
       }

        public IPuzzel Run()
        {
            var fields = new List<Field>();
            var _class = new Field();
            var _row = new Field();
            var _seat = new Field();
            var tickets = new List<Ticket>();
            var ticketValues = new List<int>();
            var notValidValues = new List<int>();

            ExtractDataFromInput(ref fields, ref tickets);

            FindNonValidTickets(ref tickets, fields);

            var columns = FindColumnIndexes(tickets.Where(x => x.IsValid).ToList(), fields);

            var myTicket = tickets.First(x => x.IsMyTicket);
            var a1 = (double) myTicket.Values[columns.First(x => x.Field == "departure location").Index];
            var a2 = (double) myTicket.Values[columns.First(x => x.Field == "departure station").Index];
            var a3 = (double) myTicket.Values[columns.First(x => x.Field == "departure platform").Index];
            var a4 = (double) myTicket.Values[columns.First(x => x.Field == "departure track").Index];
            var a5 = (double) myTicket.Values[columns.First(x => x.Field == "departure date").Index];
            var a6 = (double) myTicket.Values[columns.First(x => x.Field == "departure time").Index];

            Answer = (a1 * a2 * a3 * a4 * a5 * a6).ToString();

            return this;
        }

        private List<Column> FindColumnIndexes(List<Ticket> tickets, List<Field> fields)
        {
            var columns = new List<Column>();
            foreach (var field in fields)
            {
                for (int i = 0; i < tickets[0].Values.Count(); i++)
                {
                    // Extract field value from all tickets
                    var values = new List<int>();
                    foreach (var ticket in tickets)
                    {
                        values.Add(ticket.Values[i]);
                    }

                    // Test if all values is in range for the column
                    var ok = true;
                    foreach (var v in values)
                    {
                        if (!field.IsValuesInRange(v))
                        {
                            ok = false;
                            break;
                        }
                    }

                    // All tickts value for a column is valid for this field
                    if (ok)
                    {
                        columns.Add(new Column { Index = i, Field = field.Name });
                    }
                  
                }
            }

            // Clean to find right columns
            while (columns.Count() > fields.Count())
            {
                for (var i = 0; i< fields.Count(); i++)
                {
                    var columsWithIndex = columns.Where(x => x.Index == i && x.Found == false);
                    foreach(var c in columsWithIndex)
                    {
                        if(columns.Count(x=>x.Field == c.Field) == 1)
                        {
                            var single = c;
                            c.Found = true;

                            foreach(var r in columns.Where(x=>x.Index == c.Index).ToList())
                            {
                                if (!r.Found)
                                {
                                    columns.Remove(r);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            /*
            foreach(var column in indexes)
            {
                Console.WriteLine("{0};{1};", column.Field, column.Index);
            }*/

            return columns;
        }

        private void FindNonValidTickets(ref List<Ticket> tickets, List<Field> fields)
        {
            // Find all non valid tickets
            foreach (var ticket in tickets)
            {
                foreach (var i in ticket.Values)
                {
                    var index = 0;
                    var ok1 = fields[0].IsValuesInRange(i);
                    var ok2 = fields[1].IsValuesInRange(i);
                    var ok3 = fields[2].IsValuesInRange(i);
                    if (fields.All(x=>x.IsValuesInRange(i) == false))
                    {
                        ticket.IsValid = false;
                        ticket.NonValidValues.Add(i);
                        ticket.NonValidIndex.Add(index);
                    }
                    index++;
                }
            }
        }

        private void ExtractDataFromInput(ref List<Field> fields, ref List<Ticket> tickets)
        {
            var yourTicketSeactions = false;
            var ticketSection = false;

            foreach (var line in Input)
            {
                if (line != "")
                {
                    if(!line.Contains("your ticket") && !line.Contains("nearby tickets") && !yourTicketSeactions && !ticketSection)
                    {
                        var r = new Field();
                        ExtractRules(ref r, line);
                        fields.Add(r);
                    }

                    if (ticketSection)
                    {
                        var ticket = new Ticket();
                        var parts = line.Split(",");
                        foreach (var p in parts)
                        {
                            ticket.Values.Add(int.Parse(p));
                        }

                        tickets.Add(ticket);
                    }

                    if (yourTicketSeactions && !ticketSection)
                    {
                        var ticket = new Ticket();
                        ticket.IsMyTicket = true;
                        var parts = line.Split(",");
                        foreach (var p in parts)
                        {
                            ticket.Values.Add(int.Parse(p));
                        }

                        tickets.Add(ticket);
                        yourTicketSeactions = false;
                    }

                    if (line.Contains("your ticket"))
                        yourTicketSeactions = true;

                    if (line.Contains("nearby tickets"))
                        ticketSection = true;
                }
            }
        }

        private void ExtractRules(ref Field list, string line)
        {
            var parts = line.Split(':');
            var ranges = parts[1].Split("or");

            list.Name = parts[0];

            foreach (var r in ranges)
            {
                var limits = r.Trim().Split("-");
                var range = new Range(parts[0]);
                range.Lower = int.Parse(limits[0]);
                range.Upper = int.Parse(limits[1]);
                list.Ranges.Add(range);
            }
        }
    }

    class Column
    {
        public int Index { get; set; } = 0;

        public string Field { get; set; } = "";

        public bool Found { get; set; } = false;
    }

    class Ticket
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public bool IsMyTicket { get; set; } = false;

        public List<int> Values { get; set; } = new List<int>();

        public List<int> NonValidValues { get; set; } = new List<int>();

        public List<int> NonValidIndex { get; set; } = new List<int>();

        public bool IsValid = true;
    }
} 