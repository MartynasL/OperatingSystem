using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem.Processes
{
    public class PrintLine: Process
    {
        public PrintLine(LinkedList<Process> processList,
                       int ID, OSCore.ProcessName externalID,
                       VirtualRealMachine.CPU processor,
                       OSCore os, OSCore.ProcessState state, Process parent,
                       int priority)
            : base(processList, ID, externalID, processor, os, state,
                                           parent, priority)
        {

        }

        public Form1 form = Form1.Self;
        private string comp = null;

        public override void execute()
        {
            switch (step)
            {
                case 1:
                    descriptor.os.requestResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE);
                    step++;
                    break;
                case 2:
                    descriptor.os.requestResource(this, OSCore.ResourceName.ANTRAS_KANALAS);
                    step++;
                    break;
                case 3:
                    string component = (string) descriptor.ownedResList.First<Resource>().getDescriptor().component;
                    char[] info = new char[3];
                    component.ToCharArray().CopyTo(info, 0);
                    int block = Convert.ToInt32(String.Concat(info[1], info[2]));
                    if (info[0] == 'S')
                        descriptor.os.machine.cpu.output(descriptor.os.machine.supervisorMemory, 
                            descriptor.os.machine.outputDevice, block);
                    else
                        descriptor.os.machine.cpu.output(descriptor.os.machine.memory,
                            descriptor.os.machine.outputDevice, block);
                    form.getOutput();
                    comp = (string)descriptor.ownedResList.First.Value.getDescriptor()
                        .creator.getDescriptor().ownedResList.Last.Value.getDescriptor().component;
                    step++;
                    break;
                case 4:
                    descriptor.os.machine.cpu.tempK2 = descriptor.os.machine.cpu.K2.getValue();
                    descriptor.os.destroyResource(descriptor.ownedResList.First<Resource>());
                    step++;
                    break;
                case 5:
                    descriptor.os.releaseResource(descriptor.ownedResList.First<Resource>());
                    step++;
                    break;
                case 6:
                    descriptor.os.createResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA, comp);
                    step++;
                    break;
                case 7:
                    step = 1;
                    break;
            }
        }
    }
}
