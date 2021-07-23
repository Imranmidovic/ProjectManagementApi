using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApi.Classes
{
    public class Situation
    {
        public Situation() { }
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Started { get; set; }
        public int Fk { get; set; }
    }
}
