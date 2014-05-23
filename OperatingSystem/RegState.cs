using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystem
{
    public class RegState
    {
        public char Machine;
        public VirtualRealMachine.Word A;
        public VirtualRealMachine.Word B;
        public char C;
        public VirtualRealMachine.Word PR;
        public VirtualRealMachine.Word SP;
        public VirtualRealMachine.Word IC;
        private char[] TIMER;

        public void saveState(VirtualRealMachine.CPU cpu)
        {
            this.Machine = cpu.M.getValue();
            this.A = cpu.A.getValue();
            this.B = cpu.B.getValue();
            this.C = cpu.C.getValue();
            this.PR = cpu.PR.getValue();
            this.SP = cpu.SP.getValue();
            this.IC = cpu.IC.getValue();
            this.TIMER = cpu.TIMER.getValue();
        }

        public void setState(VirtualRealMachine.CPU cpu)
        {
            cpu.M.setValue(Machine);
            cpu.A.setValue(A);
            cpu.B.setValue(B);
            cpu.C.setValue(C);
            cpu.PR.setValue(PR);
            cpu.SP.setValue(SP);
            cpu.IC.setValue(IC);
            cpu.TIMER.setValue(new string(TIMER));
        }
    }
}
