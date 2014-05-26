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
            JobGovernor governor = (JobGovernor)parent;
            descriptor.os.machine.cpu.M.setValue((char)('0' + governor.machineNumber));
            descriptor.os.machine.cpu.PR.setValue((VirtualRealMachine.Word)governor.getDescriptor().ownedResList
                .Last.Value.getDescriptor().component);
            descriptor.os.machine.cpu.TIMER.setValue("10");
            descriptor.os.machine.cpu.SP.setValue(new VirtualRealMachine.Word(descriptor.os.machine.memory.
                getWordAtAddress(descriptor.os.machine.cpu.PR.getValue().toInt() * 10 + 9).ToString()));
            descriptor.savedState.saveState(descriptor.os.machine.cpu);
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
                    //int i = 0;
                    //while (!descriptor.os.machine.cpu.stopMachine && i != 10000)
                    //{
                    //    if (descriptor.os.machine.cpu.execute(descriptor.os.machine.interpretator) == true)
                    //    {
                    //        break;
                    //    }
                    //    i++;
                    //}
                    VirtualRealMachine.Form1 VMForm = new VirtualRealMachine.Form1();
                    VMForm.machine = descriptor.os.machine;
                    VMForm.ShowDialog();
                    step++;
                    break;
                case 3:
                    descriptor.savedState.saveState(descriptor.processor);
                    descriptor.savedState.refreshCPU(descriptor.processor);
                    descriptor.os.machine.cpu.MODE.setValue('S');
                    descriptor.os.createResource(this, OSCore.ResourceName.PERTRAUKIMAS, descriptor.ID);
                    descriptor.os.stopProcess(this);
                    step++;
                    break;
                case 4:
                    step = 1;
                    break;
            }
        }
    }
}
