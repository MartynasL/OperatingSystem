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
    public partial class Form1 : Form
    {
        public static Form1 Self;
        private OSCore os;

        public Form1()
        {
            InitializeComponent();
            Self = this;
            os = new OSCore();
        }

        public void writeToOutputConsole(string outputString)
        {
            outputConsole.AppendText(outputString + Environment.NewLine);
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            os.executeOSStep();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            os.createProcess(null, OSCore.ProcessName.START_STOP);
        }
    }
}
