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
            if (os.curProcess != null)
            {
                if (os.curProcess.getDescriptor().state != OSCore.ProcessState.BLOCKED &&
                    !os.readyProcesses.Contains(os.curProcess) &&
                    os.curProcess.getDescriptor().state != OSCore.ProcessState.STOPPED)
                //{
                //    os.readyProcesses.Remove(os.curProcess);
                //    os.blockedProcesses.AddLast(os.curProcess);
                //}
                //else
                {
                    os.curProcess.getDescriptor().state = OSCore.ProcessState.READY;
                    os.stoppedProcesses.Remove(os.curProcess);
                    os.readyProcesses.AddLast(os.curProcess);
                }
            }

            os.curProcess = getHighestPriorityReadyProcess();
            os.readyProcesses.Remove(os.curProcess);
            os.curProcess.getDescriptor().state = OSCore.ProcessState.RUN;
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
