using System;
using System.Drawing;
using System.Windows.Forms;

namespace AirFight
{
    /// <summary>Форма, в которой отображаются результаты игры</summary>
    public partial class FormGameEnd : Form
    {
        /// <summary>Победил ли игрок</summary>
        public bool IsWin;

        /// <summary>Конструктор формы</summary>
        public FormGameEnd()
        {
            InitializeComponent();
        }

        /// <summary>Событие загрузки формы</summary>
        private void FormGameEnd_Load(object sender, EventArgs e)
        {
            if (IsWin)
            {
                BackColor = Color.LightGreen;
                label_result.Text = "Вы победили!";
            }
            else
            {
                BackColor = Color.OrangeRed;
                label_result.Text = "Вы проиграли!";
            }
        }

        /// <summary>Событие закрытия формы</summary>
        private void FormGameEnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show(); // показываем форму главного меню
        }

        /// <summary>Событие нажатия на кнопку "Играть ещё раз"</summary>
        private void button_play_Click(object sender, EventArgs e)
        {
            FormGameStart form_game_start = new FormGameStart(); // создаём форму, в которой отображается начало игры
            form_game_start.Owner = this.Owner; // устанавливаем владельца второй формы
            form_game_start.Show(); // показываем созданную форму
            this.Hide(); // скрываем текущую форму
        }

        /// <summary>Событие нажатия на кнопку "Выйти в меню"</summary>
        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
