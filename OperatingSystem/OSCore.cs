using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public class OSCore
    {
        public enum ProcessName
        {
            START_STOP, JOB_INPUT, JOB_LOADER, MAIN_PROC, PRINT_LINE,
            INPUT_LINE, INTERRUPT, JOB_GOVERNOR, VIRTUAL_MACHINE
        }

        public enum ProcessState
        {
            RUN, READY, BLOCKED_STOPPED, READY_STOPPED, BLOCKED
        }

        public enum ResourceName
        {
            TRECIAS_KANALAS, SUPERVIZORINE_ATMINTIS, VARTOTOJO_ATMINTIS,
            PIRMAS_KANALAS, ANTRAS_KANALAS, PABAIGA, UZDUOTIS_ISORINEJE_ATMINTYJE,
            UZDUOTIS_VARTOTOJO_ATMINTYJE, IVYKO_PERTRAUKIMAS, EILUTE_IVESTA, EILUTE_ATSPAUSDINTA,
            PRANESIMAS_PEOCESUI_INPUT_LINE, PRANESIMAS_PROCESUI_PRINT_LINE, PERTRAUKIMAS,
            UZDUOTIES_IVEDIMAS
        }

        public void createResource(Process process, ResourceName resourceName)
        {

        }

        public void createProcess(Process process, ProcessName processName)
        {

        }

        public void destroyResource(Resource resource)
        {

        }

        public void destroyProcess(Process process)
        {

        }

        public void requestResource(Process process, ResourceName resourceName)
        {

        }

        public void releaseResource(Resource resource)
        {

        }
    }
}
