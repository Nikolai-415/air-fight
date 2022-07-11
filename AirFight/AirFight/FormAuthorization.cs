using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace AirFight
{
    /// <summary>Форма, в которой отображается окно авторизации пользователя</summary>
    public partial class FormAuthorization : Form
    {
        FormRegistration m_form_registration;

        /// <summary>Конструктор формы</summary>
        public FormAuthorization()
        {
            InitializeComponent();
        }

        /// <summary>Событие нажатия на кнопку "Войти"</summary>
        private void button_login_Click(object sender, EventArgs e)
        {
            if (textBox_nick.Text == "")
            {
                MessageBox.Show("Введите логин!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox_password.Text == "")
                {
                    MessageBox.Show("Введите пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    string nick = textBox_nick.Text;

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
                                int users_number = (int)formatter.Deserialize(fs); // количество пользователей
                                bool is_finded = false; // найден ли введённый ник
                                for (int i = 0; i < users_number; i++) // проходим циклом по всем пользователям
                                {
                                    string finded_nick = (string)formatter.Deserialize(fs); // найденный ник
                                    string finded_password_md5 = (string)formatter.Deserialize(fs); // найденный зашифрованный пароль
                                    if (finded_nick == nick) // если введённый ник найден
                                    {
                                        if (finded_password_md5 == password_md5) // если введённый зашифрованный пароль совпадает с найденным в файле
                                        {
                                            is_finded = true;
                                            break;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Неверный пароль!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                }
                                if (!is_finded)
                                {
                                    MessageBox.Show("Введённый ник не найден!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при чтении файла!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    textBox_password.Clear(); // очищаем поле с паролем

                    FormMenu form_menu = new FormMenu(); // создаём форму с главным меню
                    form_menu.Owner = this; // устанавливаем владельца второй формы - форму авторизации
                    form_menu.Nick = nick;
                    form_menu.Show(); // показываем созданную форму
                    this.Hide(); // скрываем текущую форму

                    MessageBox.Show("Вы успешно авторизовались!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        /// <summary>Событие нажатия на кнопку "Регистрация"</summary>
        private void button_registration_Click(object sender, EventArgs e)
        {
            if (m_form_registration == null)
            {
                m_form_registration = new FormRegistration(); // создаём форму регистрации
                m_form_registration.Owner = this; // устанавливаем владельца второй формы - эту форму
            }
            m_form_registration.Show(); // показываем форму авторизации
            this.Hide(); // скрываем текущую форму
        }

        /// <summary>Событие нажатия на кнопку "ВЫйти из игры"</summary>
        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
