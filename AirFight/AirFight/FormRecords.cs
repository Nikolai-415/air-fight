using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace AirFight
{
    /// <summary>Форма, в которой отображаются рекорды</summary>
    public partial class FormRecords : Form
    {
        /// <summary>Конструктор формы</summary>
        public FormRecords()
        {
            InitializeComponent();
        }

        /// <summary>Событие загрузки формы</summary>
        private void FormRecords_Load(object sender, EventArgs e)
        {
            dataGridView_records.ColumnCount = 7; // количество столбцов таблицы

            // задаём названия столбцов
            dataGridView_records.Columns[0].Name = "Номер рекорда";
            dataGridView_records.Columns[1].Name = "Ник игрока";
            dataGridView_records.Columns[2].Name = "Сложность";
            dataGridView_records.Columns[3].Name = "Набранные очки";
            dataGridView_records.Columns[4].Name = "Пройденное расстояние";
            dataGridView_records.Columns[5].Name = "Жизни";
            dataGridView_records.Columns[6].Name = "Время";

            try
            {
                BinaryFormatter formatter = new BinaryFormatter(); // создаем объект BinaryFormatter
                using (FileStream fs = new FileStream("records.bin", FileMode.OpenOrCreate)) // получаем поток, куда будем записывать сериализованные объекты
                {
                    if (fs.Length != 0) // если длина файла не равна нулю - рекорды есть
                    {
                        fs.Position = 0; // перемещаем указатель в начало файла
                        int records_number = (int)formatter.Deserialize(fs); // количество рекордов
                        dataGridView_records.RowCount = records_number; // количество строк таблицы
                        for (int i = 0; i < records_number; i++) // проходим циклом по всем рекордам
                        {
                            int id = (int)formatter.Deserialize(fs); // номер рекорда
                            string nick = (string)formatter.Deserialize(fs); // ник игрока
                            int difficulty_id = (int)formatter.Deserialize(fs); // ID сложности
                            int experience = (int)formatter.Deserialize(fs); // набранные очки
                            int milleage = (int)formatter.Deserialize(fs); // пройденное расстояние
                            int healths_left = (int)formatter.Deserialize(fs); // жизни (осталось)
                            int healths = (int)formatter.Deserialize(fs); // жизни (было всего)
                            int time = (int)formatter.Deserialize(fs); // время

                            // занесение прочитанных из файла данных в таблицу
                            dataGridView_records.Rows[i].Cells[0].Value = id;
                            dataGridView_records.Rows[i].Cells[1].Value = nick;
                            string difficulty;
                            if (difficulty_id == 1)
                            {
                                difficulty = "Легко";
                            }
                            else if (difficulty_id == 1)
                            {
                                difficulty = "Нормально";
                            }
                            else
                            {
                                difficulty = "Сложно";
                            }
                            dataGridView_records.Rows[i].Cells[2].Value = difficulty;
                            dataGridView_records.Rows[i].Cells[3].Value = experience;
                            dataGridView_records.Rows[i].Cells[4].Value = milleage;
                            dataGridView_records.Rows[i].Cells[5].Value = healths_left.ToString() + "/" + healths.ToString();
                            dataGridView_records.Rows[i].Cells[6].Value = (time / 1000 / 60).ToString() + " мин. " + (time / 1000).ToString() + " сек.";
                        }
                    }
                    else // если нет рекордов
                    {
                        dataGridView_records.RowCount = 0; // количество строк = 0
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при чтении файла!", "Рекорды", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>Событие закрытия формы</summary>
        private void FormRecords_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show(); // показываем форму главного меню
        }

        /// <summary>Событие нажатия на кнопку "Назад"</summary>
        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
