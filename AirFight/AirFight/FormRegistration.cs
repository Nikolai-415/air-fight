using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace AirFight
{
    /// <summary>Форма, в которой отображается окно регистрации пользователя</summary>
    public partial class FormRegistration : Form
    {
        /// <summary>Конструктор формы</summary>
        public FormRegistration()
        {
            InitializeComponent();
        }

        /// <summary>Событие закрытия формы</summary>
        private void FormRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0); // закрытие программы
        }

        /// <summary>Событие нажатия на кнопку "Зарегистрироваться"</summary>
        private void button_register_Click(object sender, EventArgs e)
        {
            if (textBox_nick.Text == "") // если поле для ввода ника - пустое
            {
                MessageBox.Show("Введите логин!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox_password.Text == "") // если поле для ввода пароля - пустое
                {
                    MessageBox.Show("Введите пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string nick = textBox_nick.Text; // ник игрока

                    int users_number = 0; // количество пользователей
                    try
                    {
                        BinaryFormatter formatter = new BinaryFormatter(); // создаем объект BinaryFormatter
                        using (FileStream fs = new FileStream("users.bin", FileMode.OpenOrCreate)) // получаем поток, куда будем записывать сериализованные объекты
                        {
                            if (fs.Length != 0) // если длина файла не равна нулю - пользователи есть
                            {
                                fs.Position = 0; // перемещаем указатель в начало файла
                                users_number = (int)formatter.Deserialize(fs);
                                for (int i = 0; i < users_number; i++) // проходим циклом по всем пользователям
                                {
                                    string finded_nick = (string)formatter.Deserialize(fs); // найденный ник
                                    string finded_password_md5 = (string)formatter.Deserialize(fs); // найденный зашифрованный пароль
                                    if (finded_nick == nick) // если введённый ник уже есть в файле
                                    {
                                        MessageBox.Show("Пользователь с таким логином уже зарегистрирован!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при чтении файла!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    users_number++;

                    string password = textBox_password.Text; // пароль
                    MD5 md5Hash = MD5.Create();
                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                    StringBuilder sBuilder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }
                    string password_md5 = sBuilder.ToString(); // зашифрованный при помощи MD5 пароль

                    try
                    {
                        BinaryFormatter formatter = new BinaryFormatter(); // создаем объект BinaryFormatter
                        using (FileStream fs = new FileStream("users.bin", FileMode.OpenOrCreate)) // получаем поток, куда будем записывать сериализованные объекты
                        {
                            if (fs.Length != 0) // если длина файла не равна нулю - пользователи есть
                            {
                                fs.Position = 0; // перемещаем указатель в начало файла
                                formatter.Serialize(fs, users_number); // перезаписываем число пользователей
                                fs.Position = fs.Length; // перемещаем указатель в конец файла
                            }
                            else // если длина файла равна нулю - пользователей нет
                            {
                                formatter.Serialize(fs, 1); // 1 пользователь
                            }
                            formatter.Serialize(fs, nick); // записываем ник в файл
                            formatter.Serialize(fs, password_md5); // записываем зашифрованный пароль в файл
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при записи в файл!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    textBox_password.Clear(); // очищаем поле с паролем

                    FormMenu form_menu = new FormMenu(); // создаём форму с главным меню
                    form_menu.Owner = this.Owner; // устанавливаем владельца второй формы - форму авторизации
                    form_menu.Nick = nick;
                    form_menu.Show(); // показываем созданную форму
                    this.Hide(); // скрываем текущую форму

                    MessageBox.Show("Вы успешно зарегистрировались!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        /// <summary>Событие нажатия на кнопку "Авторизация"</summary>
        private void button_authorization_Click(object sender, EventArgs e)
        {
            this.Owner.Show(); // показываем форму авторизации
            this.Hide(); // скрываем текущую форму
        }

        /// <summary>Событие нажатия на кнопку "Выйти из игры"</summary>
        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
