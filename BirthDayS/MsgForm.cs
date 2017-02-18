using System;
using System.Drawing;
using System.Windows.Forms;

namespace BirthDayS
{
    public partial class MsgForm : Form
    {
        private readonly Timer _colorChangeTimer = new Timer();
        private readonly Timer _exitTimer = new Timer();

        readonly System.Media.SoundPlayer _player1 = new System.Media.SoundPlayer(Application.StartupPath + @"\Birthday1.wav");
        readonly System.Media.SoundPlayer _player2 = new System.Media.SoundPlayer(Application.StartupPath + @"\Birthday2.wav");
        
        public enum DisplayMode
        {
            Gone = -1,
            Today = 0,
            Tomorrow = 1,
            Soon = 2
        }

        private readonly string _name;
        private readonly DisplayMode _mode;
        
        private string ModeText
        {
            get
            {
                switch(_mode)
                {
                    case DisplayMode.Gone:
                        return "День рождения прошло";

                    case DisplayMode.Today:
                        return "Поздравляем с днем рождения!";

                    case DisplayMode.Tomorrow:
                        return "Завтра день рождения!";

                    case DisplayMode.Soon:
                        return "Скоро день рождения";

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private const int ExitTime = 5000; //Через сколько мс закрыть окно
        private const int ColorChangeTime = 500; //Каждые сколько мс менять цвет сменного фона

        private readonly Color _staticColor = Color.Chartreuse;
        private readonly Color[] _colorRotation =
        {
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.Yellow
        };

        private int _colorRotation_id = 0;

        public MsgForm(string name, DisplayMode mode)
        {
            InitializeComponent();

            _name = name;
            _mode = mode;
        }

        private void MsgForm_Load(object sender, EventArgs e)
        {
            //Подписываемся на события
            KeyDown += KeyRasbirator;
            _colorChangeTimer.Tick += ColorChandgeTimerTick;
            _exitTimer.Tick += ExitTimerTick;
            
            try
            {
                if(_mode == DisplayMode.Today)
                {
                    _player1.Load();
                    _player1.Play();
                }
                else
                {
                    _player2.Load();
                    _player2.Play();
                }
            }
            catch(Exception ex)
            {
                Program.Error(ex.ToString());
            }

            PozgravLabel.Text = ModeText;
            NameLabel.Text = _name;
            
            if(_mode == DisplayMode.Today)
            {
                _colorChangeTimer.Interval = ColorChangeTime;
                _colorChangeTimer.Start();
                BackColor = _colorRotation[0];
                _colorRotation_id = 1;
            }
            else BackColor = _staticColor;
            
            _exitTimer.Interval = ExitTime;
            _exitTimer.Start();
        }

        //Функция разбора нажатых клавиш
        private void KeyRasbirator(object sender, KeyEventArgs e)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch(e.KeyCode)
            {
                //Если нажата Escape, то выключаем все приложение
                case Keys.Escape:
                    Application.Exit();
                    break;

                //Если нажата Space, то закрываем эту форму, и включаем следующию, если такова имеется
                case Keys.Space:
                    Close();
                    break;

                //Если нажата F1, то показываем окно о приложении.
                case Keys.F1:
                    var about = new AboutBox();
                    TopMost = false;
                    about.TopMost = true;
                    about.ShowDialog();
                    break;
            }
        }

        //Если сработал таймер смены цвета
        private void ColorChandgeTimerTick(object sender, EventArgs e)
        {
            BackColor = _colorRotation[_colorRotation_id];
            _colorRotation_id++;

            if(_colorRotation_id >= _colorRotation.Length)
                _colorRotation_id = 0;
        }

        //Если сработал таймер выхода
        private void ExitTimerTick(object sender, EventArgs e)
        {
            //То просто закрываем эту форму
            _player1.Dispose();
            _player2.Dispose();
            _colorChangeTimer.Dispose();
            _exitTimer.Dispose();
            Close();
        }

        private void copyright_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var about = new AboutBox();
            TopMost = false;
            about.TopMost = true;
            about.ShowDialog();
        }

        private void siteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://scrolltex.ru");
        }
    }
}
