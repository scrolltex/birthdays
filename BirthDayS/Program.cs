using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BirthDayS
{
    static class Program
    {
        private static readonly Encoding DosEnc = Encoding.GetEncoding("CP866"); //DOS кодировка
        private static string _filename = Application.StartupPath + @"\BIRTH.DAY"; //Имя и расположение файла базы данных
        private static readonly string LastStartFile = Application.LocalUserAppDataPath.Remove(Application.LocalUserAppDataPath.IndexOf(Application.ProductVersion)) + @"\LastStart"; //Имя и расположение файла проверки запусков

        private static DateTime _currDate = DateTime.Now; //Текущее дата и время
        private static int _lastStartDate = 0; //Дата последнего включения программы
        private static bool _lastStartCheck = false; //Нужна ли проверка последнего включения

        private static List<string> _names = new List<string>(); //Полочка для имен
        private static List<string> _dates = new List<string>(); //Полочка для дат

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if(args.Length != 0)
            {
                for (var c = 0; c < args.Length; c++)
                {
                    if(!args[c].StartsWith("-"))
                        continue;

                    switch(args[c])
                    {
                        case "-ls":
                            _lastStartCheck = true;
                            break;

                        case "-cf ":
                            _filename = args[++c];
                            break;

                        default:
                            Error("Неопознаная команда: " + args[c]);
                            break;
                    }
                }
            }
            
            #if !DEBUG 
            if (_lastStartCheck)
            {
                try
                {
                    var lsFileRead = new StreamReader(LastStartFile); //Читатель файла последнего запуска
                    _lastStartDate = Convert.ToInt32(lsFileRead.ReadLine()); //Читаем когда был последний запуск
                    lsFileRead.Close();
                    lsFileRead.Dispose();
                    if (_lastStartDate != _currDate.Day) //Если прочитанная дата запуска не ровняется сегодняшней дате, то пишим в файл сегодняшнюю дату, тк мы сегодня не запуская программку
                    {
                        var lsFileWrite = new StreamWriter(LastStartFile, false);
                        lsFileWrite.WriteLine(_currDate.Day);
                        lsFileWrite.Close();
                        lsFileWrite.Dispose();
                    }
                }
                catch (FileNotFoundException)
                {
                    var lsFileWrite = new StreamWriter(LastStartFile, false);
                    lsFileWrite.WriteLine(_currDate.Day);
                    lsFileWrite.Close();
                    lsFileWrite.Dispose();
                }
                catch (Exception ex)
                {
                    Error(ex.Message);
                }
            }
            else
            {
                var lsFileWrite = new StreamWriter(LastStartFile, false);
                lsFileWrite.WriteLine(_currDate.Day);
                lsFileWrite.Close();
                lsFileWrite.Dispose();
            }
#endif

            //Если дата последней проверки не совпадает с текущей, то запускаем приложение
            if (_lastStartDate != _currDate.Day)
            {
                try
                {
                    using (var reader = new StreamReader(_filename, DosEnc))
                    {
                        while(!reader.EndOfStream) //Читаем все до конца
                        {
                            var buff = reader.ReadLine();
                            if(string.IsNullOrWhiteSpace(buff))
                                continue;

                            //Первые 9 символов - это дата, кидаем на полочку с датами. Остальное это имя
                            _dates.Add(buff.Substring(0, 8));
                            _names.Add(buff.Substring(9));
                        }

                        reader.Close(); 
                    }
                    
#if DEBUG
                    _names = new List<string> { "Иванов Иван Иванович" };
                    _dates = new List<string> { _currDate.ToShortDateString() };
#endif

                    //Разбираем все даты на полочке
                    for(var i = 0; i < _dates.Count; i++)
                    {
                        //Пропуск дней рождения не в текущем месяце
                        if(Convert.ToInt32(_dates[i].Substring(3, 2)) != _currDate.Month)
                            continue;

                        var day = Convert.ToInt32(_dates[i].Substring(0, 2));

                        //Если день рождения сегодня, то поздравляем
                        if(day == _currDate.Day) 
                        {
                            var msg = new MsgForm(_names[i], MsgForm.DisplayMode.Today);
                            msg.ShowDialog();
                            msg.Dispose();
                        }
                        else if (day == _currDate.AddDays(1).Day) //Если день рождения завтра, то выводим сообщение
                        {
                            var msg = new MsgForm(_names[i], MsgForm.DisplayMode.Tomorrow);
                            msg.ShowDialog();
                            msg.Dispose();
                        }

                        if (_currDate.DayOfWeek == DayOfWeek.Friday) //А если сегодня пятница, то еще проверяем на воскресенье с понедельником
                        {
                            if (day == _currDate.AddDays(2).Day ||
                                day == _currDate.AddDays(3).Day)
                            {
                                var msg = new MsgForm(_names[i], MsgForm.DisplayMode.Soon);
                                msg.ShowDialog();
                                msg.Dispose();
                            }
                        }

                        if(_currDate.DayOfWeek == DayOfWeek.Monday) //Прошедшее
                        {
                            if(day == _currDate.AddDays(-1).Day ||
                               day == _currDate.AddDays(-2).Day)
                            {
                                var msg = new MsgForm(_names[i], MsgForm.DisplayMode.Gone);
                                msg.ShowDialog();
                                msg.Dispose();
                            }
                        }
                    }

                    Application.Exit(); 
                }
                catch (Exception ex)
                {
                    Error(ex.Message);
                }
            }
            else Application.Exit();
        }

        public static void Error(string msg)
        {
            //Выводим диалоговое окно, с текстом ошибки
            MessageBox.Show("Ошибка:\n" + msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            using(var sw = new StreamWriter("errors.log", true))
            {
                sw.WriteLine($"Время: {_currDate.Day}.{_currDate.Month} {_currDate.Hour}:{_currDate.Minute}");
                sw.WriteLine("ОС: " + Environment.OSVersion);
                sw.WriteLine("Ошибка:\n" + msg);
                sw.WriteLine();
                sw.Close();
            }

            Application.Exit();
        }
    }
}
