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
            UsoCpu.Location = new Point(292, 43);
            UsoCpu.Name = "UsoCpu";
            UsoCpu.Size = new Size(138, 32);
            UsoCpu.TabIndex = 4;
            UsoCpu.Text = "Uso da CPU";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "GPU", "CPU", "Disco" });
            checkedListBox1.Location = new Point(510, 105);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(120, 94);
            checkedListBox1.TabIndex = 5;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
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
    }
}
