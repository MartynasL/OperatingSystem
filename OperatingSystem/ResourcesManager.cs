using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public class ResourcesManager
    {
        private OSCore os;
        private Resource resource;

        public ResourcesManager(OSCore os, Resource resource)
        {
            this.os = os;
            this.resource = resource;
        }

        public void execute()
        {
            Process highestPriorityProcess = null;
            int priority = 0;

            foreach (Process process in resource.getDescriptor().os.blockedProcesses)
            {
                foreach (OSCore.ResourceName name in process.getDescriptor().waitingResList)
                {
                    if ((name == resource.getDescriptor().externalID) && (process.getDescriptor().priority > priority))
                    {
                        if (name == OSCore.ResourceName.IVYKO_PERTRAUKIMAS || name == OSCore.ResourceName.EILUTE_ATSPAUSDINTA
                            || name == OSCore.ResourceName.EILUTE_IVESTA)
                        {
                            string machine = (string)resource.getDescriptor().component;
                            for (int i = 0; i < machine.Length; i++)
                            {
                                if (!Char.IsDigit(machine, i))
                                {
                                    machine = machine.Substring(0, i);
                                    break;
                                }
                            }
                            if (process.getDescriptor().childrenList.First.Value.getDescriptor().ID == Convert.ToInt32(machine))
                            {
                                highestPriorityProcess = process;
                                priority = process.getDescriptor().priority;
                            }
                        }
                        else
                        {
                            highestPriorityProcess = process;
                            priority = process.getDescriptor().priority;
                        }
                    }
                }
            }
            if (highestPriorityProcess != null)
            {
                highestPriorityProcess.getDescriptor().ownedResList.AddLast(resource);
                resource.getDescriptor().user = highestPriorityProcess;
                highestPriorityProcess.getDescriptor().waitingResList.Remove(resource.getDescriptor().externalID);
                os.usingResources.AddLast(resource);
                os.freeResources.Remove(resource);
                os.form.writeToOutputConsole("Process " + highestPriorityProcess.getDescriptor().externalID
                    + " gets " + resource.getDescriptor().externalID);

                if (highestPriorityProcess.getDescriptor().waitingResList.Count() == 0)
                {
                    highestPriorityProcess.getDescriptor().state = OSCore.ProcessState.READY;
                    os.blockedProcesses.Remove(highestPriorityProcess);
                    os.readyProcesses.AddLast(highestPriorityProcess);
                }
            }

            os.processManager.execute();
        }
    }
}
