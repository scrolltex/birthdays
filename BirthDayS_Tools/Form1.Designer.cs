namespace BirthDayS_Tools
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OtherBaseDir_Find = new System.Windows.Forms.Button();
            this.OtherBaseDir_Text = new System.Windows.Forms.TextBox();
            this.OtherBaseDir_cb = new System.Windows.Forms.CheckBox();
            this.LSC_cb = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Создать ярлык автозапуска";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Удалить ярлык автозапуска";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OtherBaseDir_Find);
            this.groupBox1.Controls.Add(this.OtherBaseDir_Text);
            this.groupBox1.Controls.Add(this.OtherBaseDir_cb);
            this.groupBox1.Controls.Add(this.LSC_cb);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 171);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Автозапуск";
            // 
            // OtherBaseDir_Find
            // 
            this.OtherBaseDir_Find.Location = new System.Drawing.Point(7, 141);
            this.OtherBaseDir_Find.Name = "OtherBaseDir_Find";
            this.OtherBaseDir_Find.Size = new System.Drawing.Size(187, 23);
            this.OtherBaseDir_Find.TabIndex = 7;
            this.OtherBaseDir_Find.Text = "Обзор...";
            this.OtherBaseDir_Find.UseVisualStyleBackColor = true;
            this.OtherBaseDir_Find.Click += new System.EventHandler(this.OtherBaseDir_Find_Click);
            // 
            // OtherBaseDir_Text
            // 
            this.OtherBaseDir_Text.Location = new System.Drawing.Point(7, 115);
            this.OtherBaseDir_Text.Name = "OtherBaseDir_Text";
            this.OtherBaseDir_Text.Size = new System.Drawing.Size(187, 20);
            this.OtherBaseDir_Text.TabIndex = 6;
            // 
            // OtherBaseDir_cb
            // 
            this.OtherBaseDir_cb.AutoSize = true;
            this.OtherBaseDir_cb.Location = new System.Drawing.Point(7, 79);
            this.OtherBaseDir_cb.Name = "OtherBaseDir_cb";
            this.OtherBaseDir_cb.Size = new System.Drawing.Size(191, 30);
            this.OtherBaseDir_cb.TabIndex = 5;
            this.OtherBaseDir_cb.Text = "Другое нахождение файла базы\r\n(Написать внизу)";
            this.OtherBaseDir_cb.UseVisualStyleBackColor = true;
            // 
            // LSC_cb
            // 
            this.LSC_cb.AutoSize = true;
            this.LSC_cb.Location = new System.Drawing.Point(7, 56);
            this.LSC_cb.Name = "LSC_cb";
            this.LSC_cb.Size = new System.Drawing.Size(128, 17);
            this.LSC_cb.TabIndex = 3;
            this.LSC_cb.Text = "Запуск 1 раз в день";
            this.LSC_cb.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(223, 228);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BirthDayS Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox LSC_cb;
        private System.Windows.Forms.CheckBox OtherBaseDir_cb;
        private System.Windows.Forms.Button OtherBaseDir_Find;
        private System.Windows.Forms.TextBox OtherBaseDir_Text;
    }
}

