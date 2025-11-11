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
            ((System.ComponentModel.ISupportInitialize)trackerUso).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(316, 163);
            button1.Name = "button1";
            button1.Size = new Size(141, 78);
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
            trackerUso.Size = new Size(516, 56);
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
            UsoCpu.Location = new Point(334, 57);
            UsoCpu.Name = "UsoCpu";
            UsoCpu.Size = new Size(176, 41);
            UsoCpu.TabIndex = 4;
            UsoCpu.Text = "Uso da CPU";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
