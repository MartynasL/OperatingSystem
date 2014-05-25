using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem.Processes
{
    public class StartStop: Process
    {
        public StartStop(LinkedList<Process> processList,
                       int ID, OSCore.ProcessName externalID,
                       VirtualRealMachine.CPU processor,
                       OSCore os, OSCore.ProcessState state, Process parent,
                       int priority)
            : base(processList, ID, externalID,processor, os, state,
                                           parent, priority)
        {            
            
        }

        public override void execute()
        {
            switch (step)
            {
                case 1:
                    createStaticResources();
                    step++;
                    break;
                case 2:
                    createSystemProcesses();
                    step++;
                    break;
                case 3:
                    descriptor.os.requestResource(this, OSCore.ResourceName.PABAIGA);
                    step++;
                    break;
                case 4:
                    destroySystemProcesses();
                    step++;
                    break;
                case 5:
                    destroyStaticResources();
                    descriptor.os.destroyProcess(this);
                    descriptor.os.curProcess = null;
                    descriptor.os.form.writeToOutputConsole("OS HAS BEEN HALTED");
                    descriptor.os.form.enableStart();
                    descriptor.os.form.disableStep();
                    break;                    
            }
        }

        private void destroyStaticResources()
        {
            LinkedList<Resource> destrResList = new LinkedList<Resource>();
            foreach (Resource resource in descriptor.createdResList)
            {
                destrResList.AddLast(resource);
            }
            foreach (Resource resource in destrResList)
            {
                descriptor.os.destroyResource(resource);
            }
        }

        private void destroySystemProcesses()
        {
            LinkedList<Process> destrProcList = new LinkedList<Process>();
            foreach (Process process in descriptor.childrenList)
            {
                destrProcList.AddLast(process);
            }
            foreach (Process process in destrProcList)
            {
                descriptor.os.destroyProcess(process);
            }
        }

        private void createSystemProcesses()
        {
            descriptor.os.createProcess(this, OSCore.ProcessName.JOB_INPUT);
            descriptor.os.createProcess(this, OSCore.ProcessName.JOB_LOADER);
            descriptor.os.createProcess(this, OSCore.ProcessName.MAIN_PROC);
            descriptor.os.createProcess(this, OSCore.ProcessName.PRINT_LINE);
            descriptor.os.createProcess(this, OSCore.ProcessName.INPUT_LINE);
            descriptor.os.createProcess(this, OSCore.ProcessName.INTERRUPT);
        }

        private void createStaticResources()
        {
            VirtualRealMachine.Machine machine = descriptor.os.machine;

            descriptor.os.createResource(this, OSCore.ResourceName.TRECIAS_KANALAS, machine.hddManager);
            descriptor.os.createResource(this, OSCore.ResourceName.SUPERVIZORINE_ATMINTIS, machine.supervisorMemory);
            descriptor.os.createResource(this, OSCore.ResourceName.VARTOTOJO_ATMINTIS, machine.memory);
            descriptor.os.createResource(this, OSCore.ResourceName.PIRMAS_KANALAS, machine.inputDevice);
            descriptor.os.createResource(this, OSCore.ResourceName.ANTRAS_KANALAS, machine.outputDevice);
            descriptor.os.createResource(this, OSCore.ResourceName.UZDUOTIS_ISORINEJE_ATMINTYJE, 0);
        }

    }
}
