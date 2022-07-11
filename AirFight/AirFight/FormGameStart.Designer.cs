namespace AirFight
{
    partial class FormGameStart
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
            this.button_back = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.button_play = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_difficulty_1 = new System.Windows.Forms.RadioButton();
            this.radioButton_difficulty_2 = new System.Windows.Forms.RadioButton();
            this.radioButton_difficulty_3 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_model_2 = new System.Windows.Forms.RadioButton();
            this.radioButton_model_3 = new System.Windows.Forms.RadioButton();
            this.radioButton_model_4 = new System.Windows.Forms.RadioButton();
            this.radioButton_model_1 = new System.Windows.Forms.RadioButton();
            this.numericUpDown_max_speed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_healths = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_max_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_healths)).BeginInit();
            this.SuspendLayout();
            // 
            // button_back
            // 
            this.button_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_back.Location = new System.Drawing.Point(28, 385);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(290, 61);
            this.button_back.TabIndex = 5;
            this.button_back.Text = "Назад";
            this.button_back.UseVisualStyleBackColor = false;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_load
            // 
            this.button_load.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_load.Location = new System.Drawing.Point(348, 385);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(290, 61);
            this.button_load.TabIndex = 6;
            this.button_load.Text = "Загрузить";
            this.button_load.UseVisualStyleBackColor = false;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_play
            // 
            this.button_play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_play.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_play.Location = new System.Drawing.Point(668, 385);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(290, 61);
            this.button_play.TabIndex = 7;
            this.button_play.Text = "Играть";
            this.button_play.UseVisualStyleBackColor = false;
            this.button_play.Click += new System.EventHandler(this.button_play_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_difficulty_3);
            this.groupBox1.Controls.Add(this.radioButton_difficulty_2);
            this.groupBox1.Controls.Add(this.radioButton_difficulty_1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(28, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 150);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Уровень сложности:";
            // 
            // radioButton_difficulty_1
            // 
            this.radioButton_difficulty_1.AutoSize = true;
            this.radioButton_difficulty_1.Checked = true;
            this.radioButton_difficulty_1.Location = new System.Drawing.Point(22, 39);
            this.radioButton_difficulty_1.Name = "radioButton_difficulty_1";
            this.radioButton_difficulty_1.Size = new System.Drawing.Size(85, 28);
            this.radioButton_difficulty_1.TabIndex = 0;
            this.radioButton_difficulty_1.TabStop = true;
            this.radioButton_difficulty_1.Text = "Легко";
            this.radioButton_difficulty_1.UseVisualStyleBackColor = true;
            // 
            // radioButton_difficulty_2
            // 
            this.radioButton_difficulty_2.AutoSize = true;
            this.radioButton_difficulty_2.Location = new System.Drawing.Point(22, 73);
            this.radioButton_difficulty_2.Name = "radioButton_difficulty_2";
            this.radioButton_difficulty_2.Size = new System.Drawing.Size(138, 28);
            this.radioButton_difficulty_2.TabIndex = 1;
            this.radioButton_difficulty_2.Text = "Нормально";
            this.radioButton_difficulty_2.UseVisualStyleBackColor = true;
            // 
            // radioButton_difficulty_3
            // 
            this.radioButton_difficulty_3.AutoSize = true;
            this.radioButton_difficulty_3.Location = new System.Drawing.Point(22, 107);
            this.radioButton_difficulty_3.Name = "radioButton_difficulty_3";
            this.radioButton_difficulty_3.Size = new System.Drawing.Size(104, 28);
            this.radioButton_difficulty_3.TabIndex = 2;
            this.radioButton_difficulty_3.Text = "Сложно";
            this.radioButton_difficulty_3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_model_4);
            this.groupBox2.Controls.Add(this.radioButton_model_3);
            this.groupBox2.Controls.Add(this.radioButton_model_2);
            this.groupBox2.Controls.Add(this.radioButton_model_1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(28, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(930, 169);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Модель самолёта:";
            // 
            // radioButton_model_2
            // 
            this.radioButton_model_2.AutoSize = true;
            this.radioButton_model_2.Image = global::AirFight.Properties.Resources.airplane_right_2_forward;
            this.radioButton_model_2.Location = new System.Drawing.Point(256, 39);
            this.radioButton_model_2.Name = "radioButton_model_2";
            this.radioButton_model_2.Size = new System.Drawing.Size(214, 100);
            this.radioButton_model_2.TabIndex = 1;
            this.radioButton_model_2.UseVisualStyleBackColor = true;
            // 
            // radioButton_model_3
            // 
            this.radioButton_model_3.AutoSize = true;
            this.radioButton_model_3.Image = global::AirFight.Properties.Resources.airplane_right_3_forward;
            this.radioButton_model_3.Location = new System.Drawing.Point(476, 39);
            this.radioButton_model_3.Name = "radioButton_model_3";
            this.radioButton_model_3.Size = new System.Drawing.Size(214, 100);
            this.radioButton_model_3.TabIndex = 2;
            this.radioButton_model_3.UseVisualStyleBackColor = true;
            // 
            // radioButton_model_4
            // 
            this.radioButton_model_4.AutoSize = true;
            this.radioButton_model_4.Image = global::AirFight.Properties.Resources.airplane_right_4_forward;
            this.radioButton_model_4.Location = new System.Drawing.Point(696, 39);
            this.radioButton_model_4.Name = "radioButton_model_4";
            this.radioButton_model_4.Size = new System.Drawing.Size(214, 100);
            this.radioButton_model_4.TabIndex = 3;
            this.radioButton_model_4.UseVisualStyleBackColor = true;
            // 
            // radioButton_model_1
            // 
            this.radioButton_model_1.AutoSize = true;
            this.radioButton_model_1.Checked = true;
            this.radioButton_model_1.Image = global::AirFight.Properties.Resources.airplane_right_1_forward;
            this.radioButton_model_1.Location = new System.Drawing.Point(22, 39);
            this.radioButton_model_1.Name = "radioButton_model_1";
            this.radioButton_model_1.Size = new System.Drawing.Size(214, 100);
            this.radioButton_model_1.TabIndex = 0;
            this.radioButton_model_1.TabStop = true;
            this.radioButton_model_1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_max_speed
            // 
            this.numericUpDown_max_speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_max_speed.Location = new System.Drawing.Point(739, 72);
            this.numericUpDown_max_speed.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown_max_speed.Name = "numericUpDown_max_speed";
            this.numericUpDown_max_speed.Size = new System.Drawing.Size(120, 29);
            this.numericUpDown_max_speed.TabIndex = 10;
            this.numericUpDown_max_speed.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(378, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Максимальная скорость самолёта:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(462, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Количество жизней:";
            // 
            // numericUpDown_healths
            // 
            this.numericUpDown_healths.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_healths.Location = new System.Drawing.Point(681, 138);
            this.numericUpDown_healths.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_healths.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_healths.Name = "numericUpDown_healths";
            this.numericUpDown_healths.Size = new System.Drawing.Size(120, 29);
            this.numericUpDown_healths.TabIndex = 12;
            this.numericUpDown_healths.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // FormGameStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_healths);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_max_speed);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_play);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.button_back);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormGameStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки игры";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGameStart_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_max_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_healths)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_play;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_difficulty_3;
        private System.Windows.Forms.RadioButton radioButton_difficulty_2;
        private System.Windows.Forms.RadioButton radioButton_difficulty_1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton_model_4;
        private System.Windows.Forms.RadioButton radioButton_model_3;
        private System.Windows.Forms.RadioButton radioButton_model_2;
        private System.Windows.Forms.RadioButton radioButton_model_1;
        private System.Windows.Forms.NumericUpDown numericUpDown_max_speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_healths;
    }
}