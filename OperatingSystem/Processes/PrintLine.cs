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
                       RegState savedState, VirtualRealMachine.CPU processor,
                       OSCore os, OSCore.ProcessState state, Process parent,
                       int priority)
            : base(processList, ID, externalID, savedState, processor, os, state,
                                           parent, priority)
        {

        }

        public void execute()
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
                    //not implemented
                    break;
                case 4:
                    descriptor.ownedResList.RemoveFirst();
                    step++;
                    break;
                case 5:
                    descriptor.os.releaseResource(descriptor.ownedResList.First<Resource>());
                    step++;
                    break;
                case 6:
                    descriptor.os.createResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);
                    step++;
                    break;
                case 7:
                    step = 1;
                    break;
            }
        }
    }
}
