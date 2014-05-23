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
                       VirtualRealMachine.CPU processor,
                       OSCore os, OSCore.ProcessState state, Process parent,
                       int priority)
            : base(processList, ID, externalID, processor, os, state,
                                           parent, priority)
        {
            descriptor.savedState.saveState(descriptor.os.machine.cpu);
            JobGovernor governor = (JobGovernor)parent;
            descriptor.os.machine.cpu.M.setValue((char)('0' + governor.machineNumber));
            descriptor.os.machine.cpu.PR.setValue((VirtualRealMachine.Word)governor.getDescriptor().ownedResList
                .Last.Value.getDescriptor().component);
        }

        public override void execute()
        {
            switch (step)
            {
                case 1:
                    descriptor.savedState.setState(descriptor.os.machine.cpu);
                    descriptor.os.machine.cpu.MODE.setValue('V');
                    step++;
                    break;
                case 2:
                    int i = 0;
                    while (!descriptor.os.machine.cpu.stopMachine && i != 10000)
                    {
                        if (descriptor.os.machine.cpu.execute(descriptor.os.machine.interpretator) == true)
                        {
                            break;
                        }
                        i++;
                    }
                    step++;
                    break;
                case 3:
                    descriptor.savedState.saveState(descriptor.os.machine.cpu);
                    descriptor.os.createResource(this, OSCore.ResourceName.PERTRAUKIMAS, null);
                    descriptor.os.machine.cpu.MODE.setValue('S');
                    step++;
                    break;
                case 4:
                    step = 1;
                    break;
            }
        }
    }
}
