namespace Da_6
{
    partial class Form5
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label5 = new Label();
            button1 = new Button();
            label6 = new Label();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(12, 63);
            label1.Name = "label1";
            label1.Size = new Size(56, 24);
            label1.TabIndex = 8;
            label1.Text = "Рост";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(12, 120);
            label2.Name = "label2";
            label2.Size = new Size(47, 24);
            label2.TabIndex = 9;
            label2.Text = "Вес";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(12, 177);
            label3.Name = "label3";
            label3.Size = new Size(276, 24);
            label3.TabIndex = 10;
            label3.Text = "Количество тренировок:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(316, 177);
            label4.Name = "label4";
            label4.Size = new Size(23, 24);
            label4.TabIndex = 11;
            label4.Text = "0";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            textBox1.Location = new Point(158, 63);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(174, 30);
            textBox1.TabIndex = 12;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            textBox2.Location = new Point(158, 120);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(174, 30);
            textBox2.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(41, 9);
            label5.Name = "label5";
            label5.Size = new Size(385, 24);
            label5.TabIndex = 14;
            label5.Text = "Введите ваши текущие показатели";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.MouseDownBackColor = Color.Silver;
            button1.FlatAppearance.MouseOverBackColor = Color.Silver;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(107, 317);
            button1.Name = "button1";
            button1.Size = new Size(234, 39);
            button1.TabIndex = 15;
            button1.Text = "Далее";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(12, 223);
            label6.Name = "label6";
            label6.Size = new Size(59, 24);
            label6.TabIndex = 16;
            label6.Text = "Дата";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            dateTimePicker1.Font = new Font("Segoe UI", 16F);
            dateTimePicker1.Location = new Point(119, 223);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(222, 36);
            dateTimePicker1.TabIndex = 24;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(456, 363);
            Controls.Add(dateTimePicker1);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Form5";
            Text = "Результаты";
            Load += Form5_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label5;
        private Button button1;
        private Label label6;
        private DateTimePicker dateTimePicker1;
    }
}