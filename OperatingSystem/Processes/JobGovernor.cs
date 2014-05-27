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
        public Form1 form = Form1.Self;

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
                    //descriptor.childrenList.Last.Value.getDescriptor()
                    //   .ownedResList.AddLast(descriptor.ownedResList.Last.Value);
                    //descriptor.ownedResList.Last.Value.getDescriptor().user = descriptor.childrenList.Last.Value;
                    //descriptor.ownedResList.RemoveLast();
                    step++;
                    break;
                case 2:
                    descriptor.os.requestResource(this, OSCore.ResourceName.IVYKO_PERTRAUKIMAS);
                    step++;
                    break;
                case 3:
                    handleInterrupt();
                    descriptor.os.activateProcess(descriptor.childrenList.Last.Value);
                    step++;
                    break;
                case 4:
                    foreach (Resource resource in descriptor.ownedResList)
                    {
                        if ((resource.getDescriptor().externalID == OSCore.ResourceName.EILUTE_ATSPAUSDINTA) ||
                        (resource.getDescriptor().externalID == OSCore.ResourceName.EILUTE_IVESTA))
                        {
                            descriptor.os.destroyResource(resource);
                            //descriptor.os.destroyResource(descriptor.ownedResList.Last.Value);
                            break;
                        }
                    }
                    descriptor.os.destroyResource(descriptor.ownedResList.Last<Resource>());
                    step = 2;
                    break;
                case 5:
                    descriptor.os.ramManager.freeBlocks((VirtualRealMachine.Word)descriptor.ownedResList.First.
                        Value.getDescriptor().component);
                    descriptor.os.destroyResource(descriptor.ownedResList.First<Resource>());
                    step++;
                    break;
                case 6:
                    //descriptor.os.ramManager.freeBlocks((VirtualRealMachine.Word)descriptor.childrenList
                    //    .First.Value.getDescriptor().ownedResList.First.Value.getDescriptor().component);
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
            string interrupt = (string) descriptor.ownedResList.Last().getDescriptor().component;
            for (int i = 0; i < interrupt.Length; i++)
            {
                if (!Char.IsDigit(interrupt, i))
                {
                    interrupt = interrupt.Substring(i);
                    break;
                }
            }

            switch (interrupt)
            {
                case "PI1":                    
                    string component = "S14";
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE, component);                    
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);                    
                    break;
                case "PI2":
                    component = "S15";
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE, component);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);
                    break;
                case "PI3":
                    component = "S16";
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE, component);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);
                    break;
                case "PI4":
                    component = "S17";
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE, component);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);
                    break;
                case "PI5":
                    component = "S18";
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE, component);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);
                    break;
                case "SI1":
                    int block = descriptor.childrenList.First().getDescriptor().savedState.B.toInt() / 10;
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_INPUT_LINE, block);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_IVESTA);
                    break;
                case "SI2":
                    component = "V" + descriptor.childrenList.First().getDescriptor().savedState.B.toInt() / 10;
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE, component);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);
                    break;
                case "SI3":
                    descriptor.os.destroyResource(descriptor.ownedResList.Last<Resource>());
                    step = 4;
                    break;
                case "IOI1":
                    component = "S19";
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE, component);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);
                    break;
                case "IOI2":
                    component = "S20";
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE, component);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);
                    break;
                case "IOI3":
                    component = "S21";
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE, component);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);
                    break;
                case "IOI4":
                    component = "S22";
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE, component);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);
                    break;
                case "IOI5":
                    component = "S23";
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE, component);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);
                    break;
                case "IOI6":
                    component = "S24";
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE, component);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);
                    break;
                case "IOI7":
                    component = "S25";
                    descriptor.os.createResource(this, OSCore.ResourceName.PRANESIMAS_PROCESUI_PRINT_LINE, component);
                    descriptor.os.requestResource(this, OSCore.ResourceName.EILUTE_ATSPAUSDINTA);
                    break;
                case "TI1":
                    //descriptor.os.stopProcess(descriptor.childrenList.First.Value);
                    //descriptor.os.stopProcess(this);
                    //foreach (Process process in descriptor.os.stoppedProcesses)
                    //{
                    //    if (process.getDescriptor().externalID == OSCore.ProcessName.JOB_GOVERNOR)
                    //    {
                    //        descriptor.os.activateProcess(process);
                    //        descriptor.os.activateProcess(process.getDescriptor().childrenList.First.Value);
                            //process.getDescriptor().childrenList.First.Value.getDescriptor().savedState.setTimerSavedValue("10");
                    //        break;
                    //    }
                    //}
                    descriptor.childrenList.First.Value.getDescriptor().savedState.setTimerSavedValue("10");
                    break;
            }
        }
    }
}
