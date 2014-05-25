using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperatingSystem
{
    public partial class InputForm : Form
    {
        VirtualRealMachine.InputDevice inputDevice;

        public InputForm()
        {
            InitializeComponent();
        }

        private void inputButton_Click(object sender, EventArgs e)
        {
            VirtualRealMachine.MemoryBlock memoryBlock = new VirtualRealMachine.MemoryBlock();
            int i = 0;
            foreach (string line in textBox1.Lines)
            {
                memoryBlock.setBlockWord(i % 9, new VirtualRealMachine.Word(line));
                i++;
                if (i % 9 == 0)
                {
                    inputDevice.enqueueInput(memoryBlock);
                }
            }
            while(i < 99)
            {
                memoryBlock.setBlockWord(i % 9, new VirtualRealMachine.Word("0000"));
                i++;
                if (i % 9 == 0)
                {
                    inputDevice.enqueueInput(memoryBlock);
                }
            }
            this.Close();
        }

        public void setInputDevice(VirtualRealMachine.InputDevice inputDevice)
        {
            this.inputDevice = inputDevice;
        }
    }
}
