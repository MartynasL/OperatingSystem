using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem.Processes
{
    public class MainProc: Process
    {
        public MainProc(LinkedList<Process> processList,
                       int ID, OSCore.ProcessName externalID,
                       VirtualRealMachine.CPU processor,
                       OSCore os, OSCore.ProcessState state, Process parent,
                       int priority)
            : base(processList, ID, externalID, processor, os, state,
                                           parent, priority)
        {

        }

        public override void execute()
        {
            switch (step)
            {
                case 1:
                    descriptor.os.requestResource(this, OSCore.ResourceName.UZDUOTIS_VARTOTOJO_ATMINTYJE);
                    step++;
                    prepared = true;
                    break;
                case 2:
                    //not implemented
                    break;
                case 3:
                    step = 1;
                    break;
            }
        }
    }
}
