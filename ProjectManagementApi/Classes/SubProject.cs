using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApi.Classes
{
    public class SubProject
    {
        public SubProject() { }
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Started { get; set; }
        public List<Situation> Situations { get; set; } = new List<Situation>();
        public int Fk { get; set; }
    }
}
