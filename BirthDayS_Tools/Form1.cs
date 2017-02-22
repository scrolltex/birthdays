using System;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.IO;
using System.Text;

// ReSharper disable LocalizableElement

namespace BirthDayS_Tools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(var enc in Encoding.GetEncodings())
                dataEncoding.Items.Add(enc.DisplayName);
            
            dataEncoding.SelectedIndex = dataEncoding.Items.IndexOf(Encoding.UTF8.EncodingName);

            OtherBaseDir_Text.Enabled = OtherBaseDir_cb.Checked;
            OtherBaseDir_Find.Enabled = OtherBaseDir_cb.Checked;
        }
        
        private static void DeleteShortcut()
        {
            try
            {
                var shell = new WshShell();
                var startup = shell.SpecialFolders.Item("Startup").ToString();
                System.IO.File.Delete(startup + @"\BirthDayS.lnk");

                MessageBox.Show("Успешно удалено!",
                                   Application.ProductName,
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
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
                var shell = new WshShell();
                var startup = shell.SpecialFolders.Item("Startup").ToString();

                // Файлы ярлыков имеют (скрытое) расширение .lnk
                var shortcut = (IWshShortcut)shell.CreateShortcut(startup + @"\BirthDayS.lnk");

                var arguments = "";

                if(LSC_cb.Checked)
                    arguments += " -ls";

                if(OtherBaseDir_cb.Checked)
                    arguments += " -cf " + OtherBaseDir_Text.Text;

                if(dataEncoding.SelectedIndex != dataEncoding.Items.IndexOf(Encoding.UTF8.EncodingName))
                    arguments += " -enc " + Encoding.GetEncodings()[dataEncoding.SelectedIndex].Name;

                // Задание некоторых простых свойств ярлыка.
                shortcut.TargetPath = Application.StartupPath + @"\BirthDayS.exe";
                shortcut.Arguments = arguments;
                shortcut.WindowStyle = 1;
                shortcut.WorkingDirectory = startup;
                shortcut.IconLocation = Application.StartupPath + @"\BirthDayS.exe" + ", 0";

                shortcut.Save(); // Сохранение файла ярлыка

                MessageBox.Show("Успешно создано!",
                                   Application.ProductName,
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information); //Выводим диалоговое окно
            }
            catch(Exception ex)
            {
                Error(ex.Message);
            }
        }

        public static void Error(string msg)
        {
            MessageBox.Show("Ошибка:\n" + msg,
                Application.ProductName,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Error);

            using(var sw = new StreamWriter("errors.log", true))
            {
                var date = DateTime.Now;
                sw.WriteLine("Время: " + date.Day + "." + date.Month + " " + date.Hour + ":" + date.Minute);
                sw.WriteLine("ОС: " + Environment.OSVersion);
                sw.WriteLine("Ошибка:\n" + msg);
                sw.WriteLine();
                sw.Close();
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
            var fd = new OpenFileDialog();
            fd.Multiselect = false; 
            
            if(fd.ShowDialog() != DialogResult.Cancel)
                OtherBaseDir_Text.Text = fd.FileName;
        }

        private void OtherBaseDir_cb_CheckedChanged(object sender, EventArgs e)
        {
            OtherBaseDir_Text.Enabled = OtherBaseDir_cb.Checked;
            OtherBaseDir_Find.Enabled = OtherBaseDir_cb.Checked;
        }
    }
}
