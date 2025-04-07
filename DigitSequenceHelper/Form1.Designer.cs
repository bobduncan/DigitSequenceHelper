namespace DigitSequenceHelper
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
            pictureBox1 = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanelStart = new FlowLayoutPanel();
            richTextBox1 = new RichTextBox();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(33, 289);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(71, 46);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1062, 0);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanelStart
            // 
            flowLayoutPanelStart.BackColor = SystemColors.GradientActiveCaption;
            flowLayoutPanelStart.Location = new Point(0, 21);
            flowLayoutPanelStart.Name = "flowLayoutPanelStart";
            flowLayoutPanelStart.Size = new Size(946, 58);
            flowLayoutPanelStart.TabIndex = 5;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(122, 289);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(131, 48);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(954, 21);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 58);
            btnReset.TabIndex = 6;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += BtnReset_Click;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1062, 253);
            this.Controls.Add(btnReset);
            this.Controls.Add(flowLayoutPanelStart);
            this.Controls.Add(flowLayoutPanel1);
            this.Controls.Add(richTextBox1);
            this.Controls.Add(pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanelStart;
        private RichTextBox richTextBox1;
        private Button btnReset;
    }
}
