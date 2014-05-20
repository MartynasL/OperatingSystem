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
        public LinkedList<ResourceElements> elements;
        public LinkedList<Process> processes;
        public OSCore os;
        public Process creator;
        public LinkedList<Resource> resources;
        public Object component;

        public ResourceDescriptor(int ID, OSCore.ResourceName externalID,
                                  OSCore os, Process creator, Object component)
        {
            this.ID = ID;
            this.externalID = externalID;
            this.os = os;
            this.creator = creator;
            this.component = component;

            processes = new LinkedList<Process>();
            resources = new LinkedList<Resource>();
        }
    }
}
