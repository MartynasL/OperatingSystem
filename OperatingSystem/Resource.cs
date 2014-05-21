using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystem
{
    public class Resource
    {
        protected ResourceDescriptor descriptor;

        public Resource(int ID, OSCore.ResourceName externalID,
                        OSCore os, Process creator, Object component, LinkedList<Resource> resources)
        {
            this.descriptor = new ResourceDescriptor(ID, externalID, os, creator, component, resources);
            creator.getDescriptor().createdResList.AddLast(this);
        }

        public ResourceDescriptor getDescriptor()
        {
            return descriptor;
        }
    }
}
