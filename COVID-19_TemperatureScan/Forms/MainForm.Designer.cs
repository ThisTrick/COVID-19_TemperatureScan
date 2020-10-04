namespace COVID_19_TemperatureScan
{
    partial class MainForm
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
            this.pInputs = new System.Windows.Forms.Panel();
            this.pbTemp = new System.Windows.Forms.PictureBox();
            this.pbRgb = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.pInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRgb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pInputs
            // 
            this.pInputs.Controls.Add(this.pbTemp);
            this.pInputs.Controls.Add(this.pbRgb);
            this.pInputs.Dock = System.Windows.Forms.DockStyle.Left;
            this.pInputs.Location = new System.Drawing.Point(0, 0);
            this.pInputs.Name = "pInputs";
            this.pInputs.Size = new System.Drawing.Size(272, 523);
            this.pInputs.TabIndex = 0;
            // 
            // pbTemp
            // 
            this.pbTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbTemp.Location = new System.Drawing.Point(0, 249);
            this.pbTemp.Name = "pbTemp";
            this.pbTemp.Size = new System.Drawing.Size(272, 274);
            this.pbTemp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTemp.TabIndex = 1;
            this.pbTemp.TabStop = false;
            this.pbTemp.DoubleClick += new System.EventHandler(this.pbTemp_DoubleClick);
            // 
            // pbRgb
            // 
            this.pbRgb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRgb.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbRgb.Location = new System.Drawing.Point(0, 0);
            this.pbRgb.Name = "pbRgb";
            this.pbRgb.Size = new System.Drawing.Size(272, 249);
            this.pbRgb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRgb.TabIndex = 1;
            this.pbRgb.TabStop = false;
            this.pbRgb.DoubleClick += new System.EventHandler(this.pbRgb_DoubleClick);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(272, 467);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(494, 56);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pbResult
            // 
            this.pbResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbResult.Location = new System.Drawing.Point(272, 0);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(494, 467);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbResult.TabIndex = 2;
            this.pbResult.TabStop = false;
            this.pbResult.DoubleClick += new System.EventHandler(this.pbResult_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 523);
            this.Controls.Add(this.pbResult);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pInputs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "COVID-19_TemperatureScan";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pInputs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRgb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pInputs;
        private System.Windows.Forms.PictureBox pbTemp;
        private System.Windows.Forms.PictureBox pbRgb;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pbResult;
    }
}

