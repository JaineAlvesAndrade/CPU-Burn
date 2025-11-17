namespace CpuBurn
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            trackerUso = new TrackBar();
            percentualUso = new Label();
            Timer = new System.Windows.Forms.Timer(components);
            UsoCpu = new Label();
            checkedListBox1 = new CheckedListBox();
            label1 = new Label();
            label2 = new Label();
            labelGpu = new Label();
            labelCpu = new Label();
            ((System.ComponentModel.ISupportInitialize)trackerUso).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(315, 163);
            button1.Name = "button1";
            button1.Size = new Size(141, 77);
            button1.TabIndex = 0;
            button1.Text = "Começar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // trackerUso
            // 
            trackerUso.Location = new Point(131, 316);
            trackerUso.Maximum = 100;
            trackerUso.Name = "trackerUso";
            trackerUso.Size = new Size(517, 56);
            trackerUso.TabIndex = 1;
            trackerUso.Scroll += trackBar1_Scroll;
            // 
            // percentualUso
            // 
            percentualUso.AutoSize = true;
            percentualUso.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            percentualUso.Location = new Point(368, 279);
            percentualUso.Name = "percentualUso";
            percentualUso.Size = new Size(26, 31);
            percentualUso.TabIndex = 3;
            percentualUso.Text = "0";
            // 
            // Timer
            // 
            Timer.Tick += Timer_Tick;
            // 
            // UsoCpu
            // 
            UsoCpu.AutoSize = true;
            UsoCpu.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UsoCpu.Location = new Point(284, 47);
            UsoCpu.Name = "UsoCpu";
            UsoCpu.Size = new Size(172, 41);
            UsoCpu.TabIndex = 4;
            UsoCpu.Text = "LET'S BURN";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "GPU", "CPU" });
            checkedListBox1.Location = new Point(62, 152);
            checkedListBox1.Margin = new Padding(3, 4, 3, 4);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(137, 114);
            checkedListBox1.TabIndex = 5;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 128);
            label1.Name = "label1";
            label1.Size = new Size(261, 20);
            label1.TabIndex = 6;
            label1.Text = "Selecione o que você deseja estressar:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(515, 128);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 7;
            label2.Text = "Usos:";
            label2.Click += label2_Click;
            // 
            // labelGpu
            // 
            labelGpu.AutoSize = true;
            labelGpu.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelGpu.Location = new Point(515, 152);
            labelGpu.Name = "labelGpu";
            labelGpu.Size = new Size(40, 20);
            labelGpu.TabIndex = 8;
            labelGpu.Text = "GPU:";
            // 
            // labelCpu
            // 
            labelCpu.AutoSize = true;
            labelCpu.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCpu.Location = new Point(515, 172);
            labelCpu.Name = "labelCpu";
            labelCpu.Size = new Size(39, 20);
            labelCpu.TabIndex = 9;
            labelCpu.Text = "CPU:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(labelCpu);
            Controls.Add(labelGpu);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkedListBox1);
            Controls.Add(UsoCpu);
            Controls.Add(percentualUso);
            Controls.Add(trackerUso);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)trackerUso).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TrackBar trackerUso;
        private Label percentualUso;
        private System.Windows.Forms.Timer Timer;
        private Label UsoCpu;
        private CheckedListBox checkedListBox1;
        private Label label1;
        private Label label2;
        private Label labelGpu;
        private Label labelCpu;
    }
}
