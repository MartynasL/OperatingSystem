using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public class ResourceDescriptor
    {
        public int ID;
        public OSCore.ResourceName externalID;
        public LinkedList<Process> processes;
        public OSCore os;
        public Process creator;
        public LinkedList<Resource> resources;
        public Object component;
        public Process user;

        public ResourceDescriptor(int ID, OSCore.ResourceName externalID,
                                  OSCore os, Process creator, Object component, LinkedList<Resource> resources)
        {
            this.ID = ID;
            this.externalID = externalID;
            this.os = os;
            this.creator = creator;
            this.component = component;
            this.resources = resources;

            processes = new LinkedList<Process>();
            user = null;
        }
    }
}
