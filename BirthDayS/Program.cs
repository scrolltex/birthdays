using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BirthDayS
{
    static class Program
    {
        static Encoding dosEnc = Encoding.GetEncoding("CP866");
        static string Filename = Application.StartupPath + @"\BIRTH.DAY"; //Имя и расположение файла базы данных
        static string LastStartFile = Application.LocalUserAppDataPath.Remove(Application.LocalUserAppDataPath.IndexOf(Application.ProductVersion)) + @"\LastStart"; //Имя и расположение файла проверки запусков
        
        static DateTime CurrDate = DateTime.Now; //Текущее дата и время
        static int LastStartDate = 0; //Дата последнего включения программы
        static bool LastStartCheck = true;

        static List<string> Names = new List<string>(); //Полочка для имен
        static List<string> Dates = new List<string>(); //Полочка для дат

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if(args.Length != 0)
            {
                #region Проверка команд запуска
                for (int c = 0; c < args.Length; c++)
                {
                    if(args[c].ToString() == "-noLastStartCheck")
                    {
                        LastStartCheck = false;
                    }
                    else if(args[c].ToString() == "-LastStartCheck")
                    {
                        LastStartCheck = true;
                    }
                    else if(args[c].ToString().StartsWith("-CustomFile="))
                    {
                        Filename = args[c].ToString().Substring(args[c].ToString().IndexOf("-CustomFile=") + ("-CustomFile=").Length);
                    }
                    else
                    {
                        MessageBox.Show("Неопознаная команда: " + args[c].ToString(),
                                    Application.CompanyName + "`s " + Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);//Выводим диалоговое окно, с текстом ошибки
                        Application.Exit();
                    }
                }
                #endregion
            }

            #region Запускалась ли проверка сегодня?
            #if !DEBUG  //Только если собираем в конфигурации Release
            if (LastStartCheck)
            {
                try
                {
                    StreamReader lsFileRead = new StreamReader(LastStartFile); //Читатель файла последнего запуска
                    LastStartDate = Convert.ToInt32(lsFileRead.ReadLine()); //Читаем когда был последний запуск
                    lsFileRead.Close();
                    lsFileRead.Dispose();
                    if (LastStartDate != CurrDate.Day) //Если прочитанная дата запуска не ровняется сегодняшней дате, то пишим в файл сегодняшнюю дату, тк мы сегодня не запуская программку
                    {
                        StreamWriter lsFileWrite = new StreamWriter(LastStartFile, false);
                        lsFileWrite.WriteLine(CurrDate.Day);
                        lsFileWrite.Close();
                        lsFileWrite.Dispose();
                    }
                }
                catch (FileNotFoundException)
                {
                    StreamWriter lsFileWrite = new StreamWriter(LastStartFile, false);
                    lsFileWrite.WriteLine(CurrDate.Day);
                    lsFileWrite.Close();
                    lsFileWrite.Dispose();
                }
                catch (Exception ex)
                {
                    #region Обработка ошибок
                    MessageBox.Show(ex.ToString(),
                                    Application.CompanyName + "`s " + Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);//Выводим диалоговое окно, с текстом ошибки
                    Application.Exit();
                    #endregion
                }
            }
            #endif
            #endregion

            //Если дата последней проверки не совпадает с текущей, то запускаем приложение
            if (LastStartDate != CurrDate.Day)
            {
                try
                {
                    #region Читаем и распихиваем по полочкам
                    string buff; //Буфер, в который мы сначала записываем прочитанную информацию
                    StreamReader reader = new StreamReader(Filename, dosEnc); //Новый экземпляр "Читателя"
                    while (!reader.EndOfStream) //Читаем все до конца!!!
                    {
                        buff = reader.ReadLine(); //Кидаем в буфер
                        if (!string.IsNullOrWhiteSpace(buff))
                        {
                            Dates.Add(buff.Substring(0, 8)); //Первые 9 символов - это дата, кидаем на полочку с датами.
                            Names.Add(buff.Substring(9)); //Остальное имя.
                        }
                    }
                    reader.Close(); //Отправляем "читателя" отдыхать
                    reader.Dispose();
                    #endregion

                    #region Разбираем и проверяем даты и выводи сообщения
                    for (int i = 0; i < Dates.Count; i++)//Разбираем все даты на полочке
                    {
                        if (Convert.ToInt32(Dates[i].Substring(3, 2)) == CurrDate.Month) //Если день рождения в этом месяце то идем дальше
                        {
                            if (Convert.ToInt32(Dates[i].Substring(0, 2)) == CurrDate.Day) //Если день рождения сегодня, то поздравляем
                            {
                                MsgForm msg = new MsgForm(Names[i], 1); //Создаем новый экземпляр формы сообщений, в который мы передаем Имя, дату и сегодня ли лень рождения
                                msg.ShowDialog(); //И отображаем его как диалоговое окно
                                msg.Dispose();
                            }
                            else if (Convert.ToInt32(Dates[i].Substring(0, 2)) == CurrDate.AddDays(1).Day) //Если день рождения завтра, то выводим сообщение
                            {
                                MsgForm msg = new MsgForm(Names[i], 2);
                                msg.ShowDialog();
                                msg.Dispose();
                            }

                            if (CurrDate.DayOfWeek == DayOfWeek.Friday) //А если сегодня пятница, то еще проверяем на воскресенье с понедельником
                            {
                                if (Convert.ToInt32(Dates[i].Substring(0, 2)) == CurrDate.AddDays(2).Day)
                                {
                                    MsgForm msg = new MsgForm(Names[i], 3);
                                    msg.ShowDialog();
                                    msg.Dispose();
                                }
                                else if (Convert.ToInt32(Dates[i].Substring(0, 2)) == CurrDate.AddDays(3).Day)
                                {
                                    MsgForm msg = new MsgForm(Names[i], 3);
                                    msg.ShowDialog();
                                    msg.Dispose();
                                }

                            }
                        }
                    }
                    #endregion

                    Application.Exit(); //Мы все сделали, поэтому выходим
                }
                catch (Exception ex)
                {
                    #region Обработка ошибок
                    MessageBox.Show(ex.ToString(),
                                    Application.CompanyName + "`s " + Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);//Выводим диалоговое окно, с текстом ошибки
                    Application.Exit();
                    #endregion
                }
            }
            else Application.Exit(); //Иначе уходим... Но завтра вернемся!!!
        }
    }
}
