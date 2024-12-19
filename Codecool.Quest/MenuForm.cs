using Codecool.Квест.Models;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System;
using System.Drawing.Imaging;


namespace Codecool.Квест
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            SetupMenu();
        }

        private void SetupMenu()
        {
            Image backgroundImage = Image.FromFile(@"Resources\roguelikeDungeon_transparent.png");

            // Создание нового объекта Bitmap, чтобы изменить прозрачность
            Bitmap transparentBackground = new Bitmap(backgroundImage.Width, backgroundImage.Height);

            // Создание графики для рисования
            using (Graphics g = Graphics.FromImage(transparentBackground))
            {
                // Установка прозрачности
                ColorMatrix colorMatrix = new ColorMatrix
                {
                    Matrix33 = 0.7f // Устанавливаем прозрачность (0.5 - полупрозрачность)
                };

                // Применяем матрицу к изображению
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                // Рисуем изображение с применением прозрачности
                g.DrawImage(backgroundImage, new Rectangle(0, 0, backgroundImage.Width, backgroundImage.Height),
                    0, 0, backgroundImage.Width, backgroundImage.Height, GraphicsUnit.Pixel, imageAttributes);
            }

            // Устанавливаем фон
            this.BackgroundImage = transparentBackground;
            this.BackgroundImageLayout = ImageLayout.Tile;
            this.ClientSize = new Size(800, 600);
            this.Text = "Квест";

            // Создание кнопок
            Button startButton = CreateButton("Начать игру", 300, 200, StartGame);
            Button howToPlayButton = CreateButton("Как играть", 300, 270, ShowHowToPlay);
            Button aboutButton = CreateButton("Об авторе", 300, 340, ShowAbout);
            Button exitButton = CreateButton("Выход", 300, 410, ExitGame);

            // Добавление кнопок на форму
            this.Controls.Add(startButton);
            this.Controls.Add(howToPlayButton);
            this.Controls.Add(aboutButton);
            this.Controls.Add(exitButton);
        }

        private Button CreateButton(string text, int x, int y, EventHandler onClick)
        {
            Button button = new Button();
            button.Text = text;
            button.Size = new Size(200, 50);
            button.Location = new Point(x, y);
            button.Font = new Font("Arial", 12, FontStyle.Bold);
            button.BackColor = Color.LightGray;
            button.ForeColor = Color.Black;
            button.Click += onClick;
            return button;
        }

        // Обработчики кнопок
        private void StartGame(object sender, EventArgs e)
        {
            this.Hide(); // Скрыть меню
            MainForm gameForm = new MainForm(); // Создать форму игры
            gameForm.Show(); // Показать игру
        }

        private void ShowHowToPlay(object sender, EventArgs e)
        {
            MessageBox.Show("Инструкция:\nИспользуйте WASD для перемещения. ЛКМ для взаимодействия.",
                            "Как играть", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowAbout(object sender, EventArgs e)
        {
            MessageBox.Show("Игра разработана Рогачёвым Всеволодом.\nПроект был разработан в рамках курсовой работы второго курса 2024 года.",
                            "Об авторе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitGame(object sender, EventArgs e)
        {
            Application.Exit(); // Завершить приложение
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.SuspendLayout();
            // 
            // MenuForm
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1710, 844);
            this.HelpButton = true;
            this.Name = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);

        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}