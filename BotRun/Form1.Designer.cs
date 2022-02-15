namespace BotRun
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TokenLabel = new System.Windows.Forms.Label();
            this.DataPathLabel = new System.Windows.Forms.Label();
            this.TokenBox = new System.Windows.Forms.TextBox();
            this.DataPathBox = new System.Windows.Forms.TextBox();
            this.RunBtn = new System.Windows.Forms.Button();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TokenLabel
            // 
            this.TokenLabel.AutoSize = true;
            this.TokenLabel.Location = new System.Drawing.Point(35, 15);
            this.TokenLabel.Name = "TokenLabel";
            this.TokenLabel.Size = new System.Drawing.Size(38, 13);
            this.TokenLabel.TabIndex = 0;
            this.TokenLabel.Text = "Token";
            // 
            // DataPathLabel
            // 
            this.DataPathLabel.AutoSize = true;
            this.DataPathLabel.Location = new System.Drawing.Point(21, 52);
            this.DataPathLabel.Name = "DataPathLabel";
            this.DataPathLabel.Size = new System.Drawing.Size(52, 13);
            this.DataPathLabel.TabIndex = 1;
            this.DataPathLabel.Text = "DataPath";
            // 
            // TokenBox
            // 
            this.TokenBox.Location = new System.Drawing.Point(89, 12);
            this.TokenBox.Name = "TokenBox";
            this.TokenBox.Size = new System.Drawing.Size(315, 20);
            this.TokenBox.TabIndex = 2;
            // 
            // DataPathBox
            // 
            this.DataPathBox.Location = new System.Drawing.Point(89, 45);
            this.DataPathBox.Name = "DataPathBox";
            this.DataPathBox.Size = new System.Drawing.Size(315, 20);
            this.DataPathBox.TabIndex = 3;
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(507, 26);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(64, 23);
            this.RunBtn.TabIndex = 4;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // OpenBtn
            // 
            this.OpenBtn.Location = new System.Drawing.Point(411, 43);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(69, 23);
            this.OpenBtn.TabIndex = 5;
            this.OpenBtn.Text = "Open";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(592, 86);
            this.Controls.Add(this.OpenBtn);
            this.Controls.Add(this.RunBtn);
            this.Controls.Add(this.DataPathBox);
            this.Controls.Add(this.TokenBox);
            this.Controls.Add(this.DataPathLabel);
            this.Controls.Add(this.TokenLabel);
            this.Name = "Form1";
            this.Text = "Bot Starter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TokenLabel;
        private System.Windows.Forms.Label DataPathLabel;
        private System.Windows.Forms.TextBox TokenBox;
        private System.Windows.Forms.TextBox DataPathBox;
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.Button OpenBtn;
    }
}

