namespace Da_6
{
    partial class Form2
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            button2 = new Button();
            label7 = new Label();
            comboBox2 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(113, 22);
            label1.Name = "label1";
            label1.Size = new Size(334, 24);
            label1.TabIndex = 2;
            label1.Text = "Введите ваши личные данные";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(12, 131);
            label2.Name = "label2";
            label2.Size = new Size(104, 24);
            label2.TabIndex = 3;
            label2.Text = "Фамилия";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(12, 79);
            label3.Name = "label3";
            label3.Size = new Size(51, 24);
            label3.TabIndex = 4;
            label3.Text = "Имя";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(12, 225);
            label4.Name = "label4";
            label4.Size = new Size(74, 24);
            label4.TabIndex = 5;
            label4.Text = "Логин";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(12, 274);
            label5.Name = "label5";
            label5.Size = new Size(88, 24);
            label5.TabIndex = 6;
            label5.Text = "Пароль";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(12, 323);
            label6.Name = "label6";
            label6.Size = new Size(205, 24);
            label6.TabIndex = 7;
            label6.Text = "Повторите пароль";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.MouseDownBackColor = Color.Silver;
            button1.FlatAppearance.MouseOverBackColor = Color.Silver;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(246, 395);
            button1.Name = "button1";
            button1.Size = new Size(275, 39);
            button1.TabIndex = 8;
            button1.Text = "Зарегистрироваться";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            textBox1.Location = new Point(246, 78);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(275, 30);
            textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            textBox2.Location = new Point(246, 123);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(275, 30);
            textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            textBox3.Location = new Point(246, 223);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(275, 30);
            textBox3.TabIndex = 11;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            textBox4.Location = new Point(246, 272);
            textBox4.Name = "textBox4";
            textBox4.PasswordChar = '*';
            textBox4.Size = new Size(275, 30);
            textBox4.TabIndex = 12;
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            textBox5.Location = new Point(246, 324);
            textBox5.Name = "textBox5";
            textBox5.PasswordChar = '*';
            textBox5.Size = new Size(275, 30);
            textBox5.TabIndex = 13;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.MouseDownBackColor = Color.Silver;
            button2.FlatAppearance.MouseOverBackColor = Color.Silver;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(12, 395);
            button2.Name = "button2";
            button2.Size = new Size(104, 39);
            button2.TabIndex = 14;
            button2.Text = "Меню";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(12, 179);
            label7.Name = "label7";
            label7.Size = new Size(51, 24);
            label7.TabIndex = 15;
            label7.Text = "Пол";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.Simple;
            comboBox2.FlatStyle = FlatStyle.Flat;
            comboBox2.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(246, 170);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(275, 32);
            comboBox2.TabIndex = 21;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(533, 446);
            Controls.Add(comboBox2);
            Controls.Add(label7);
            Controls.Add(button2);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = SystemColors.ButtonFace;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Form2";
            Text = "Регистрация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button button2;
        private Label label7;
        private ComboBox comboBox2;
    }
}