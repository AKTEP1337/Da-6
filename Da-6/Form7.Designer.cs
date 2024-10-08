namespace Da_6
{
    partial class Form7
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
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(-444, 169);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(25, 30);
            label1.TabIndex = 8;
            label1.Text = "1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(12, 47);
            label2.Name = "label2";
            label2.Size = new Size(74, 24);
            label2.TabIndex = 9;
            label2.Text = "label2";
            // 
            // comboBox1
            // 
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(229, 131);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(253, 32);
            comboBox1.TabIndex = 10;
            comboBox1.UseWaitCursor = true;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(12, 139);
            label3.Name = "label3";
            label3.Size = new Size(181, 24);
            label3.TabIndex = 11;
            label3.Text = "Тип тренировки";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.CheckedBackColor = Color.Silver;
            button1.FlatAppearance.MouseDownBackColor = Color.Silver;
            button1.FlatAppearance.MouseOverBackColor = Color.Silver;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(526, 213);
            button1.Name = "button1";
            button1.Size = new Size(220, 36);
            button1.TabIndex = 12;
            button1.Text = "Продолжить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.CheckedBackColor = Color.Silver;
            button2.FlatAppearance.MouseDownBackColor = Color.Silver;
            button2.FlatAppearance.MouseOverBackColor = Color.Silver;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(12, 213);
            button2.Name = "button2";
            button2.Size = new Size(220, 36);
            button2.TabIndex = 13;
            button2.Text = "Меню";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(758, 261);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Form7";
            Text = "Результаты";
            Load += Form7_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private Button button1;
        private Button button2;
    }
}