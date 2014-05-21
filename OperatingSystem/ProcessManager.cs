using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public class ProcessManager
    {
        private OSCore os;

        public ProcessManager(OSCore os)
        {
            this.os = os;
        }

        public void execute()
        {
            if (os.curProcess.getDescriptor().state == OSCore.ProcessState.BLOCKED)
            {
                os.blockedProcesses.AddLast(os.curProcess);
            }
            else
            {
                os.curProcess.getDescriptor().state = OSCore.ProcessState.READY;
                os.readyProcesses.AddLast(os.curProcess);
            }

            os.curProcess = getHighestPriorityReadyProcess();
        }

        private Process getHighestPriorityReadyProcess()
        {
            Process tempProc = null;
            int highestPriority = 0;

            foreach (Process process in os.readyProcesses)
            {
                if (process.getDescriptor().priority > highestPriority)
                {
                    tempProc = process;
                    highestPriority = process.getDescriptor().priority;
                }
            }

            return tempProc;
        }
    }
}
