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
                    break;
                case 2:
                    descriptor.os.createProcess(this, OSCore.ProcessName.VIRTUAL_MACHINE);
                    step++;
                    break;
                case 3:
                    descriptor.os.requestResource(this, OSCore.ResourceName.IVYKO_PERTRAUKIMAS);
                    step++;
                    break;
                case 4:
                    //not implemented                    
                    break;
                case 5:
                    step = 3;
                    break;
                case 6:
                    descriptor.os.destroyResource(descriptor.ownedResList.First<Resource>());
                    step++;
                    break;
                case 7:
                    descriptor.os.destroyProcess(descriptor.childrenList.First());
                    step++;
                    break;
                case 8:
                    step = 1;
                    break;
            }
        }
    }
}
