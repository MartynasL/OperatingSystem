using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem.Processes
{
    public class JobGovernor: Process
    {
        public JobGovernor(LinkedList<Process> processList,
                       int ID, OSCore.ProcessName externalID,
                       RegState savedState, VirtualRealMachine.CPU processor,
                       OSCore os, OSCore.ProcessState state, Process parent,
                       int priority)
            : base(processList, ID, externalID, savedState, processor, os, state,
                                           parent, priority)
        {
            switch (step)
            {
                case 1:
                    //not implemented 
                case 2:
                    //not implemented 
                    break;
                case 3:
                    //not implemented 
                    break;
                case 4:
                    //not implemented                    
                    break;
                case 5:
                    //not implemented
                    break;
                case 6:
                    //sdf
                    break;
                case 7:
                    //sdg
                    break;
            }
        }
    }
}
