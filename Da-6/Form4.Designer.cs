namespace Da_6
{
    partial class Form4
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
            comboBox1 = new ComboBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.Simple;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            comboBox1.ForeColor = SystemColors.ActiveCaptionText;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(295, 42);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(249, 32);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(9, 42);
            label3.Name = "label3";
            label3.Size = new Size(267, 24);
            label3.TabIndex = 5;
            label3.Text = "Выбери тип тренировки";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.MouseDownBackColor = Color.Silver;
            button1.FlatAppearance.MouseOverBackColor = Color.Silver;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(12, 265);
            button1.Name = "button1";
            button1.Size = new Size(141, 39);
            button1.TabIndex = 9;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaptionText;
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.MouseDownBackColor = Color.Silver;
            button2.FlatAppearance.MouseOverBackColor = Color.Silver;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(354, 265);
            button2.Name = "button2";
            button2.Size = new Size(190, 39);
            button2.TabIndex = 10;
            button2.Text = "Составить план";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(9, 92);
            label1.Name = "label1";
            label1.Size = new Size(56, 24);
            label1.TabIndex = 11;
            label1.Text = "Рост";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(9, 147);
            label2.Name = "label2";
            label2.Size = new Size(47, 24);
            label2.TabIndex = 12;
            label2.Text = "Вес";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            textBox1.Location = new Point(295, 92);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(174, 30);
            textBox1.TabIndex = 14;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            textBox2.Location = new Point(295, 139);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(174, 30);
            textBox2.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(12, 200);
            label4.Name = "label4";
            label4.Size = new Size(59, 24);
            label4.TabIndex = 21;
            label4.Text = "Дата";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 14F);
            dateTimePicker1.CalendarForeColor = SystemColors.ButtonFace;
            dateTimePicker1.Font = new Font("MS Reference Sans Serif", 14F, FontStyle.Bold);
            dateTimePicker1.Location = new Point(295, 194);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(240, 30);
            dateTimePicker1.TabIndex = 22;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(556, 319);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Form4";
            Text = "Введите ваши данные";
            Load += Form4_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label3;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label4;
        private DateTimePicker dateTimePicker1;
    }
}