using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2CapstoneTaskList
{
    class Task
    {
        public List<string> members;

        
        public string date;
        public bool status;
        public string description;

        //Constructor
        public Task()
        {
            // Instantiating members b.c currently is no.
            members = new List<string>();
            status = false;
        }











    }
}
