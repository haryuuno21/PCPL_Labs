using System.Collections.Generic;
using System.Diagnostics;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Список слов
        List<string> words = new List<string>();
        private void BLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "текстовые файлы|*.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Stopwatch t = new Stopwatch();
                t.Start();

                //Чтение файла в виде строки
                string text = File.ReadAllText(fileDialog.FileName);

                //Разделительные символы для чтения из файла
                char[] separators = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };

                string[] textArray = text.Split(separators);

                foreach (string strTemp in textArray)
                {
                    //Удаление пробелов в начале и конце строки
                    string str = strTemp.Trim();
                    //Добавление строки в список, если строка не содержится в списке
                    if (!words.Contains(str)) words.Add(str);
                }

                t.Stop();
                this.timeLabel.Text = t.Elapsed.ToString();
                // this.textBoxFileReadCount.Text = list.Count.ToString();
            }
            else MessageBox.Show("Необходимо выбрать файл");

        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void BFindWord_Click(object sender, EventArgs e)
        {
            // Слово для поиска
            string word = this.textBoxWord2Find.Text.Trim();

            // Если пустой список слов
            if (words.Count == 0)
            {
                MessageBox.Show("Необходимо выбрать файл!");
            }
            // Если слово для поиска пусто
            else if (string.IsNullOrWhiteSpace(word))
            {
                MessageBox.Show("Необходимо ввести слово для поиска!");
            }
            else
            {
                // Переводим слово для поиска в верхний регистр
                string wordUpper = word.ToUpper();

                //Результаты поиска
                List<string> tempList = new List<string>();

                Stopwatch t = new Stopwatch();
                t.Start();

                foreach (string str in words)
                {
                    if (str.ToUpper().Contains(wordUpper))
                    {
                        tempList.Add(str);
                    }
                }

                t.Stop();
                this.TimeFindLabel.Text = t.Elapsed.ToString();

                this.listBoxResult.BeginUpdate();

                //Очистка списка
                this.listBoxResult.Items.Clear();

                //Вывод результатов поиска 
                foreach (string str in tempList)
                {
                    this.listBoxResult.Items.Add(str);
                }
                this.listBoxResult.EndUpdate();
            }
        }
    }
}