using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystem
{
    public class Process
    {
        protected ProcessDescriptor descriptor;
        protected int step;

        public Process(LinkedList<Process> processList,
                       int ID, OSCore.ProcessName externalID,
                       RegState savedState, VirtualRealMachine.CPU processor,
                       OSCore os, OSCore.ProcessState state, Process parent,
                       int priority)
        {
            this.descriptor = new ProcessDescriptor(processList, ID, externalID,
                                                    savedState, processor, os, state,
                                                    parent, priority);
            this.step = 1;

            if (parent != null)
            {
                parent.descriptor.childrenList.AddLast(this);
            }
        }

        public ProcessDescriptor getDescriptor()
        {
            return descriptor;
        }
    }
}
