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
                       VirtualRealMachine.CPU processor,
                       OSCore os, OSCore.ProcessState state, Process parent,
                       int priority)
            : base(processList, ID, externalID, processor, os, state,
                                           parent, priority)
        {

        }

        private string interrupt = null;
        private int machine = 0;

        public override void execute()
        {
            switch (step)
            {
                case 1:
                    descriptor.os.requestResource(this, OSCore.ResourceName.PERTRAUKIMAS);
                    step++;
                    break;
                case 2:
                    interrupt = identificateInterrupt();
                    step++;
                    break;
                case 3:
                    if (interrupt == "SI4")
                    {
                        descriptor.os.machine.cpu.SI.setValue('0');
                        descriptor.os.createResource(this, OSCore.ResourceName.UZDUOTIES_IVEDIMAS, null);
                        descriptor.os.activateProcess(descriptor.ownedResList.First.Value.getDescriptor().creator);
                        descriptor.os.destroyResource(descriptor.ownedResList.First<Resource>());
                        step = 1;
                    }
                    else
                        step++;
                    break;
                case 4:
                    if (interrupt == "SI5")
                    {
                        descriptor.os.machine.cpu.SI.setValue('0');
                        descriptor.os.createResource(this, OSCore.ResourceName.PABAIGA, null);
                        descriptor.os.activateProcess(descriptor.ownedResList.First.Value.getDescriptor().creator);
                        descriptor.os.destroyResource(descriptor.ownedResList.First<Resource>());
                        step = 1;
                    }
                    else
                        step++;
                    break;
                case 5:
                    machine = identificateMachine();
                    step++;
                    break;
                case 6:
                    descriptor.os.createResource(this, OSCore.ResourceName.IVYKO_PERTRAUKIMAS, machine + interrupt);
                    step++;
                    break;
                case 7:
                    descriptor.os.destroyResource(descriptor.ownedResList.First<Resource>());
                    step++;
                    break;
                case 8:
                    step = 1;
                    break;        
            }
        }

        private string identificateInterrupt()
        {
            int innerInterrupt = 0;

            if (descriptor.os.machine.cpu.PI.getValue() != '0')
            {
                innerInterrupt = innerIdentificate(descriptor.os.machine.cpu.PI.getIntValue(), 5);
                descriptor.os.machine.cpu.PI.setValue('0');
                return "PI" + innerInterrupt;
            }
            if (descriptor.os.machine.cpu.SI.getValue() != '0')
            {
                innerInterrupt = innerIdentificate(descriptor.os.machine.cpu.SI.getIntValue(), 5);
                descriptor.os.machine.cpu.SI.setValue('0');
                return "SI" + innerInterrupt;
            }
            if (descriptor.os.machine.cpu.IOI.getValue() != '0')
            {
                innerInterrupt = innerIdentificate(descriptor.os.machine.cpu.IOI.getIntValue(), 7);
                descriptor.os.machine.cpu.IOI.setValue('0');
                return "IOI" + innerInterrupt;
            }
            if (descriptor.os.machine.cpu.TI.getValue() != '0')
            {
                innerInterrupt = innerIdentificate(descriptor.os.machine.cpu.TI.getIntValue(), 1);
                descriptor.os.machine.cpu.TI.setValue('0');
                return "TI" + innerInterrupt;
            }

            return null;
        }

        private int innerIdentificate(int interrupt, int count)
        {
            for (int i = 1; i <= count; i++)
            {
                if (interrupt == i)
                    return i;
            }

            return -1;
        }

        private int identificateMachine()
        {
            return (int)descriptor.ownedResList.First.Value.getDescriptor().component;
        }
    }
}
