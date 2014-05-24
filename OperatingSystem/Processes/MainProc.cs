using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem.Processes
{
    public class MainProc: Process
    {
        private bool[] machines;

        public MainProc(LinkedList<Process> processList,
                       int ID, OSCore.ProcessName externalID,
                       VirtualRealMachine.CPU processor,
                       OSCore os, OSCore.ProcessState state, Process parent,
                       int priority)
            : base(processList, ID, externalID, processor, os, state,
                                           parent, priority)
        {
            machines = new bool[10];
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
                    if (descriptor.ownedResList.Last.Value.getDescriptor().creator is JobLoader)
                    {
                        descriptor.os.createProcess(this, OSCore.ProcessName.JOB_GOVERNOR);
                        descriptor.childrenList.Last.Value.getDescriptor()
                            .ownedResList.AddLast(descriptor.ownedResList.Last.Value);
                        JobGovernor childrenGovernor = (JobGovernor)descriptor.childrenList.Last.Value;
                        descriptor.ownedResList.Last.Value.getDescriptor().user = childrenGovernor;
                        for (int i = 0; i < 10; i++)
                        {
                            if (machines[i] == false)
                            {
                                machines[i] = true;
                                childrenGovernor.machineNumber = i;
                                break;
                            }
                        }
                        descriptor.ownedResList.RemoveLast();
                    }
                    else if (descriptor.ownedResList.Last.Value.getDescriptor().creator is JobGovernor)
                    {
                        descriptor.os.destroyProcess(descriptor.ownedResList.Last.Value.getDescriptor().creator);
                        JobGovernor childrenGovernor = (JobGovernor)descriptor.ownedResList.Last.Value.getDescriptor().creator;
                        machines[childrenGovernor.machineNumber] = false;
                    }
                    step++;
                    break;
                case 3:
                    step = 1;
                    break;
            }
        }
    }
}
