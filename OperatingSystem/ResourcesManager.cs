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
                        highestPriorityProcess = process;
                        priority = process.getDescriptor().priority;
                    }
                }
            }
            if (highestPriorityProcess != null)
            {
                highestPriorityProcess.getDescriptor().ownedResList.AddLast(resource);
                highestPriorityProcess.getDescriptor().waitingResList.Remove(resource.getDescriptor().externalID);
                os.usingResources.AddLast(resource);
                os.freeResources.Remove(resource);

                if (highestPriorityProcess.prepared)
                {
                    highestPriorityProcess.getDescriptor().state = OSCore.ProcessState.READY;
                    os.blockedProcesses.Remove(highestPriorityProcess);
                    os.readyProcesses.AddLast(highestPriorityProcess);
                }
            }
        }
    }
}
