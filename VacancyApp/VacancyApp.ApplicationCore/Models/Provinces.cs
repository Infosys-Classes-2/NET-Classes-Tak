using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyApp.ApplicationCore.Models
{
    public class Provinces
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public float Area { get; set; }
        public string Map { get; set; }
        public bool Active { get; set; }
        public DateTime DateTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
