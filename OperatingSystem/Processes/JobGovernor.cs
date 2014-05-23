using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem.Processes
{
    public class JobGovernor: Process
    {
        public int machineNumber;

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
                    descriptor.os.createProcess(this, OSCore.ProcessName.VIRTUAL_MACHINE);
                    descriptor.childrenList.Last.Value.getDescriptor()
                       .ownedResList.AddLast(descriptor.ownedResList.Last.Value);
                    descriptor.ownedResList.RemoveLast();
                    step++;
                    break;
                case 2:
                    descriptor.os.requestResource(this, OSCore.ResourceName.IVYKO_PERTRAUKIMAS);
                    step++;
                    break;
                case 3:
                    handleInterrupt();
                    step++;
                    break;
                case 4:
                    foreach (Resource resource in descriptor.ownedResList)
                    {
                        if ((resource.getDescriptor().externalID == OSCore.ResourceName.EILUTE_ATSPAUSDINTA) ||
                        (resource.getDescriptor().externalID == OSCore.ResourceName.EILUTE_IVESTA))
                            descriptor.os.destroyResource(resource);
                    }
                    step = 2;
                    break;
                case 5:
                    descriptor.os.destroyResource(descriptor.ownedResList.First<Resource>());
                    step++;
                    break;
                case 6:
                    descriptor.os.createResource(this, OSCore.ResourceName.UZDUOTIS_VARTOTOJO_ATMINTYJE, null);
                    step++;
                    break;
                case 7:
                    step = 1;
                    break;
            }
        }

        private void handleInterrupt()
        {
            string interrupt = (string) descriptor.ownedResList.First().getDescriptor().component;
            interrupt = interrupt.Substring(1);

            switch (interrupt)
            {
                case "PI1":
                    //msg
                    break;
                case "PI2":
                    //msg
                    break;
                case "PI3":
                    //msg
                    break;
                case "PI4":
                    //msg
                    break;
                case "PI5":
                    //msg
                    break;
                case "SI1":
                    int block = descriptor.childrenList.First().getDescriptor().savedState.B.toInt() / 10;
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PEOCESUI_INPUT_LINE, block);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_IVESTA);
                    break;
                case "SI2":
                    block = descriptor.childrenList.First().getDescriptor().savedState.B.toInt() / 10;
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE, block);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);
                    break;
                case "SI3":
                    step = 5;
                    break;
                case "IOI1":
                    //msg
                    break;
                case "IOI2":
                    //msg
                    break;
                case "IOI3":
                    //msg
                    break;
                case "IOI4":
                    //msg
                    break;
                case "IOI5":
                    //msg
                    break;
                case "IOI6":
                    //msg
                    break;
                case "IOI7":
                    //msg
                    break;
                case "TI1":
                    //ready?
                    break;
            }
        }
    }
}
