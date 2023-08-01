using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingShedule.Data
{
    internal class Employee
    {
        int id;
        string name = string.Empty;
        int initHours;
        string restHours=string.Empty;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int InitHours { get { return initHours; } set { initHours = value; } }
        public string RestHours { get { return restHours; } set { restHours = value; } }

        public  List<dayPosition> PositionsList;
         
    }
}
