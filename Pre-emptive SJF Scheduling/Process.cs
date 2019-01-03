using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_emptive_SJF_Scheduling
{
    public class Process
    {
        public string name { get; set; }
        public int arrivalTime { get; set; }
        public int burstTime { get; set; }
        private int RemainingTime;
        public int remainingTime
        {
            get
            {
                if (RemainingTime < 0)
                    return 0;
                return RemainingTime;
            }
            set { RemainingTime = value; }

        }
        public int finishTime { get; set; }

        public int waitingTime
        {
            get
            {
                return finishTime - arrivalTime - burstTime;
            }

        }
        public Process(string name, int arrivalTime, int burstTime)
        {
            this.name = name;
            this.arrivalTime = arrivalTime;
            this.burstTime = burstTime;
            this.remainingTime = burstTime;

        }

    }
}
