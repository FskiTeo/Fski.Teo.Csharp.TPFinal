using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiminski.RG.DAL.Model
{
    public class Mission
    {
        public int MissionId { get; set; }

        public string Lieu { get; set; }

        public int Year { get; set; }

        public int? EspionId { get; set; }

        public Mission() { }

        public Mission(string lieu, int year)
        {
            this.Lieu = lieu;
            this.Year = year;
        }
    }
}
