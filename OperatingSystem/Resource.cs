using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystem
{
    public class Resource
    {
        protected ResourceDescriptor descriptor;
        protected ResourcesManager manager;

        public Resource(int ID, OSCore.ResourceName externalID,
                        OSCore os, Process creator, Object component, LinkedList<Resource> resources)
        {
            this.descriptor = new ResourceDescriptor(ID, externalID, os, creator, component, resources);
            creator.getDescriptor().createdResList.AddLast(this);
            this.manager = new ResourcesManager(os, this);
        }

        public ResourceDescriptor getDescriptor()
        {
            return descriptor;
        }

        public ResourcesManager getManager()
        {
            return manager;
        }
    }
}
