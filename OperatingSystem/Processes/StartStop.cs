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
                    createStaticResources();
                    createSystemProcesses();
                    step++;
                    break;
                case 2:
                    //request resources
                case 3:
                    destroySystemProcesses();
                    destroyStaticResources();
                    break;                    
            }
        }

        private void destroyStaticResources()
        {
            foreach(Resource resource in descriptor.createdResList)
            {
                descriptor.os.destroyResource(resource);
            }
        }

        private void destroySystemProcesses()
        {
            foreach (Process process in descriptor.childrenList)
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
            descriptor.os.createResource(this, OSCore.ResourceName.TRECIAS_KANALAS);
            descriptor.os.createResource(this, OSCore.ResourceName.SUPERVIZORINE_ATMINTIS);
            descriptor.os.createResource(this, OSCore.ResourceName.VARTOTOJO_ATMINTIS);
            descriptor.os.createResource(this, OSCore.ResourceName.PIRMAS_KANALAS);
            descriptor.os.createResource(this, OSCore.ResourceName.ANTRAS_KANALAS);
        }

    }
}
