using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashTrack.Model
{
    internal class Expense
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public double Ammount { get; set; }

        public DateTime Date { get; set; }
    }
}