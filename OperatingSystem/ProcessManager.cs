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

        internal void execute()
        {
            throw new NotImplementedException();
        }
    }
}
