using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem.Processes
{
    public class Interrupt: Process
    {
        public Interrupt(LinkedList<Process> processList,
                       int ID, OSCore.ProcessName externalID,
                       RegState savedState, VirtualRealMachine.CPU processor,
                       OSCore os, OSCore.ProcessState state, Process parent,
                       int priority)
            : base(processList, ID, externalID, savedState, processor, os, state,
                                           parent, priority)
        {

        }

        public void execute()
        {
            switch (step)
            {
                case 1:
                    descriptor.os.requestResource(this, OSCore.ResourceName.PERTRAUKIMAS);
                    step++;
                    break;
                case 2:
                    //not implemented
                    step++;
                    break;
                case 3:
                    //not implemented
                    step++;
                    break;
                case 4:
                    //not implemented 
                    step++;
                    break;
                case 5:
                    //not implemented
                    step++;
                    break;
                case 6:
                    //gsd
                    step++;
                    break;
                case 7:
                    descriptor.ownedResList.RemoveFirst();
                    step++;
                    break;
                case 8:
                    step = 1;
                    break;
            }
        }
    }
}
