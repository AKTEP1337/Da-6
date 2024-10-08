namespace Da_6
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
            button1 = new Button();
            label1 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.MouseDownBackColor = Color.Silver;
            button1.FlatAppearance.MouseOverBackColor = Color.Silver;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("MS Reference Sans Serif", 15.75F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(176, 130);
            button1.Name = "button1";
            button1.Size = new Size(201, 39);
            button1.TabIndex = 0;
            button1.Text = "Регистрация";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS Reference Sans Serif", 17F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(30, 49);
            label1.Name = "label1";
            label1.Size = new Size(511, 28);
            label1.TabIndex = 1;
            label1.Text = "Добро пожаловать в приложение Da-6";
            label1.Click += label1_Click;
            // 
            // button3
            // 
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.FlatAppearance.BorderColor = Color.White;
            button3.FlatAppearance.MouseDownBackColor = Color.Silver;
            button3.FlatAppearance.MouseOverBackColor = Color.Silver;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("MS Reference Sans Serif", 15.75F, FontStyle.Bold);
            button3.ForeColor = SystemColors.ButtonFace;
            button3.Location = new Point(176, 193);
            button3.Name = "button3";
            button3.Size = new Size(201, 39);
            button3.TabIndex = 3;
            button3.Text = "Вход";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(580, 251);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Form1";
            Text = "Вход";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Button button3;
    }
}
