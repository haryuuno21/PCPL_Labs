namespace Lab4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BLoadFile = new Button();
            timeLabel = new Label();
            label1 = new Label();
            BFindWord = new Button();
            textBoxWord2Find = new TextBox();
            label2 = new Label();
            TimeFindLabel = new Label();
            listBoxResult = new ListBox();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // BLoadFile
            // 
            BLoadFile.Location = new Point(12, 31);
            BLoadFile.Name = "BLoadFile";
            BLoadFile.Size = new Size(107, 23);
            BLoadFile.TabIndex = 0;
            BLoadFile.Text = "Загрузить файл";
            BLoadFile.UseVisualStyleBackColor = true;
            BLoadFile.Click += BLoadFile_Click;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(240, 35);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(33, 15);
            timeLabel.TabIndex = 1;
            timeLabel.Text = "Time";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 35);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 2;
            label1.Text = "Время загрузки:";
            // 
            // BFindWord
            // 
            BFindWord.Location = new Point(245, 105);
            BFindWord.Name = "BFindWord";
            BFindWord.Size = new Size(75, 23);
            BFindWord.TabIndex = 3;
            BFindWord.Text = "Поиск";
            BFindWord.UseVisualStyleBackColor = true;
            BFindWord.Click += BFindWord_Click;
            // 
            // textBoxWord2Find
            // 
            textBoxWord2Find.Location = new Point(12, 105);
            textBoxWord2Find.Name = "textBoxWord2Find";
            textBoxWord2Find.Size = new Size(227, 23);
            textBoxWord2Find.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 146);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 5;
            label2.Text = "Время поиска:";
            // 
            // TimeFindLabel
            // 
            TimeFindLabel.AutoSize = true;
            TimeFindLabel.Location = new Point(105, 146);
            TimeFindLabel.Name = "TimeFindLabel";
            TimeFindLabel.Size = new Size(33, 15);
            TimeFindLabel.TabIndex = 6;
            TimeFindLabel.Text = "Time";
            // 
            // listBoxResult
            // 
            listBoxResult.FormattingEnabled = true;
            listBoxResult.ItemHeight = 15;
            listBoxResult.Location = new Point(139, 178);
            listBoxResult.Name = "listBoxResult";
            listBoxResult.Size = new Size(311, 94);
            listBoxResult.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 178);
            label3.Name = "label3";
            label3.Size = new Size(114, 15);
            label3.TabIndex = 8;
            label3.Text = "Результаты поиска:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 87);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 9;
            label4.Text = "Поиск слова:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 356);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(listBoxResult);
            Controls.Add(TimeFindLabel);
            Controls.Add(label2);
            Controls.Add(textBoxWord2Find);
            Controls.Add(BFindWord);
            Controls.Add(label1);
            Controls.Add(timeLabel);
            Controls.Add(BLoadFile);
            Name = "Form1";
            Text = "Лабораторная работа №4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BLoadFile;
        private Label timeLabel;
        private Label label1;
        private Button BFindWord;
        private TextBox textBoxWord2Find;
        private Label label2;
        private Label TimeFindLabel;
        private ListBox listBoxResult;
        private Label label3;
        private Label label4;
    }
}