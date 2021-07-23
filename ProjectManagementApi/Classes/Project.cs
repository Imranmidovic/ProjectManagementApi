using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApi.Classes
{
    public class Project
    {
        public Project() { }
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Started { get; set; }
        public List<SubProject> SubProjects { get; set; } = new List<SubProject>();
    }
}
