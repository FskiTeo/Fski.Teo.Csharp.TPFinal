using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiminski.RG.DAL.Model
{
    public class Espion
    {
        public int EspionId { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }

        public List<Mission> Missions { get; set; }

        public Espion() { }

        public Espion(string name, string code)
        {
            this.Name = name;
            this.Code = code;
        }
        
        public Espion(string name, string code, List<Mission> missions)
        {
            this.Name = name;
            this.Code = code;
            this.Missions = missions;
        }
    }
}
