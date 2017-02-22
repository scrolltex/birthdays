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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataEncodingLabel = new System.Windows.Forms.Label();
            this.dataEncoding = new System.Windows.Forms.ComboBox();
            this.OtherBaseDir_Find = new System.Windows.Forms.Button();
            this.OtherBaseDir_Text = new System.Windows.Forms.TextBox();
            this.OtherBaseDir_cb = new System.Windows.Forms.CheckBox();
            this.LSC_cb = new System.Windows.Forms.CheckBox();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(263, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Создать ярлык автозапуска";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(263, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Удалить ярлык автозапуска";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataEncodingLabel);
            this.groupBox1.Controls.Add(this.dataEncoding);
            this.groupBox1.Controls.Add(this.OtherBaseDir_Find);
            this.groupBox1.Controls.Add(this.OtherBaseDir_Text);
            this.groupBox1.Controls.Add(this.OtherBaseDir_cb);
            this.groupBox1.Controls.Add(this.LSC_cb);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 120);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // dataEncodingLabel
            // 
            this.dataEncodingLabel.AutoSize = true;
            this.dataEncodingLabel.Location = new System.Drawing.Point(6, 94);
            this.dataEncodingLabel.Name = "dataEncodingLabel";
            this.dataEncodingLabel.Size = new System.Drawing.Size(97, 13);
            this.dataEncodingLabel.TabIndex = 9;
            this.dataEncodingLabel.Text = "Кодировка файла";
            // 
            // dataEncoding
            // 
            this.dataEncoding.FormattingEnabled = true;
            this.dataEncoding.Location = new System.Drawing.Point(109, 91);
            this.dataEncoding.Name = "dataEncoding";
            this.dataEncoding.Size = new System.Drawing.Size(160, 21);
            this.dataEncoding.TabIndex = 8;
            // 
            // OtherBaseDir_Find
            // 
            this.OtherBaseDir_Find.Location = new System.Drawing.Point(219, 63);
            this.OtherBaseDir_Find.Name = "OtherBaseDir_Find";
            this.OtherBaseDir_Find.Size = new System.Drawing.Size(50, 23);
            this.OtherBaseDir_Find.TabIndex = 7;
            this.OtherBaseDir_Find.Text = "Обзор";
            this.OtherBaseDir_Find.UseVisualStyleBackColor = true;
            this.OtherBaseDir_Find.Click += new System.EventHandler(this.OtherBaseDir_Find_Click);
            // 
            // OtherBaseDir_Text
            // 
            this.OtherBaseDir_Text.Location = new System.Drawing.Point(6, 65);
            this.OtherBaseDir_Text.Name = "OtherBaseDir_Text";
            this.OtherBaseDir_Text.Size = new System.Drawing.Size(207, 20);
            this.OtherBaseDir_Text.TabIndex = 6;
            // 
            // OtherBaseDir_cb
            // 
            this.OtherBaseDir_cb.AutoSize = true;
            this.OtherBaseDir_cb.Location = new System.Drawing.Point(6, 42);
            this.OtherBaseDir_cb.Name = "OtherBaseDir_cb";
            this.OtherBaseDir_cb.Size = new System.Drawing.Size(191, 17);
            this.OtherBaseDir_cb.TabIndex = 5;
            this.OtherBaseDir_cb.Text = "Другое нахождение файла базы";
            this.OtherBaseDir_cb.UseVisualStyleBackColor = true;
            this.OtherBaseDir_cb.CheckedChanged += new System.EventHandler(this.OtherBaseDir_cb_CheckedChanged);
            // 
            // LSC_cb
            // 
            this.LSC_cb.AutoSize = true;
            this.LSC_cb.Location = new System.Drawing.Point(6, 19);
            this.LSC_cb.Name = "LSC_cb";
            this.LSC_cb.Size = new System.Drawing.Size(128, 17);
            this.LSC_cb.TabIndex = 3;
            this.LSC_cb.Text = "Запуск 1 раз в день";
            this.LSC_cb.UseVisualStyleBackColor = true;
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(BirthDayS_Tools.Form1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(289, 211);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BirthDayS Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
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
        private System.Windows.Forms.ComboBox dataEncoding;
        private System.Windows.Forms.Label dataEncodingLabel;
        private System.Windows.Forms.BindingSource form1BindingSource;
    }
}

