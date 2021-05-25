using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica
{
    class Process
    {
        public int ID { get; set; }
        public int ArrivalTime { get; set; }
        public int ExecutionTime { get; set; }
        public int ExecutedTime { get; set; }
        public int RemaingTime
        {
            get { return this.ExecutionTime - this.ExecutedTime; }
            private set { }
        }
    }
}
