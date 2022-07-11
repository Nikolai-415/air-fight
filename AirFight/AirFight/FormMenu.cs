using System;
using System.Drawing;
using System.Windows.Forms;

namespace AirFight
{
    /// <summary>Форма, в которой отображается главное меню</summary>
    public partial class FormMenu : Form
    {
        public string Nick;

        /// <summary>Конструктор формы</summary>
        public FormMenu()
        {
            InitializeComponent();
        }

        /// <summary>Событие загрузки формы</summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Refresh(); // вызываем перерисовку формы
        }

        /// <summary>Событие закрытия формы</summary>
        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show(); // показываем форму авторизации
        }

        /// <summary>Событие перерисовки формы</summary>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Random random = new Random(); // переменная для генерации случайных чисел

            // генерация изображений облаков на фоне
            int clouds_number = random.Next(20, 50); // количество облаков - случайно
            for (int i = 0; i < clouds_number; i++)
            {
                Bitmap image = new Bitmap(Properties.Resources.cloud); // картинка
                int scale_procent = random.Next(20, 80); // процент - будущий размер прямоугольника
                Size size = new Size(image.Width * scale_procent / 100, image.Height * scale_procent / 100); // размер прямоугольника
                Point location = new Point(random.Next(-size.Width, this.Width), random.Next(-size.Height, this.Height)); // позиция прямоугольника
                Rectangle rectangle = new Rectangle(location, size); // создаём прямоугольник
                e.Graphics.DrawImage(image, rectangle); // рисуем картинку в прямоугольнике
            }

            // заголовок
            Rectangle text_rectangle = new Rectangle(0, 0, this.Width, 200); // прямоугольник
            StringFormat format = new StringFormat(); // формат текста
            format.Alignment = StringAlignment.Center; // устанавливаем горизонтальное выравнивание текста по центру
            format.LineAlignment = StringAlignment.Center; // устанавливаем вертикальное выравнивание текста по центру
            e.Graphics.DrawString("Воздушный бой", new Font("Microsoft Sans Serif", (float)(text_rectangle.Height * 0.2), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.Black, text_rectangle, format); // рисуем текст в прямоугольнике
        }

        /// <summary>Событие нажатия на кнопку "Играть"</summary>
        private void button_play_Click(object sender, EventArgs e)
        {
            FormGameStart form_game_start = new FormGameStart(); // создаём форму, в которой отображается начало игры
            form_game_start.Owner = this; // устанавливаем владельца второй формы - эту форму
            form_game_start.Show(); // показываем созданную форму
            this.Hide(); // скрываем текущую форму
        }

        /// <summary>Событие нажатия на кнопку "Рекорды"</summary>
        private void button_records_Click(object sender, EventArgs e)
        {
            FormRecords form_records = new FormRecords(); // создаём форму, в которой отображаются рекорды
            form_records.Owner = this; // устанавливаем владельца второй формы - эту форму
            form_records.Show(); // показываем созданную форму
            this.Hide(); // скрываем текущую форму
        }

        /// <summary>Событие нажатия на кнопку "Выйти из аккаунта"</summary>
        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
