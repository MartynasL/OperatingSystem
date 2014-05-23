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
                        descriptor.os.createResource(this, OSCore.ResourceName.UZDUOTIES_IVEDIMAS, null);
                    step++;
                    break;
                case 4:
                    if (interrupt == "SI5")
                        descriptor.os.createResource(this, OSCore.ResourceName.PABAIGA, null); 
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
            if (descriptor.os.machine.cpu.PI.getValue() != '0')
            {
                return "PI" + innerIdentificate(descriptor.os.machine.cpu.PI.getValue(), 5);
            }
            if (descriptor.os.machine.cpu.SI.getValue() != '0')
            {
                return "SI" + innerIdentificate(descriptor.os.machine.cpu.SI.getValue(), 5);
            }
            if (descriptor.os.machine.cpu.IOI.getValue() != '0')
            {
                return "IOI" + innerIdentificate(descriptor.os.machine.cpu.IOI.getValue(), 7);
            }
            if (descriptor.os.machine.cpu.TI.getValue() != '0')
            {
                return "TI" + innerIdentificate(descriptor.os.machine.cpu.TI.getValue(), 1);
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
            return descriptor.os.machine.cpu.M.getIntValue();
        }
    }
}
