using System;
using System.Drawing;
using System.Windows.Forms;

namespace AirFight
{
    /// <summary>Направление движения</summary>
    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right,
        None,
    }

    /// <summary>Самолёт</summary>
    [Serializable]
    public class Airplane
    {
        /// <summary>Шаг перемещения при движении</summary>
        const int step_move = 5;

        /// <summary>Максимальная скорость самолёта</summary>
        public int max_speed;

        /// <summary>Интервал между выстрелами (в миллисекундах)</summary>
        const int shoot_interval = 500;

        /// <summary>Форма, в которой отображается игра</summary>
        [NonSerialized]
        FormGame m_form_game;

        /// <summary>Форма, в которой отображается игра</summary>
        public FormGame FormGame {
            set {
                m_form_game = value;
            }
        }

        /// <summary>Игрок ли (если не игрок, то самолёт - противника)</summary>
        bool m_is_player;

        /// <summary>ID модели самолёта (для игрока: 0, для противников: 3-6)</summary>
        int m_model_id;

        /// <summary>Жизни самолёта</summary>
        int m_health;

        /// <summary>Жизни самолёта</summary>
        public int Health
        {
            get
            {
                return m_health;
            }
            set
            {
                m_health = value;
                if (m_health <= 0)
                {
                    m_is_destroyed = true;
                }
            }
        }

        /// <summary>Текущее изображение самолёта</summary>
        Bitmap m_image;

        /// <summary>Текущая позиция самолёта на форме (центр самолёта)</summary>
        Point m_location;

        /// <summary>Текущая позиция самолёта на форме (центр самолёта)</summary>
        public Point Location
        {
            get
            {
                return m_location;
            }
            set
            {
                m_location = value;
            }
        }

        /// <summary>Скорость самолёта</summary>
        int m_speed;

        /// <summary>Скорость самолёта</summary>
        public int Speed
        {
            get
            {
                return m_speed;
            }
        }

        /// <summary>Уничтожен ли самолёт</summary>
        bool m_is_destroyed;

        /// <summary>Уничтожен ли самолёт</summary>
        public bool IsDestroyed
        {
            get
            {
                return m_is_destroyed;
            }
        }

        /// <summary>Таймер стрельбы</summary>
        [NonSerialized]
        Timer m_timer_shoot;

        /// <summary>Может ли самолёт стрелять</summary>
        bool m_can_shoot;

        /// <summary>Создаёт самолёт</summary>
        /// <param name="form_game">Форма, в которой отображается самолёт</param>
        /// <param name="is_player">Игрок ли (если не игрок, то самолёт - противника)</param>
        /// <param name="model_id">ID модели (для игрока: 0, для противников: 3-6)</param>
        /// <param name="health">Количество жизней</param>
        public Airplane(FormGame form_game, bool is_player = false, int model_id = 0, int health = 3)
        {
            m_form_game = form_game;
            m_is_player = is_player;
            m_model_id = model_id;
            m_health = health;

            if (m_is_player)
            {
                if (m_model_id < 0 || m_model_id > 3) // проверка на правильность введённого ID
                {
                    m_model_id = 0;
                }
                if (m_model_id == 0)
                {
                    m_image = Properties.Resources.airplane_right_1_forward; // игрок
                }
                else if (m_model_id == 1)
                {
                    m_image = Properties.Resources.airplane_right_2_forward; // игрок
                }
                else if (m_model_id == 2)
                {
                    m_image = Properties.Resources.airplane_right_3_forward; // игрок
                }
                else if (m_model_id == 3)
                {
                    m_image = Properties.Resources.airplane_right_4_forward; // игрок
                }
                m_location = new Point(m_image.Width / 2, form_game.ClientSize.Height / 2);
            }
            else
            {
                if (m_model_id < 4 || m_model_id > 6) // проверка на правильность введённого ID
                {
                    m_model_id = 4;
                }
                if (m_model_id == 4)
                {
                    m_image = Properties.Resources.airplane_left_1_forward; // противник
                }
                else if (m_model_id == 5)
                {
                    m_image = Properties.Resources.airplane_left_2_forward; // противник
                }
                else if (m_model_id == 6)
                {
                    m_image = Properties.Resources.airplane_left_3_forward; // противник
                }
                Random random = new Random(); // переменная для генерации случайных чисел
                m_location = new Point(form_game.ClientSize.Width + m_image.Width / 2, random.Next(m_image.Height / 2, form_game.ClientSize.Height - m_image.Height / 2)); // устанавливаем позицию самолёта противника - за правым краем формы, на случайной высоте
            }

            m_is_destroyed = false;

            m_speed = 10; // скорость самолёта - для противников не меняется

            m_timer_shoot = new Timer();
            m_timer_shoot.Tick += timer_shoot_Tick;
            m_timer_shoot.Interval = shoot_interval;
            m_can_shoot = true;
        }

        /// <summary>Рисует самолёт</summary>
        public void Paint(PaintEventArgs e)
        {
            if (!m_is_destroyed) // если самолёт не уничтожен
            {
                Point location = new Point(m_location.X - m_image.Width / 2, m_location.Y - m_image.Height / 2); // позиция прямоугольника
                Rectangle rectangle = new Rectangle(location, m_image.Size); // прямоугольник
                e.Graphics.DrawImage(m_image, rectangle); // рисуем изображение в прямоугольнике
            }
        }

        /// <summary>Передвигает самолёт в заданном направлении</summary>
        /// <param name="move_direction">Направление движения</param>
        public void Move(MoveDirection move_direction)
        {
            if (!m_is_destroyed) // если самолёт не уничтожен
            {
                int new_location_x = m_location.X;
                int new_location_y = m_location.Y;

                if (move_direction == MoveDirection.Left) // движение влево
                {
                    new_location_x -= step_move;
                }

                if (m_is_player) // если игрок
                {
                    if (move_direction == MoveDirection.Up) // движение вверх
                    {
                        new_location_y -= step_move;

                        // обновление изображения самолёта
                        if (m_model_id == 0)
                        {
                            m_image = Properties.Resources.airplane_right_1_up; // игрок
                        }
                        else if (m_model_id == 1)
                        {
                            m_image = Properties.Resources.airplane_right_2_up; // игрок
                        }
                        else if (m_model_id == 2)
                        {
                            m_image = Properties.Resources.airplane_right_3_up; // игрок
                        }
                        else if (m_model_id == 3)
                        {
                            m_image = Properties.Resources.airplane_right_4_up; // игрок
                        }
                    }
                    else if (move_direction == MoveDirection.Down) // движение вниз
                    {
                        new_location_y += step_move;

                        // обновление изображения самолёта
                        if (m_model_id == 0)
                        {
                            m_image = Properties.Resources.airplane_right_1_down; // игрок
                        }
                        else if (m_model_id == 1)
                        {
                            m_image = Properties.Resources.airplane_right_2_down; // игрок
                        }
                        else if (m_model_id == 2)
                        {
                            m_image = Properties.Resources.airplane_right_3_down; // игрок
                        }
                        else if (m_model_id == 3)
                        {
                            m_image = Properties.Resources.airplane_right_4_down; // игрок
                        }
                    }
                    else
                    {
                        if (move_direction == MoveDirection.Right) // движение вправо
                        {
                            new_location_x += step_move;
                        }

                        // обновление изображения самолёта
                        if (m_model_id == 0)
                        {
                            m_image = Properties.Resources.airplane_right_1_forward; // игрок
                        }
                        else if (m_model_id == 1)
                        {
                            m_image = Properties.Resources.airplane_right_2_forward; // игрок
                        }
                        else if (m_model_id == 2)
                        {
                            m_image = Properties.Resources.airplane_right_3_forward; // игрок
                        }
                        else if (m_model_id == 3)
                        {
                            m_image = Properties.Resources.airplane_right_4_forward; // игрок
                        }
                    }

                    if (new_location_x - m_image.Width / 2 < 0) // проверка на выход за левый край поля
                    {
                        new_location_x = m_image.Width / 2;
                    }
                    if (new_location_x + m_image.Width / 2 > m_form_game.ClientSize.Width) // проверка на выход за правый край поля
                    {
                        new_location_x = m_form_game.ClientSize.Width - m_image.Width / 2;
                    }
                    if (new_location_y - m_image.Height / 2 < 0) // проверка на выход за верхний край поля
                    {
                        new_location_y = m_image.Height / 2;
                    }
                    if (new_location_y + m_image.Height / 2 > m_form_game.ClientSize.Height) // проверка на выход за нижний край поля
                    {
                        new_location_y = m_form_game.ClientSize.Height - m_image.Height / 2;
                    }
                }
                else // если противник - выйти может только за левый край формы
                {
                    if (new_location_x + m_image.Width < 0) // проверка на выход за левый край поля
                    {
                        m_is_destroyed = true; // уничтожаем самолёт противника
                    }
                }

                m_location = new Point(new_location_x, new_location_y); // устанавливаем новую позицию самолёта

                if (m_is_player) // если игрок
                {
                    m_speed = (int)(max_speed * ((m_location.X / ((double)m_form_game.Width / 2)) / step_move)); // меняем скорость самолёта в зависимости от положения на форме - чем правее, тем быстрее
                }
            }
        }

        /// <summary>Произодит выстрел пули из самолёта</summary>
        /// <param name="procent_success_shoot">Вероятность успешного выстрела в процентах</param>
        public void Shoot(int procent_success_shoot = 100)
        {
            if (!m_is_destroyed) // если самолёт не уничтожен
            {
                if (m_can_shoot) // если самолёт может стрелять
                {
                    m_can_shoot = false;
                    m_timer_shoot.Start(); // запускаем таймер стрельбы - интервал между выстрелами
                    Random random = new Random();
                    if (random.Next(0, 100) <= procent_success_shoot) // проверяем вероятность успешного выстрела
                    {
                        m_form_game.CreateBullet(m_location, m_is_player); // создаём пулю на форме
                    }
                }
            }
        }

        /// <summary>Событие таймера стрельбы</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_shoot_Tick(object sender, EventArgs e)
        {
            m_timer_shoot.Stop(); // останавливаем таймер стрельбы
            m_can_shoot = true;
        }
    }
}
