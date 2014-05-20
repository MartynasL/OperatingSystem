using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem.Processes
{
    public class VirtualMachine: Process
    {
        public VirtualMachine(LinkedList<Process> processList,
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
                    break;
                case 2:
                    //not implemented
                    break;
                case 3:
                    //not implemented
                    break;
            }
        }
    }
}
