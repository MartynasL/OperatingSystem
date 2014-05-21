using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem.Processes
{
    public class JobInput: Process
    {
        public JobInput(LinkedList<Process> processList,
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
                    descriptor.os.requestResource(this, OSCore.ResourceName.UZDUOTIES_IVEDIMAS);
                    step++;
                    break;
                case 2:
                    descriptor.os.requestResource(this, OSCore.ResourceName.TRECIAS_KANALAS);
                    step++;
                    break;
                case 3:
                    descriptor.os.requestResource(this, OSCore.ResourceName.SUPERVIZORINE_ATMINTIS);
                    step++;
                    prepared = true;
                    break;
                case 4:
                    //not implemented                    
                    break;
                case 5:
                    //not implemented
                    break;
                case 6:
                    descriptor.os.releaseResource(descriptor.ownedResList.Last<Resource>());
                    step++;
                    break;
                case 7:
                    descriptor.os.releaseResource(descriptor.ownedResList.Last<Resource>());
                    step++;
                    break;
                case 8:
                    descriptor.os.releaseResource(descriptor.ownedResList.Last<Resource>());
                    step++;
                    break;
                case 9:
                    descriptor.os.destroyResource(descriptor.ownedResList.Last<Resource>());
                    step++;
                    break;
                case 10:
                    step = 1;
                    break;
            }
        }

    }
}
