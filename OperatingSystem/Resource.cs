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
                        OSCore os, Process creator, Object component)
        {
            this.descriptor = new ResourceDescriptor(ID, externalID, os, creator, component);
        }

        public ResourceDescriptor getDescriptor()
        {
            return descriptor;
        }
    }
}
