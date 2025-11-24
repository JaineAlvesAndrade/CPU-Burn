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
            _coresSelection = new CheckedListBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackerUso).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(276, 122);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(123, 58);
            button1.TabIndex = 0;
            button1.Text = "Começar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // trackerUso
            // 
            trackerUso.Location = new Point(115, 237);
            trackerUso.Margin = new Padding(3, 2, 3, 2);
            trackerUso.Maximum = 100;
            trackerUso.Name = "trackerUso";
            trackerUso.Size = new Size(452, 45);
            trackerUso.TabIndex = 1;
            trackerUso.Scroll += trackBar1_Scroll;
            // 
            // percentualUso
            // 
            percentualUso.AutoSize = true;
            percentualUso.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            percentualUso.Location = new Point(322, 209);
            percentualUso.Name = "percentualUso";
            percentualUso.Size = new Size(22, 25);
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
            UsoCpu.Location = new Point(248, 35);
            UsoCpu.Name = "UsoCpu";
            UsoCpu.Size = new Size(138, 32);
            UsoCpu.TabIndex = 4;
            UsoCpu.Text = "LET'S BURN";
            UsoCpu.Click += UsoCpu_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "GPU", "CPU" });
            checkedListBox1.Location = new Point(54, 140);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(120, 40);
            checkedListBox1.TabIndex = 5;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(54, 106);
            label1.Name = "label1";
            label1.Size = new Size(180, 32);
            label1.TabIndex = 6;
            label1.Text = "Selecione o que você deseja estressar:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(465, 117);
            label2.Name = "label2";
            label2.Size = new Size(47, 21);
            label2.TabIndex = 7;
            label2.Text = "Usos:";
            label2.Click += label2_Click;
            // 
            // labelGpu
            // 
            labelGpu.AutoSize = true;
            labelGpu.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelGpu.Location = new Point(465, 140);
            labelGpu.Name = "labelGpu";
            labelGpu.Size = new Size(33, 15);
            labelGpu.TabIndex = 8;
            labelGpu.Text = "GPU:";
            // 
            // labelCpu
            // 
            labelCpu.AutoSize = true;
            labelCpu.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCpu.Location = new Point(465, 155);
            labelCpu.Name = "labelCpu";
            labelCpu.Size = new Size(33, 15);
            labelCpu.TabIndex = 9;
            labelCpu.Text = "CPU:";
            // 
            // _coresSelection
            // 
            _coresSelection.FormattingEnabled = true;
            _coresSelection.Location = new Point(54, 326);
            _coresSelection.Margin = new Padding(3, 2, 3, 2);
            _coresSelection.Name = "_coresSelection";
            _coresSelection.Size = new Size(232, 76);
            _coresSelection.TabIndex = 10;
            _coresSelection.SelectedIndexChanged += checkedListBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Location = new Point(55, 290);
            label3.Name = "label3";
            label3.Size = new Size(230, 31);
            label3.TabIndex = 11;
            label3.Text = "Selecione os núcleos da CPU a serem estressados:";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 438);
            Controls.Add(label3);
            Controls.Add(_coresSelection);
            Controls.Add(labelCpu);
            Controls.Add(labelGpu);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkedListBox1);
            Controls.Add(UsoCpu);
            Controls.Add(percentualUso);
            Controls.Add(trackerUso);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
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
        private CheckedListBox _coresSelection;
        private Label label3;
    }
}
