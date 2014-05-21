using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public class OSCore
    {
        public LinkedList<Process> processes;
        public LinkedList<Process> readyProcesses;
        public LinkedList<Process> blockedProcesses;
        public LinkedList<Process> stoppedProcesses;

        public LinkedList<Resource> resources;
        public LinkedList<Resource> usingResources;
        public LinkedList<Resource> freeResources;

        public ProcessManager processManager;
        public ResourcesManager resourcesManager;

        public VirtualRealMachine.Machine machine;

        private int currentProcID;
        private int currentResID;

        public Process curProcess;

        public enum ProcessName
        {
            START_STOP, JOB_INPUT, JOB_LOADER, MAIN_PROC, PRINT_LINE,
            INPUT_LINE, INTERRUPT, JOB_GOVERNOR, VIRTUAL_MACHINE
        }

        public enum ProcessState
        {
            RUN, READY, STOPPED, BLOCKED
        }

        public enum ResourceName
        {
            TRECIAS_KANALAS, SUPERVIZORINE_ATMINTIS, VARTOTOJO_ATMINTIS,
            PIRMAS_KANALAS, ANTRAS_KANALAS, PABAIGA, UZDUOTIS_ISORINEJE_ATMINTYJE,
            UZDUOTIS_VARTOTOJO_ATMINTYJE, IVYKO_PERTRAUKIMAS, EILUTE_IVESTA, EILUTE_ATSPAUSDINTA,
            PRANESIMAS_PEOCESUI_INPUT_LINE, PRANESIMAS_PROCESUI_PRINT_LINE, PERTRAUKIMAS,
            UZDUOTIES_IVEDIMAS
        }

        public OSCore()
        {
            processes = new LinkedList<Process>();
            readyProcesses = new LinkedList<Process>();
            blockedProcesses = new LinkedList<Process>();
            stoppedProcesses = new LinkedList<Process>();

            resources = new LinkedList<Resource>();
            usingResources = new LinkedList<Resource>();
            freeResources = new LinkedList<Resource>();

            processManager = new ProcessManager(this);
            currentProcID = 0;
            currentResID = 0;

            machine = new VirtualRealMachine.Machine();
        }

        public Process createProcess(Process process, ProcessName processName)
        {
            Process tempProc = null;
            currentProcID++;
            int intID = currentProcID;

            switch (processName)
            {
                case ProcessName.INPUT_LINE:
                    tempProc = new Processes.InputLine(processes, intID, processName,
                        machine.cpu, this, ProcessState.READY, process, 4);                                                                                                    
                    break;
                case ProcessName.INTERRUPT:
                    tempProc = new Processes.Interrupt(processes, intID, processName,
                        machine.cpu, this, ProcessState.READY, process, 3);                                                                                                    
                    break;
                case ProcessName.JOB_GOVERNOR:
                    tempProc = new Processes.JobGovernor(processes, intID, processName,
                        machine.cpu, this, ProcessState.READY, process, 2);                                                                                                    
                    break;
                case ProcessName.JOB_INPUT:
                    tempProc = new Processes.JobInput(processes, intID, processName,
                        machine.cpu, this, ProcessState.READY, process, 6);                                                                                                    
                    break;
                case ProcessName.JOB_LOADER:
                    tempProc = new Processes.JobLoader(processes, intID, processName,
                        machine.cpu, this, ProcessState.READY, process, 6);                                                                                                    
                    break;
                case ProcessName.MAIN_PROC:
                    tempProc = new Processes.MainProc(processes, intID, processName,
                        machine.cpu, this, ProcessState.READY, process, 5);                                                                                                    
                    break;
                case ProcessName.PRINT_LINE:
                    tempProc = new Processes.PrintLine(processes, intID, processName,
                        machine.cpu, this, ProcessState.READY, process, 4);                                                                                                    
                    break;
                case ProcessName.START_STOP:
                    tempProc = new Processes.StartStop(processes, intID, processName,
                        machine.cpu, this, ProcessState.READY, process, 7);                                                                                                    
                    break;
                case ProcessName.VIRTUAL_MACHINE:
                    tempProc = new Processes.VirtualMachine(processes, intID, processName,
                        machine.cpu, this, ProcessState.READY, process, 1);                                                                                                    
                    break;
                default:
                    break;
            }

            processes.AddLast(tempProc);
            readyProcesses.AddLast(tempProc);
            processManager.execute();
            return tempProc;
        }

        public void destroyProcess(Process process)
        {
            foreach (Resource resource in process.getDescriptor().createdResList)
            {
                destroyResource(resource);
            }

            foreach (Process proc in process.getDescriptor().childrenList)
            {
                destroyProcess(proc);
            }

            processes.Remove(process);
            readyProcesses.Remove(process);
            blockedProcesses.Remove(process);
            stoppedProcesses.Remove(process);

            process.getDescriptor().parent.getDescriptor().childrenList.Remove(process);
        }

        public void stopProcess(Process process)
        {
            switch (process.getDescriptor().state)
            {
                case ProcessState.RUN:
                    readyProcesses.AddLast(process);
                    process.getDescriptor().state = ProcessState.STOPPED;
                    break;

                case ProcessState.BLOCKED:
                    blockedProcesses.Remove(process);
                    stoppedProcesses.AddLast(process);
                    process.getDescriptor().state = ProcessState.STOPPED;
                    break;
                
                case ProcessState.READY:
                    readyProcesses.Remove(process);
                    stoppedProcesses.AddLast(process);
                    process.getDescriptor().state = ProcessState.STOPPED;
                    break;
            }
            processManager.execute();
        }

        public void activateProcess(Process process)
        {
            stoppedProcesses.Remove(process);
            process.getDescriptor().state = ProcessState.READY;
            processManager.execute();
        }

        public void changeProcessPriority(Process process, int newPriority)
        {
            process.getDescriptor().priority = newPriority;
            processManager.execute();
        }

        public Resource createResource(Process process, ResourceName resourceName, Object component)
        {
            Resource tempRes = null;
            currentResID++;

            tempRes = new Resource(currentResID, resourceName, this, process, component, resources);

            resources.AddLast(tempRes);
            freeResources.AddLast(tempRes);
            resourcesManagerExecute(resourceName);
            return tempRes;
        }

        public void destroyResource(Resource resource)
        {
            resource.getDescriptor().user.getDescriptor().ownedResList.Remove(resource);
            resource.getDescriptor().user = null;
            resource.getDescriptor().creator.getDescriptor().createdResList.Remove(resource);

            resources.Remove(resource);
            freeResources.Remove(resource);
            usingResources.Remove(resource);
        }

        public void requestResource(Process process, ResourceName resourceName)
        {
            process.getDescriptor().waitingResList.AddLast(resourceName);
            resourcesManagerExecute(resourceName);
        }

        public void releaseResource(Resource resource)
        {
            resource.getDescriptor().user.getDescriptor().ownedResList.Remove(resource);
            resource.getDescriptor().user = null;

            freeResources.AddLast(resource);
            usingResources.Remove(resource);

            resourcesManagerExecute(resource.getDescriptor().externalID);
        }

        private void resourcesManagerExecute(OSCore.ResourceName name)
        {
            Resource foundResource = null;

            foreach (Resource resource in resources)
            {
                if (name == resource.getDescriptor().externalID)
                {
                    foundResource = resource;
                    break;
                }
            }

            if (foundResource != null)
            {
                foundResource.getManager().execute();                
            }
        }
    }
}
