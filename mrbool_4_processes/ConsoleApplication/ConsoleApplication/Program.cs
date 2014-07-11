using System;
using System.Linq;
using System.Diagnostics;

namespace ConsoleApplication
{
    class Program
    {

        // exploring Process - AppDomain (like a partition in a process) - Assembly - Modules

        static void Main(string[] args)
        {

            var runningProcesses = from proc in Process.GetProcesses(".") orderby proc.Id select proc;
            foreach (var runningProcess in runningProcesses)
            {
                string processInfo = string.Format("PID: {0}\tName: {1}", runningProcess.Id, runningProcess.ProcessName);
                Console.WriteLine(processInfo);
            }

            //Console.WriteLine("Enter a process id to get the threads: ");
            //int id = int.Parse(Console.ReadLine());
            //
            //Process aProcess = Process.GetProcessById(id);
            //ProcessThreadCollection threadCollection = aProcess.Threads;
            //foreach (ProcessThread pt in threadCollection)
            //{
            //    string threadInfo = string.Format("\tThread ID: {0}\tStart Time: {1}\tPriority: {2}", pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
            //    Console.WriteLine(threadInfo);
            //}

            Console.WriteLine("Enter a process id to get the modules: ");
            int id = int.Parse(Console.ReadLine());
            Process aProcess = Process.GetProcessById(id);
            ProcessModuleCollection processModuleCollection = aProcess.Modules;
            foreach (ProcessModule processModule in processModuleCollection)
            {
                string moduleInfo = string.Format("\tModuleName: {0}", processModule.ModuleName);
            }


            Console.ReadLine();
        }
    }
}
