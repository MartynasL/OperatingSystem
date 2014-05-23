using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem.Processes
{
    public class JobLoader: Process
    {
        private VirtualRealMachine.Word PRValue;

        public JobLoader(LinkedList<Process> processList,
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
                    descriptor.os.requestResource(this, OSCore.ResourceName.UZDUOTIS_ISORINEJE_ATMINTYJE);
                    step++;
                    break;
                case 2:
                    descriptor.os.requestResource(this, OSCore.ResourceName.VARTOTOJO_ATMINTIS);
                    step++;
                    break;
                case 3:
                    PRValue = descriptor.os.ramManager.getPageTableAddress();
                    for(int j = 0; j < 10; j++)
                    {
                        for(int i = 0; i < 10; i++)
                        {
                            descriptor.os.machine.cpu.input(descriptor.os.machine.memory,
                                descriptor.os.machine.hddManager, (PRValue.toInt() + j) * 10 + i,
                                (int)descriptor.ownedResList.First.Value.getDescriptor().component - 10 + i);
                        }
                    }
                    break;
                case 4:
                    descriptor.os.createResource(this, OSCore.ResourceName.UZDUOTIS_VARTOTOJO_ATMINTYJE, PRValue);
                    step++;
                    break;
                case 5:
                    descriptor.os.releaseResource(descriptor.ownedResList.Last<Resource>());
                    step++;
                    break;
                case 6:
                    descriptor.os.destroyResource(descriptor.ownedResList.Last<Resource>());
                    step++;
                    break;
                case 7:
                    step = 1;
                    break;
            }
        }
    }
}
