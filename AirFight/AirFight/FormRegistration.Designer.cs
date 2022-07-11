namespace AirFight
{
    partial class FormRegistration
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
            this.button_register = new System.Windows.Forms.Button();
            this.button_authorization = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.label_password = new System.Windows.Forms.Label();
            this.label_nick = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_nick = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_register
            // 
            this.button_register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_register.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_register.Location = new System.Drawing.Point(35, 234);
            this.button_register.Name = "button_register";
            this.button_register.Size = new System.Drawing.Size(415, 61);
            this.button_register.TabIndex = 12;
            this.button_register.Text = "Зарегистрироваться";
            this.button_register.UseVisualStyleBackColor = false;
            this.button_register.Click += new System.EventHandler(this.button_register_Click);
            // 
            // button_authorization
            // 
            this.button_authorization.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_authorization.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_authorization.Location = new System.Drawing.Point(35, 311);
            this.button_authorization.Name = "button_authorization";
            this.button_authorization.Size = new System.Drawing.Size(415, 61);
            this.button_authorization.TabIndex = 11;
            this.button_authorization.Text = "Авторизация";
            this.button_authorization.UseVisualStyleBackColor = false;
            this.button_authorization.Click += new System.EventHandler(this.button_authorization_Click);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Location = new System.Drawing.Point(35, 388);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(415, 61);
            this.button_exit.TabIndex = 10;
            this.button_exit.Text = "Выйти из игры";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_password.Location = new System.Drawing.Point(31, 127);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(88, 24);
            this.label_password.TabIndex = 23;
            this.label_password.Text = "Пароль:";
            // 
            // label_nick
            // 
            this.label_nick.AutoSize = true;
            this.label_nick.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_nick.Location = new System.Drawing.Point(31, 34);
            this.label_nick.Name = "label_nick";
            this.label_nick.Size = new System.Drawing.Size(52, 24);
            this.label_nick.TabIndex = 22;
            this.label_nick.Text = "Ник:";
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_password.Location = new System.Drawing.Point(35, 154);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(415, 29);
            this.textBox_password.TabIndex = 21;
            // 
            // textBox_nick
            // 
            this.textBox_nick.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_nick.Location = new System.Drawing.Point(35, 61);
            this.textBox_nick.Name = "textBox_nick";
            this.textBox_nick.Size = new System.Drawing.Size(415, 29);
            this.textBox_nick.TabIndex = 20;
            // 
            // FormRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_nick);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_nick);
            this.Controls.Add(this.button_register);
            this.Controls.Add(this.button_authorization);
            this.Controls.Add(this.button_exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRegistration_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_register;
        private System.Windows.Forms.Button button_authorization;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_nick;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_nick;
    }
}