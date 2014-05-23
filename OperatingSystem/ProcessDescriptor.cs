using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public class ProcessDescriptor
    {
        public LinkedList<Process> processList;
        public int ID;
        public OSCore.ProcessName externalID;
        public RegState savedState;
        public VirtualRealMachine.CPU processor;
        public OSCore os;
        public LinkedList<Resource> createdResList;
        public LinkedList<Resource> ownedResList;
        public LinkedList<OSCore.ResourceName> waitingResList;
        public OSCore.ProcessState state;
        public Process parent;
        public LinkedList<Process> childrenList;
        public int priority;

        public ProcessDescriptor(LinkedList<Process> processList,
                                 int ID, OSCore.ProcessName externalID,
                                 VirtualRealMachine.CPU processor,
                                 OSCore os, OSCore.ProcessState state, Process parent,
                                 int priority)
        {
            this.processList = processList;
            this.ID = ID;
            this.savedState = new RegState();
            this.externalID = externalID;
            this.processor = processor;
            this.os = os;
            this.state = state;
            this.parent = parent;
            this.priority = priority;

            childrenList = new LinkedList<Process>();
            createdResList = new LinkedList<Resource>();
            ownedResList = new LinkedList<Resource>();
            waitingResList = new LinkedList<OSCore.ResourceName>();
        }
    }
}
