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

        // ������ ����
        List<string> words = new List<string>();
        private void BLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "��������� �����|*.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Stopwatch t = new Stopwatch();
                t.Start();

                //������ ����� � ���� ������
                string text = File.ReadAllText(fileDialog.FileName);

                //�������������� ������� ��� ������ �� �����
                char[] separators = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };

                string[] textArray = text.Split(separators);

                foreach (string strTemp in textArray)
                {
                    //�������� �������� � ������ � ����� ������
                    string str = strTemp.Trim();
                    //���������� ������ � ������, ���� ������ �� ���������� � ������
                    if (!words.Contains(str)) words.Add(str);
                }

                t.Stop();
                this.timeLabel.Text = t.Elapsed.ToString();
                // this.textBoxFileReadCount.Text = list.Count.ToString();
            }
            else MessageBox.Show("���������� ������� ����");

        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void BFindWord_Click(object sender, EventArgs e)
        {
            // ����� ��� ������
            string word = this.textBoxWord2Find.Text.Trim();

            // ���� ������ ������ ����
            if (words.Count == 0)
            {
                MessageBox.Show("���������� ������� ����!");
            }
            // ���� ����� ��� ������ �����
            else if (string.IsNullOrWhiteSpace(word))
            {
                MessageBox.Show("���������� ������ ����� ��� ������!");
            }
            else
            {
                // ��������� ����� ��� ������ � ������� �������
                string wordUpper = word.ToUpper();

                //���������� ������
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

                //������� ������
                this.listBoxResult.Items.Clear();

                //����� ����������� ������ 
                foreach (string str in tempList)
                {
                    this.listBoxResult.Items.Add(str);
                }
                this.listBoxResult.EndUpdate();
            }
        }
    }
}