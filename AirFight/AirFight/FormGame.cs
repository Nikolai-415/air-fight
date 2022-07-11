using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AirFight
{
    /// <summary>Форма, в которой отображается игра</summary>
    public partial class FormGame : Form
    {
        /// <summary>Ник игрока</summary>
        private string m_nick;

        /// <summary>ID выбранной сложности</summary>
        private int m_difficulty_id;

        /// <summary>Выбранная максимальная скорость</summary>
        private int m_max_speed;

        /// <summary>Выбранное количество жизней</summary>
        private int m_healths;

        /// <summary>ID выбранной модели самолёта</summary>
        private int m_model_id;

        /// <summary>Нужное количество очков для победы</summary>
        int need_experience;

        /// <summary>Нужное расстояния для появления облака</summary>
        const int need_milleage_for_cloud = 200;

        /// <summary>Нужное расстояния для появления монетки</summary>
        const int need_milleage_for_coin = 3000;

        /// <summary>Нужное расстояния для появления противника</summary>
        int need_milleage_for_enemy;

        /// <summary>Нужное расстояния для получения очков</summary>
        const int need_milleage_for_experience = 500;

        /// <summary>Процент - вероятность успешного выстрела противника</summary>
        int procent_enemy_shoot = 20;

        /// <summary>Скорость пули</summary>
        const int bullet_speed = 15;

        /// <summary>Очки</summary>
        int m_experience;

        /// <summary>Пройденное расстояние</summary>
        int m_milleage;

        /// <summary>Расстояние, на котором было создано последнее облако</summary>
        int m_milleage_last_cloud;

        /// <summary>Расстояние, на котором была создана последняя монетка</summary>
        int m_milleage_last_coin;

        /// <summary>Расстояние, на котором был создан последний противник</summary>
        int m_milleage_last_enemy;

        /// <summary>Расстояние, на котором были добавлены последние очки</summary>
        int m_milleage_last_experience;

        /// <summary>Победил ли игрок</summary>
        bool m_is_win;

        /// <summary>Изображение пули игрока</summary>
        Bitmap m_image_bullet_player;

        /// <summary>Изображение пули противника</summary>
        Bitmap m_image_bullet_enemy;

        /// <summary>Изображение облака</summary>
        Bitmap m_image_cloud;

        /// <summary>Изображение монетки</summary>
        Bitmap m_image_coin;

        /// <summary>Список нажатых клавиш</summary>
        List<Keys> m_keys_pressed;

        /// <summary>Список выпущенных пуль игрока</summary>
        List<Rectangle> m_bullets_player;

        /// <summary>Список скоростей выпущенных пуль игрока</summary>
        List<int> m_bullets_speeds_player;

        /// <summary>Список выпущенных пуль противников</summary>
        List<Rectangle> m_bullets_enemies;

        /// <summary>Список скоростей выпущенных пуль противников</summary>
        List<int> m_bullets_speeds_enemies;

        /// <summary>Список облаков на поле</summary>
        List<Rectangle> m_clouds;

        /// <summary>Список монет на поле</summary>
        List<Rectangle> m_coins;

        /// <summary>Список противников на поле</summary>
        List<Airplane> m_enemies;

        /// <summary>Самолёт игрока</summary>
        Airplane m_player_airplane;

        /// <summary>Форма настроек игры (предыдущая форма)</summary>
        FormGameStart m_form_game_start;

        /// <summary>Было ли загружено сохранение (иначе - была создана новая игра)</summary>
        bool m_is_load = false;

        /// <summary>Прошедшее время с начала игры</summary>
        int m_time;

        /// <summary>Конструктор формы</summary>
        public FormGame()
        {
            InitializeComponent();
        }

        /// <summary>Событие загрузки формы</summary>
        private void FormGame_Load(object sender, EventArgs e)
        {
            m_form_game_start = (FormGameStart)(this.Owner); // предыдущая форма

            m_nick = ((FormMenu)m_form_game_start.Owner).Nick; // загружаем ник игрока из предыдущей формы

            // загружаем картинки из ресурсов проекта
            m_image_bullet_player = Properties.Resources.bullet_right;
            m_image_bullet_enemy = Properties.Resources.bullet_left;
            m_image_cloud = Properties.Resources.cloud;
            m_image_coin = Properties.Resources.coin;

            m_keys_pressed = new List<Keys>(); // очищаем список нажатых клавиш

            m_is_win = false;

            if (!m_is_load) // если игра была начата с начала
            {
                // загружаем значения настроек из предыдущей формы
                m_difficulty_id = m_form_game_start.DifficultyId;
                m_max_speed = m_form_game_start.MaxSpeed;
                m_healths = m_form_game_start.Healths;
                m_model_id = m_form_game_start.ModelId;

                if (m_difficulty_id == 0) // сложность - легко
                {
                    need_experience = 100;
                    need_milleage_for_enemy = 500;
                    procent_enemy_shoot = 20;
                }
                else if (m_difficulty_id == 1) // сложность - нормально
                {
                    need_experience = 200;
                    need_milleage_for_enemy = 400;
                    procent_enemy_shoot = 40;
                }
                else // сложность - сложно
                {
                    need_experience = 300;
                    need_milleage_for_enemy = 300;
                    procent_enemy_shoot = 60;
                }

                // обнуляем переменные
                m_experience = 0;
                m_milleage = 0;
                m_milleage_last_cloud = 0;
                m_milleage_last_coin = 0;
                m_milleage_last_enemy = 0;
                m_milleage_last_experience = 0;

                // создаём списки
                m_bullets_player = new List<Rectangle>();
                m_bullets_speeds_player = new List<int>();
                m_bullets_enemies = new List<Rectangle>();
                m_bullets_speeds_enemies = new List<int>();
                m_clouds = new List<Rectangle>();
                m_coins = new List<Rectangle>();
                m_enemies = new List<Airplane>();

                m_player_airplane = new Airplane(this, true, m_model_id, m_healths);
                m_player_airplane.max_speed = m_max_speed;
            }

            m_time = 0;
            timer_refresh.Start(); // запускаем таймер отрисовки формы
        }

        /// <summary>Событие закрытия формы</summary>
        private void FormGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer_refresh.Stop(); // останавливаем таймер отрисовки формы

            FormGameEnd form_game_end = new FormGameEnd(); // создаём форму, в которой отображается результат
            form_game_end.Owner = m_form_game_start.Owner; // устанавливаем владельца второй формы
            form_game_end.IsWin = m_is_win; // передаём в созданную форму значение переменной m_is_win - выиграл ли игрок
            form_game_end.Show(); // показываем созданную форму
        }

        /// <summary>Событие изменения размера формы</summary>
        private void FormGame_SizeChanged(object sender, EventArgs e)
        {
            button_save.Location = new Point(ClientSize.Width - 10 - button_save.Width, ClientSize.Height - 10 - button_save.Height);
        }

        /// <summary>Событие нажатия клавиши</summary>
        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (m_keys_pressed.IndexOf(e.KeyCode) == -1) // если клавиши нет в списке нажатых
            {
                m_keys_pressed.Add(e.KeyCode); // добавляем клавишу в список нажатых
            }
        }

        /// <summary>Событие поднятия клавиши</summary>
        private void FormGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (m_keys_pressed.IndexOf(e.KeyCode) != -1) // если клавиши есть в списке нажатых
            {
                m_keys_pressed.Remove(e.KeyCode); // удаляем клавишу из списка нажатых
            }
        }

        /// <summary>Событие прорисовки формы</summary>
        private void FormGame_Paint(object sender, PaintEventArgs e)
        {
            // рисуем облака
            for (int i = 0; i < m_clouds.Count; i++)
            {
                e.Graphics.DrawImage(m_image_cloud, m_clouds[i]);
            }

            // рисуем монеты
            for (int i = 0; i < m_coins.Count; i++)
            {
                e.Graphics.DrawImage(m_image_coin, m_coins[i]);
            }

            // рисуем пули
            for (int i = 0; i < m_bullets_player.Count; i++) // пули игрока
            {
                e.Graphics.DrawImage(m_image_bullet_player, m_bullets_player[i]);
            }
            for (int i = 0; i < m_bullets_enemies.Count; i++) // пули противников
            {
                e.Graphics.DrawImage(m_image_bullet_enemy, m_bullets_enemies[i]);
            }

            // рисуем вражеские самолёты
            for (int i = 0; i < m_enemies.Count; i++)
            {
                m_enemies[i].Paint(e);
            }

            // рисуем самолёт игрока
            m_player_airplane.Paint(e);

            // рисуем количество жизней игрока
            for (int i = 0; i < m_player_airplane.Health; i++)
            {
                Bitmap image = Properties.Resources.heart;
                Point location = new Point(10 + (image.Width + 10) * i, 10);
                Rectangle rectangle = new Rectangle(location, image.Size);
                e.Graphics.DrawImage(image, rectangle);
            }

            // очки
            Rectangle text_rectangle = new Rectangle(ClientSize.Width - 510, 10, 500, 50); // прямоугольник
            StringFormat format = new StringFormat(); // формат текста
            format.Alignment = StringAlignment.Far; // устанавливаем горизонтальное выравнивание текста по правому краю
            format.LineAlignment = StringAlignment.Center; // устанавливаем вертикальное выравнивание текста по центру
            e.Graphics.DrawString("Очки: " + m_experience.ToString() + "/" + need_experience.ToString(), new Font("Microsoft Sans Serif", (float)(text_rectangle.Height * 0.6), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.Black, text_rectangle, format); // рисуем текст в прямоугольнике

            // пройденное расстояние
            Rectangle text_rectangle2 = new Rectangle(10, ClientSize.Height - 60, ClientSize.Width - 20, 50); // прямоугольник
            e.Graphics.DrawString("Пройденное расстояние: " + m_milleage.ToString(), new Font("Microsoft Sans Serif", (float)(text_rectangle2.Height * 0.6), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.Black, text_rectangle2); // рисуем текст в прямоугольнике
        }

        /// <summary>Событие таймера</summary>
        private void timer_refresh_Tick(object sender, EventArgs e)
        {
            m_time += timer_refresh.Interval;

            if (m_experience >= need_experience) // если набрано необходимое количество очков
            {
                m_is_win = true; // игрок победил
                EndGame();
            }

            Random random = new Random(); // переменная для генерации случайных чисел

            bool is_player_moving = false; // совершил ли игрок движение

            if (m_keys_pressed.IndexOf(Keys.A) != -1 || m_keys_pressed.IndexOf(Keys.Left) != -1) // движение игрока влево
            {
                m_player_airplane.Move(MoveDirection.Left);
                is_player_moving = true;
            }
            else if (m_keys_pressed.IndexOf(Keys.D) != -1 || m_keys_pressed.IndexOf(Keys.Right) != -1) // движение игрока вправо
            {
                m_player_airplane.Move(MoveDirection.Right);
                is_player_moving = true;
            }

            if (m_keys_pressed.IndexOf(Keys.W) != -1 || m_keys_pressed.IndexOf(Keys.Up) != -1) // движение игрока вверх
            {
                m_player_airplane.Move(MoveDirection.Up);
                is_player_moving = true;
            }
            else if (m_keys_pressed.IndexOf(Keys.S) != -1 || m_keys_pressed.IndexOf(Keys.Down) != -1) // движение игрока вниз
            {
                m_player_airplane.Move(MoveDirection.Down);
                is_player_moving = true;
            }

            if (!is_player_moving) // если игрок не двигался
            {
                m_player_airplane.Move(MoveDirection.None);
            }

            if (m_keys_pressed.IndexOf(Keys.Space) != -1) // стрельба игрока
            {
                m_player_airplane.Shoot();
            }

            m_milleage += m_player_airplane.Speed; // увеличиваем пройденное расстояние

            // если пройдено нужное расстояние - создаём облако
            if (m_milleage - m_milleage_last_cloud > need_milleage_for_cloud)
            {
                m_milleage_last_cloud = m_milleage;
                int scale_procent = random.Next(20, 80); // процент - будущий размер прямоугольника
                Size size = new Size(m_image_cloud.Width * scale_procent / 100, m_image_cloud.Height * scale_procent / 100); // размер прямоугольника
                Point location = new Point(this.ClientSize.Width + m_image_cloud.Width, random.Next(-m_image_cloud.Height, this.ClientSize.Height)); // позиция прямоугольника
                Rectangle rectangle = new Rectangle(location, size); // создаём прямоугольник
                m_clouds.Add(rectangle);
            }

            // передвигаем все облака
            for (int i = 0; i < m_clouds.Count; i++)
            {
                Point new_location = new Point(m_clouds[i].X - m_player_airplane.Speed, m_clouds[i].Y);
                m_clouds[i] = new Rectangle(new_location, m_clouds[i].Size);
                if (new_location.X + m_image_cloud.Width < 0)
                {
                    m_clouds.Remove(m_clouds[i]);
                }
            }

            // если пройдено нужное расстояние - создаём монетку
            if (m_milleage - m_milleage_last_coin > need_milleage_for_coin)
            {
                m_milleage_last_coin = m_milleage;
                Point location = new Point(this.ClientSize.Width + m_image_coin.Width, random.Next(0, this.ClientSize.Height - m_image_coin.Height)); // позиция прямоугольника
                Rectangle rectangle = new Rectangle(location, m_image_coin.Size); // создаём прямоугольник
                m_coins.Add(rectangle);
            }

            // передвигаем и проверяем все монетки на подбирание игроком
            Size airplane_size = new Size(180, 50);
            Point player_airplane_location = new Point(m_player_airplane.Location.X - airplane_size.Width / 2, m_player_airplane.Location.Y - airplane_size.Height / 2);
            Rectangle player_airplane_rectangle = new Rectangle(player_airplane_location, airplane_size);
            for (int i = 0; i < m_coins.Count; i++)
            {
                if (player_airplane_rectangle.IntersectsWith(m_coins[i]))
                {
                    m_experience += 10;
                    m_coins.Remove(m_coins[i]);
                }
                else
                {
                    Point new_location = new Point(m_coins[i].X - m_player_airplane.Speed, m_coins[i].Y);
                    m_coins[i] = new Rectangle(new_location, m_coins[i].Size);
                    if (new_location.X + m_image_coin.Width < 0)
                    {
                        m_coins.Remove(m_coins[i]);
                    }
                }
            }

            // если пройдено нужное расстояние - создаём противника
            if (m_milleage - m_milleage_last_enemy > need_milleage_for_enemy)
            {
                m_milleage_last_enemy = m_milleage;
                Airplane enemy = new Airplane(this, false, random.Next(4, 7));
                m_enemies.Add(enemy);
            }

            // передвигаем всех противников, а также проверяем все пули игрока на попадание в противников
            for (int i = 0; i < m_enemies.Count; i++)
            {
                Point enemy_airplane_location = new Point(m_enemies[i].Location.X - airplane_size.Width / 2, m_enemies[i].Location.Y - airplane_size.Height / 2);
                Rectangle enemy_airplane_rectangle = new Rectangle(enemy_airplane_location, airplane_size);

                if (player_airplane_rectangle.IntersectsWith(enemy_airplane_rectangle) && !m_player_airplane.IsDestroyed) // если игрок столкнулся с противником
                {
                    EndGame();
                }
                else // если игрок не столкнулся с противником
                {
                    m_enemies[i].Location = new Point(m_enemies[i].Location.X - m_player_airplane.Speed, m_enemies[i].Location.Y); // передвигаем противника в зависимости от скорости игрока
                    m_enemies[i].Shoot(procent_enemy_shoot); // стрельба противника с установленной пероятностью
                    m_enemies[i].Move(MoveDirection.Left); // движение самого противника
                }

                // проверяем все пули игрока
                for (int i2 = 0; i2 < m_bullets_player.Count; i2++)
                {
                    if (enemy_airplane_rectangle.IntersectsWith(m_bullets_player[i2]) && !m_enemies[i].IsDestroyed) // если пуля столкнулась с противником
                    {
                        m_enemies[i].Health--; // уменьшаем количество жизней противника
                        RemoveBullet(m_bullets_player[i2]); // уничтожаем пулю
                        if (m_enemies[i].IsDestroyed) // если противник был уничтожен
                        {
                            m_experience += 20; // даём опыт игроку
                        }
                    }
                }

                if (m_enemies[i].IsDestroyed) // если противник был уничтожен
                {
                    m_enemies.Remove(m_enemies[i]); // удаляем противника из списка противников на поле
                }
            }

            // если пройдено нужное расстояние - добавляем очки
            if (m_milleage - m_milleage_last_experience > need_milleage_for_experience)
            {
                m_milleage_last_experience = m_milleage;
                m_experience++;
            }

            // передвигаем все пули игрока
            for (int i = 0; i < m_bullets_player.Count; i++)
            {
                Point new_location = new Point(m_bullets_player[i].X - m_player_airplane.Speed + m_bullets_speeds_player[i], m_bullets_player[i].Y);
                m_bullets_player[i] = new Rectangle(new_location, m_bullets_player[i].Size);

                if (new_location.X > ClientSize.Width) // если пуля вышла за правый край формы
                {
                    RemoveBullet(m_bullets_player[i]); // уничтожаем пулю
                }
            }

            // передвигаем и проверяем все пули противника на попадание в игрока
            for (int i = 0; i < m_bullets_enemies.Count; i++)
            {
                Point new_location = new Point(m_bullets_enemies[i].X - m_player_airplane.Speed - m_bullets_speeds_enemies[i], m_bullets_enemies[i].Y);
                m_bullets_enemies[i] = new Rectangle(new_location, m_bullets_enemies[i].Size);

                if (player_airplane_rectangle.IntersectsWith(m_bullets_enemies[i]) && !m_player_airplane.IsDestroyed)
                {
                    m_player_airplane.Health--; // уменьшаем количество жизней игрока
                    RemoveBullet(m_bullets_enemies[i]); // уничтожаем пулю
                    if (m_player_airplane.IsDestroyed) // если самолёт игрока был уничтожен
                    {
                        EndGame(); // завершаем игру
                    }
                }
                else if (new_location.X + m_image_bullet_enemy.Width < 0) // если пуля вышла за левый край формы
                {
                    RemoveBullet(m_bullets_enemies[i]); // уничтожаем пулю
                }
            }

            this.Refresh(); // вызываем перерисовку формы
        }

        /// <summary>Создаёт пулю</summary>
        /// <param name="location">Начальная позиция пули</param>
        /// <param name="is_player">Выпустил ли игрок пулю (если нет - выпустил противник)</param>
        public void CreateBullet(Point location, bool is_player)
        {
            Rectangle bullet; // прямоугольник
            if (is_player) // если пулю выпустил игрок
            {
                bullet = new Rectangle(location, m_image_bullet_player.Size);
                m_bullets_player.Add(bullet);
                m_bullets_speeds_player.Add(bullet_speed + m_player_airplane.Speed);
            }
            else
            {
                bullet = new Rectangle(location, m_image_bullet_enemy.Size);
                m_bullets_enemies.Add(bullet);
                m_bullets_speeds_enemies.Add(bullet_speed + m_player_airplane.Speed);
            }
        }

        /// <summary>Удаляет пулю с поля</summary>
        /// <param name="bullet">Пуля</param>
        private void RemoveBullet(Rectangle bullet)
        {
            int i = m_bullets_player.IndexOf(bullet);
            if (i != -1)
            {
                m_bullets_player.RemoveAt(i);
                m_bullets_speeds_player.RemoveAt(i);
            }
            else
            {
                i = m_bullets_enemies.IndexOf(bullet);
                m_bullets_enemies.RemoveAt(i);
                m_bullets_speeds_enemies.RemoveAt(i);
            }
        }

        /// <summary>Завершает игру</summary>
        public void EndGame()
        {
            SaveRecord();
            this.Close();
        }

        /// <summary>Событие нажатия на кнопку "Сохранить"</summary>
        private void button_save_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter(); // создаем объект BinaryFormatter
            using (FileStream fs = new FileStream("save.bin", FileMode.OpenOrCreate)) // получаем поток, куда будем записывать сериализованные объекты
            {
                formatter.Serialize(fs, m_difficulty_id);
                formatter.Serialize(fs, m_max_speed);
                formatter.Serialize(fs, m_healths);
                formatter.Serialize(fs, m_model_id);
                formatter.Serialize(fs, need_experience);
                formatter.Serialize(fs, need_milleage_for_enemy);
                formatter.Serialize(fs, m_experience);
                formatter.Serialize(fs, m_milleage);
                formatter.Serialize(fs, m_milleage_last_cloud);
                formatter.Serialize(fs, m_milleage_last_coin);
                formatter.Serialize(fs, m_milleage_last_enemy);
                formatter.Serialize(fs, m_milleage_last_experience);
                formatter.Serialize(fs, m_bullets_player);
                formatter.Serialize(fs, m_bullets_speeds_player);
                formatter.Serialize(fs, m_bullets_enemies);
                formatter.Serialize(fs, m_bullets_speeds_enemies);
                formatter.Serialize(fs, m_clouds);
                formatter.Serialize(fs, m_coins);
                formatter.Serialize(fs, m_enemies);
                formatter.Serialize(fs, m_player_airplane);
                formatter.Serialize(fs, m_time);
            }
        }

        /// <summary>Загружает сохранение из файла</summary>
        /// <returns>Возвращает true в случае успешной загрузки, false - в случае ошибки</returns>
        public bool LoadGame()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter(); // создаем объект BinaryFormatter
                using (FileStream fs = new FileStream("save.bin", FileMode.Open)) // получаем поток, откуда будем считывать сериализованные объекты
                {
                    m_difficulty_id = (int)formatter.Deserialize(fs);
                    m_max_speed = (int)formatter.Deserialize(fs);
                    m_healths = (int)formatter.Deserialize(fs);
                    m_model_id = (int)formatter.Deserialize(fs);
                    need_experience = (int)formatter.Deserialize(fs);
                    need_milleage_for_enemy = (int)formatter.Deserialize(fs);
                    m_experience = (int)formatter.Deserialize(fs);
                    m_milleage = (int)formatter.Deserialize(fs);
                    m_milleage_last_cloud = (int)formatter.Deserialize(fs);
                    m_milleage_last_coin = (int)formatter.Deserialize(fs);
                    m_milleage_last_enemy = (int)formatter.Deserialize(fs);
                    m_milleage_last_experience = (int)formatter.Deserialize(fs);
                    m_bullets_player = (List<Rectangle>)formatter.Deserialize(fs);
                    m_bullets_speeds_player = (List<int>)formatter.Deserialize(fs);
                    m_bullets_enemies = (List<Rectangle>)formatter.Deserialize(fs);
                    m_bullets_speeds_enemies = (List<int>)formatter.Deserialize(fs);
                    m_clouds = (List<Rectangle>)formatter.Deserialize(fs);
                    m_coins = (List<Rectangle>)formatter.Deserialize(fs);
                    m_enemies = (List<Airplane>)formatter.Deserialize(fs);
                    m_time = (int)formatter.Deserialize(fs);
                    for (int i = 0; i < m_enemies.Count; i++)
                    {
                        m_enemies[i].FormGame = this;
                    }
                    m_player_airplane = (Airplane)formatter.Deserialize(fs);
                    m_player_airplane.FormGame = this;
                }
                m_is_load = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Сохраняет рекорд пользователя в файл рекордов</summary>
        /// <returns>Возвращает true в случае успешного сохранения, false - в случае ошибки</returns>
        private bool SaveRecord()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter(); // создаем объект BinaryFormatter
                using (FileStream fs = new FileStream("records.bin", FileMode.OpenOrCreate)) // получаем поток, куда будем записывать сериализованные объекты
                {
                    int records_number = 0; // количество рекордов
                    if (fs.Length != 0) // если длина файла не равна нулю - рекорды есть
                    {
                        fs.Position = 0; // перемещаем указатель в начало файла
                        records_number = (int)formatter.Deserialize(fs); // количество рекордов
                        records_number++; // увеличиваем количество рекордов
                        fs.Position = 0; // перемещаем указатель в начало файла
                        formatter.Serialize(fs, records_number); // перезаписываем количество рекордов
                        fs.Position = fs.Length; // перемещаем указатель в конец файла
                        formatter.Serialize(fs, records_number); // номер рекорда
                    }
                    else // если длина файла равна нулю - рекордов нет
                    {
                        formatter.Serialize(fs, 1); // перезаписываем количество рекордов
                        formatter.Serialize(fs, 1); // номер рекорда
                    }
                    formatter.Serialize(fs, m_nick); // ник игрока
                    formatter.Serialize(fs, m_difficulty_id); // ID сложности
                    formatter.Serialize(fs, m_experience); // набранные очки
                    formatter.Serialize(fs, m_milleage); // пройденное расстояние
                    formatter.Serialize(fs, m_player_airplane.Health); // жизни (осталось)
                    formatter.Serialize(fs, m_healths); // жизни (всего)
                    formatter.Serialize(fs, m_time); // время
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка при записи в файл!", "Рекорды", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
