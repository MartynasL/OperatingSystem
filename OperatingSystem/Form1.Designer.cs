namespace OperatingSystem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outputConsole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.stepButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.currentProcessText = new System.Windows.Forms.TextBox();
            this.currentStepBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // outputConsole
            // 
            this.outputConsole.Location = new System.Drawing.Point(196, 12);
            this.outputConsole.Multiline = true;
            this.outputConsole.Name = "outputConsole";
            this.outputConsole.ReadOnly = true;
            this.outputConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputConsole.Size = new System.Drawing.Size(463, 226);
            this.outputConsole.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Console";
            // 
            // stepButton
            // 
            this.stepButton.Enabled = false;
            this.stepButton.Location = new System.Drawing.Point(12, 35);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(75, 23);
            this.stepButton.TabIndex = 2;
            this.stepButton.Text = "Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 9);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // currentProcessText
            // 
            this.currentProcessText.Location = new System.Drawing.Point(12, 85);
            this.currentProcessText.Name = "currentProcessText";
            this.currentProcessText.ReadOnly = true;
            this.currentProcessText.Size = new System.Drawing.Size(178, 20);
            this.currentProcessText.TabIndex = 4;
            // 
            // currentStepBox
            // 
            this.currentStepBox.Location = new System.Drawing.Point(167, 111);
            this.currentStepBox.Name = "currentStepBox";
            this.currentStepBox.ReadOnly = true;
            this.currentStepBox.Size = new System.Drawing.Size(23, 20);
            this.currentStepBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Current Process";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Current Step";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(40, 278);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(218, 148);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(280, 278);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(239, 148);
            this.listView2.TabIndex = 9;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Free resources";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Used resources";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 438);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentStepBox);
            this.Controls.Add(this.currentProcessText);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputConsole);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(687, 476);
            this.MinimumSize = new System.Drawing.Size(687, 476);
            this.Name = "Form1";
            this.Text = "Operating System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox outputConsole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox currentProcessText;
        private System.Windows.Forms.TextBox currentStepBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

