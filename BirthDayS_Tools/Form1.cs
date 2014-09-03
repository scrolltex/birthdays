using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.IO;

namespace BirthDayS_Tools
{
    public partial class Form1 : Form
    {
        static DateTime CurrDate = DateTime.Now; //Текущее дата и время

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyDown += new KeyEventHandler(this.KeyDowned);
        }

        private void KeyDowned(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;

                case Keys.F1:
                    About about = new About();
                    about.ShowDialog();
                    break;

                case Keys.F6:
                    CreateShortcut();
                    break;

                case Keys.F9:
                    DeleteShortcut();
                    break;
            }
        }

        private void DeleteShortcut()
        {
            try
            {
                WshShell WshShell = new WshShell();
                string DesktopDir = (string)WshShell.SpecialFolders.Item("Startup");
                System.IO.File.Delete(DesktopDir + @"\BirthDayS.lnk");

                MessageBox.Show("Успешно удалено!",
                                   Application.CompanyName + "`s " + Application.ProductName,
                                   MessageBoxButtons.YesNoCancel,
                                   MessageBoxIcon.Error); //Выводим диалоговое окно
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void CreateShortcut()
        {
            try
            {
                // Создание объекта оболочки Windows Script Host (WSH shell object)
                WshShell WshShell = new WshShell();
                string DesktopDir = (string)WshShell.SpecialFolders.Item("Startup");
                IWshShortcut Shortcut;

                // Файлы ярлыков имеют (скрытое) расширение .lnk
                Shortcut = (IWshShortcut)WshShell.CreateShortcut(DesktopDir + @"\BirthDayS.lnk");


                string Target = Application.StartupPath + @"\BirthDayS.exe";
                if (LSC_cb.Checked)
                {
                    Target += " -ls";
                }
                if(OtherBaseDir_cb.Checked)
                {
                    Target += " -cf " + OtherBaseDir_Text.Text; 
                }

                // Задание некоторых простых свойств ярлыка.
                Shortcut.TargetPath = Target;
                Shortcut.WindowStyle = 1;
                Shortcut.WorkingDirectory = DesktopDir;
                Shortcut.IconLocation = "notepad.exe, 0"; // Значком ярлыка будет первый значок из файла notepad.exe

                Shortcut.Save(); // Сохранение файла ярлыка

                MessageBox.Show("Успешно создано!",
                                   Application.CompanyName + "`s " + Application.ProductName,
                                   MessageBoxButtons.YesNoCancel,
                                   MessageBoxIcon.Error); //Выводим диалоговое окно
            }
            catch(Exception ex)
            {
                Error(ex.Message);
            }
        }

        static public void Error(string msg)
        {
            if (MessageBox.Show("Ошибка:\n" + msg + "\n\nСохранить в лог ошибок?",
                               Application.CompanyName + "`s " + Application.ProductName,
                               MessageBoxButtons.YesNoCancel,
                               MessageBoxIcon.Error) == DialogResult.Yes)//Выводим диалоговое окно, с текстом ошибки
            {
                StreamWriter sw = new StreamWriter("Errors.ser", true);
                sw.WriteLine("Время: " + CurrDate.Day + "." + CurrDate.Month + " " + CurrDate.Hour + ":" + CurrDate.Minute);
                sw.WriteLine("ОС: " + Environment.OSVersion);
                sw.WriteLine("Ошибка:\n" + msg);
                sw.WriteLine("===========================================================================================");
                sw.Close();
                sw.Dispose();
            }

            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateShortcut();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteShortcut();
        }

        private void OtherBaseDir_Find_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = false; 
            
            if(fd.ShowDialog() != DialogResult.Cancel)
            {
                OtherBaseDir_Text.Text = fd.FileName;
            }
        }
    }
}
