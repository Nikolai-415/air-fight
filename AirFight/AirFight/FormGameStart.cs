using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirFight
{
    public partial class FormGameStart : Form
    {
        private int m_difficulty_id;

        public int DifficultyId
        {
            get
            {
                return m_difficulty_id;
            }
        }

        private int m_max_speed;
        public int MaxSpeed
        {
            get
            {
                return m_max_speed;
            }
        }

        private int m_healths;
        public int Healths
        {
            get
            {
                return m_healths;
            }
        }

        private int m_model_id;
        public int ModelId
        {
            get
            {
                return m_model_id;
            }
        }

        public FormGameStart()
        {
            InitializeComponent();
        }

        private void FormGameStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show(); // показываем форму главного меню
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            FormGame form_game = new FormGame(); // создаём форму, в которой отображается сама игра
            if (form_game.LoadGame()) // если загрузка из файла прошла успешно
            {
                form_game.Owner = this; // устанавливаем владельца второй формы - эту форму
                form_game.Show(); // показываем созданную форму
                this.Hide(); // скрываем текущую форму
            }
            else // если возникла ошибка при загрузке из файла
            {
                MessageBox.Show("Ошибка при загрузке сохранения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            if (radioButton_difficulty_1.Checked == true)
            {
                m_difficulty_id = 0;
            }
            else if (radioButton_difficulty_2.Checked == true)
            {
                m_difficulty_id = 1;
            }
            else
            {
                m_difficulty_id = 2;
            }
            m_max_speed = Convert.ToInt32(numericUpDown_max_speed.Value);
            m_healths = Convert.ToInt32(numericUpDown_healths.Value);
            if (radioButton_model_1.Checked == true)
            {
                m_model_id = 0;
            }
            else if (radioButton_model_2.Checked == true)
            {
                m_model_id = 1;
            }
            else if (radioButton_model_3.Checked == true)
            {
                m_model_id = 2;
            }
            else
            {
                m_model_id = 3;
            }

            FormGame form_game = new FormGame(); // создаём форму, в которой отображается сама игра
            form_game.Owner = this; // устанавливаем владельца второй формы - эту форму
            form_game.Show(); // показываем созданную форму
            this.Hide(); // скрываем текущую форму
        }
    }
}
