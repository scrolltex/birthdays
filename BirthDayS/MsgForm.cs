using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirthDayS
{
    public partial class MsgForm : Form
    {
        Timer colorChangeTimer = new Timer(); //Таймер для смены цвета фона
        Timer exitTimer = new Timer(); //Таймер для закрытия через определенное время

        System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(HappyBirthdaySoundFile);
        System.Media.SoundPlayer player2 = new System.Media.SoundPlayer(HappyBirthdayLaterSoundFile);

        string BDName = null; //Имя
        int BirthDayNow; //Сегодня ли день рождения?
        int CurrBGid = 0; //Текущий id фона (сменного)

        static string HappyBirthdaySoundFile = Application.StartupPath + @"\Birthday1.wav";
        static string HappyBirthdayLaterSoundFile = Application.StartupPath + @"\Birthday2.wav";

        const string BDNowText = "Поздравляем с днем рождения!"; //Текст поздравления, если день рождения сегодня
        const string BDTommorowText = "Завтра день рождения!"; //Если день рождения завтра
        const string BDLaterText = "Скоро день рождения!"; //Если день рождения скоро

        const int ExitTime = 5000; //Через сколько мс закрыть окно
        const int ColorChangeTime = 500; //Каждые сколько мс менять цвет сменного фона

        Color preBDbg = Color.Chartreuse; //Цвет статического фона, если день рождения скоро
        Color[] MultiColoBG = //А это цвета фона, если день рождения сегодня
        {
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.Yellow
        };

        public MsgForm(string n, int bdNow) //Конструктор формы, n = Имя, bdNow = Сегодня ли день рождения
        {
            InitializeComponent();

            //Присваеваем значения
            BDName = n;
            BirthDayNow = bdNow;
        }

        private void MsgForm_Load(object sender, EventArgs e)
        {
            //Подписываемся на события
            this.KeyDown += new KeyEventHandler(this.KeyRasbirator); //Нажатие кнопки
            this.colorChangeTimer.Tick += new EventHandler(this.colorChandgeTimerTick); //Срабатывание таймера смены цвета
            this.exitTimer.Tick += new EventHandler(this.exitTimerTick); //Срабатывание таймера выхода

            //Здесь смотрим какой текст выводить
            if (BirthDayNow == 1)
            {
                PozgravLabel.Text = BDNowText;
                try
                {
                    player1.Load();
                    player1.Play();
                }
                catch (Exception ex) { }
            }
            else if (BirthDayNow == 2)
            {
                PozgravLabel.Text = BDTommorowText;
                try
                {
                    player2.Load();
                    player2.Play();
                }
                catch (Exception ex) { }
            }
            else
            {
                PozgravLabel.Text = BDLaterText;
                try
                {
                    player2.Load();
                    player2.Play();
                }
                catch (Exception ex) { }
            }

            //Пишем на форме имя
            NameLabel.Text = BDName;

            if (BirthDayNow == 1) //Если день рождения сегодня, то включаем перебор цветов фона
            {
                colorChangeTimer.Interval = ColorChangeTime;
                colorChangeTimer.Start();
                this.BackColor = MultiColoBG[CurrBGid];
                CurrBGid++;
            }
            else this.BackColor = preBDbg;

            //И устанавливаем таймер выхода
            exitTimer.Interval = ExitTime;
            exitTimer.Start();
        }

        //Функция разбора нажатых клавиш
        private void KeyRasbirator(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit(); //Если нажата Escape, то выключаем все приложение
                    break;

                case Keys.Space:
                    this.Close(); //Если нажата Space, то закрываем эту форму, и включаем следующию, если такова имеется
                    break;

                case Keys.F1:
                    AboutBox about = new AboutBox(); //Если нажата F1, то показываем окно о приложении.
                    about.ShowDialog();
                    break;
            }
        }

        //Если сработал таймер смены цвета
        private void colorChandgeTimerTick(object sender, EventArgs e)
        {
            this.BackColor = MultiColoBG[CurrBGid]; //Берем из масива цветов цвет по id (CurrBGid), и устанавливаем в качестве фона
            CurrBGid++; //Инкрементируем

            //И смотрим за выходом за размер массива!!!
            if (CurrBGid >= MultiColoBG.Length)
                CurrBGid = 0;
        }

        //Усли сработал таймер выхода
        private void exitTimerTick(object sender, EventArgs e)
        {
            //То просто закрываем эту форму
            player1.Dispose();
            player2.Dispose();
            colorChangeTimer.Dispose();
            exitTimer.Dispose();
            this.Close();
        }

        private void copyright_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutBox about = new AboutBox();
            this.TopMost = false;
            about.TopMost = true;
            about.ShowDialog();
        }
    }
}
