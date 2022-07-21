using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    static class Dbcontext
    {
        static Dbcontext()
        {
            Students=new List<Student>();
            Groups=new List<Group>();
        }
        public static List<Student>Students { get; set; }
        public static List<Group>Groups { get; set; }
    }
}
