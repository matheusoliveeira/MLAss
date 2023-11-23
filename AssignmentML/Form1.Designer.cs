namespace AssignmentML
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
            textBoxFeedback = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            comboBox1 = new ComboBox();
            lblguess = new Label();
            lblconfidence = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            SuspendLayout();
            // 
            // textBoxFeedback
            // 
            textBoxFeedback.Location = new Point(121, 44);
            textBoxFeedback.Name = "textBoxFeedback";
            textBoxFeedback.Size = new Size(603, 23);
            textBoxFeedback.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(121, 89);
            button1.Name = "button1";
            button1.Size = new Size(105, 41);
            button1.TabIndex = 1;
            button1.Text = "Predict";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(121, 263);
            button2.Name = "button2";
            button2.Size = new Size(105, 41);
            button2.TabIndex = 2;
            button2.Text = "Re-Train";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(121, 320);
            button3.Name = "button3";
            button3.Size = new Size(105, 41);
            button3.TabIndex = 3;
            button3.Text = "Compare Models";
            button3.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.DisplayMember = "0,1";
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "0", "1" });
            comboBox1.Location = new Point(121, 222);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(105, 23);
            comboBox1.TabIndex = 4;
            // 
            // lblguess
            // 
            lblguess.BorderStyle = BorderStyle.FixedSingle;
            lblguess.Location = new Point(624, 101);
            lblguess.Name = "lblguess";
            lblguess.Size = new Size(100, 23);
            lblguess.TabIndex = 5;
            // 
            // lblconfidence
            // 
            lblconfidence.BorderStyle = BorderStyle.FixedSingle;
            lblconfidence.Location = new Point(624, 145);
            lblconfidence.Name = "lblconfidence";
            lblconfidence.Size = new Size(100, 23);
            lblconfidence.TabIndex = 6;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(624, 263);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 7;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Location = new Point(624, 298);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 8;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Location = new Point(624, 332);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(41, 47);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 10;
            label6.Text = "Feedback:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(513, 102);
            label7.Name = "label7";
            label7.Size = new Size(41, 15);
            label7.TabIndex = 11;
            label7.Text = "Guess:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(513, 146);
            label8.Name = "label8";
            label8.Size = new Size(71, 15);
            label8.TabIndex = 12;
            label8.Text = "Confidence:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(513, 264);
            label9.Name = "label9";
            label9.Size = new Size(98, 15);
            label9.TabIndex = 13;
            label9.Text = "Original Weights:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(513, 299);
            label10.Name = "label10";
            label10.Size = new Size(110, 15);
            label10.TabIndex = 14;
            label10.Text = "Re Trained Weights:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(513, 333);
            label11.Name = "label11";
            label11.Size = new Size(75, 15);
            label11.TabIndex = 15;
            label11.Text = "Weight Diffs:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblconfidence);
            Controls.Add(lblguess);
            Controls.Add(comboBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBoxFeedback);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFeedback;
        private Button button1;
        private Button button2;
        private Button button3;
        private ComboBox comboBox1;
        private Label lblguess;
        private Label lblconfidence;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
    }
}