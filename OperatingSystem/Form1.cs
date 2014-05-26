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
            initializeLists();
        }

        public void writeToOutputConsole(string outputString)
        {
            outputConsole.AppendText(outputString + Environment.NewLine);
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            os.executeOSStep();
            refreshProcessText();
            updateLists();
        }

        private void refreshProcessText()
        {
            if (os.curProcess != null)
            {
            currentProcessText.Text = "" + os.curProcess.getDescriptor().externalID;
            currentStepBox.Text = "" + os.curProcess.getStep();
        }
            else
            {
                currentProcessText.Text = "";
                currentStepBox.Text = "";
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            os.createProcess(null, OSCore.ProcessName.START_STOP);
            stepButton.Enabled = true;
            startButton.Enabled = false;
            refreshProcessText();
        }

        public void disableStep()
        {
            stepButton.Enabled = false;
        }

        public void enableStart()
        {
            startButton.Enabled = true;
        }

        public void showInputForm(VirtualRealMachine.InputDevice inputDevice)
        {
            InputForm form = new InputForm();
            form.setInputDevice(inputDevice);
            form.ShowDialog();
        }

        public void getOutput()
        {
            string outputString = "";
            VirtualRealMachine.MemoryBlock outputBlock = os.machine.outputDevice.getOutput();

            for (int i = 0; i < 10; i++)
            {
                outputString += outputBlock.getBlockWord(i).ToString();
            }

            MessageBox.Show(outputString, "Output", MessageBoxButtons.OK);
        }

        public void getInput()
        {
            string inputString = Microsoft.VisualBasic.Interaction.
                                    InputBox("Enter the input", "Input");
            VirtualRealMachine.MemoryBlock inputBlock = new VirtualRealMachine.MemoryBlock();
            string tempWordString = "";

            for (int i = 0; i < 40; i = i + 4)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (inputString.Length > i + j)
                    {
                        tempWordString += inputString[i + j];
                    }
                    else
                    {
                        tempWordString += "0";
                    }
                }

                inputBlock.setBlockWord(i / 4, new VirtualRealMachine.Word(tempWordString));
                tempWordString = "";
            }

            os.machine.inputDevice.enqueueInput(inputBlock);
        }

        private void initializeLists()
        {
            listView1.View = View.SmallIcon;
            listView2.View = View.SmallIcon;

            listView1.Columns.Add("Resource name");
            listView2.Columns.Add("Resource name");

            updateLists();
        }

        private void updateLists()
        {
            listView1.Items.Clear();
            listView2.Items.Clear();

            foreach (Resource resource in os.freeResources)
            {
                listView1.Items.Add(new ListViewItem(resource.getDescriptor().externalID.ToString()));
            }

            foreach (Resource resource in os.usingResources)
            {
                listView2.Items.Add(new ListViewItem(resource.getDescriptor().externalID.ToString()));
            }
        }
    }
}
