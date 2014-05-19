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
                        OSCore os, Process creator)
        {
            this.descriptor = new ResourceDescriptor(ID, externalID, os, creator);
        }

        public ResourceDescriptor getDescriptor()
        {
            return descriptor;
        }
    }
}
