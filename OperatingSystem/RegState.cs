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
        public char[] TIMER;

        public void saveState(VirtualRealMachine.CPU cpu)
        {
            this.Machine = cpu.M.getValue();
            this.A = new VirtualRealMachine.Word(cpu.A.getValue().ToString());
            this.B = new VirtualRealMachine.Word(cpu.B.getValue().ToString());
            this.C = cpu.C.getValue();
            this.PR = new VirtualRealMachine.Word(cpu.PR.getValue().ToString());
            this.SP = new VirtualRealMachine.Word(cpu.SP.getValue().ToString());
            this.IC = new VirtualRealMachine.Word(cpu.IC.getValue().ToString());
            this.TIMER = new char[2];
            this.TIMER[0] = cpu.TIMER.getValue()[0];
            this.TIMER[1] = cpu.TIMER.getValue()[1];
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

        public void setTimerSavedValue(string value)
        {
            this.TIMER[0] = value[0];
            this.TIMER[1] = value[1];
        }
    }
}
