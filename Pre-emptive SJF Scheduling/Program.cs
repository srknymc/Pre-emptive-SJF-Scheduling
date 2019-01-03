using System;
using System.Collections.Generic;
using System.Linq;


namespace Pre_emptive_SJF_Scheduling
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter the total no of processes:");
            int totalProcess = Convert.ToInt32(Console.ReadLine());//get number of processes from user
            List<Process> pList = new List<Process>(); //Process list
            for (int i = 0; i < totalProcess; i++) //get processes properties from user
            {
                Console.Write("Enter p_name: ");
                string p_name = Console.ReadLine();
                Console.Write("Enter p_arrival: ");
                int p_arrival = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter p_burst: ");
                int p_burst = Convert.ToInt32(Console.ReadLine());
                pList.Add(new Process(p_name, p_arrival, p_burst));//add to list given processes
                Console.WriteLine();
            }
            pList = pList.OrderBy(x => x.arrivalTime).ToList();//update list as ordered by arrivalTime 
            int completedProcess = 0; //number of completed processes
            int currtime = 0; //time variable
            while (completedProcess < totalProcess) //loop until all processes are completed
            {
                var list = pList.Where(x => x.arrivalTime <= currtime && x.remainingTime > 0).ToList(); //list for which processes' arrival time less or equal than current time and its not completed
                if (list.Count != 0) //if list contains any processes
                {
                    int i = pList.IndexOf(getMinRemaining(list, currtime));//find the minimum process which is ready to run
                    pList.ElementAt(i).remainingTime--;//decrease remaining time
                    if (pList.ElementAt(i).remainingTime == 0)//if its completed set finish time and increase number of completed process
                    {
                        pList.ElementAt(i).finishTime = currtime + 1;
                        completedProcess++;
                    }
                }
                currtime++;//increase time every step
            }
            /*
             * Print all status of processes and
             * calculate total waiting time and
             * avarage waiting time
             */
            Console.WriteLine("ProcessName" + "\t"
                + "ArrivalTime" + "\t"
                + "BurstTime" + "\t"
                + "WaitingTime" + "\t"
                );
            foreach (Process p in pList)
            {
                Console.WriteLine("{0,7}{1,14}{2,16}{3,16}", p.name, p.arrivalTime, p.burstTime, p.waitingTime);
            }
            Console.WriteLine("Total waiting time: " + pList.Sum(x => Convert.ToInt32(x.waitingTime)));
            Console.WriteLine("Average waiting time: " + pList.Average(x => Convert.ToDouble(x.waitingTime)));
            Console.ReadLine();
        }
        static Process getMinRemaining(List<Process> list, int currtime)//get process which has the minimum remaining time
        {
            return list.OrderBy(x => x.remainingTime).ToList().First();
        }
    }
}
