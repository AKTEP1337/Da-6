namespace Da_6
{
    partial class Form3
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
            label3 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(12, 46);
            label3.Name = "label3";
            label3.Size = new Size(74, 24);
            label3.TabIndex = 5;
            label3.Text = "Логин";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(12, 133);
            label1.Name = "label1";
            label1.Size = new Size(88, 24);
            label1.TabIndex = 6;
            label1.Text = "Пароль";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            textBox1.Location = new Point(138, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 30);
            textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 14F);
            textBox2.Location = new Point(138, 125);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(200, 32);
            textBox2.TabIndex = 11;
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
            button2.Location = new Point(12, 215);
            button2.Name = "button2";
            button2.Size = new Size(104, 39);
            button2.TabIndex = 15;
            button2.Text = "Меню";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
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
            button1.Location = new Point(265, 215);
            button1.Name = "button1";
            button1.Size = new Size(101, 39);
            button1.TabIndex = 16;
            button1.Text = "Вход";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(378, 266);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Form3";
            Text = "Вход";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button2;
        private Button button1;
    }
}