namespace COVID_19_TemperatureScan
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.numStart = new System.Windows.Forms.NumericUpDown();
            this.bSave = new System.Windows.Forms.Button();
            this.numFinish = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFinish)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMode
            // 
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "Averaging Method",
            "Maximum Method",
            "Interlacing Method",
            "Interlacing Maximum Method",
            "Threshold Method"});
            this.cmbMode.Location = new System.Drawing.Point(62, 94);
            this.cmbMode.Margin = new System.Windows.Forms.Padding(6);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(250, 41);
            this.cmbMode.TabIndex = 0;
            // 
            // numStart
            // 
            this.numStart.Location = new System.Drawing.Point(87, 195);
            this.numStart.Margin = new System.Windows.Forms.Padding(6);
            this.numStart.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numStart.Minimum = new decimal(new int[] {
            70,
            0,
            0,
            -2147483648});
            this.numStart.Name = "numStart";
            this.numStart.Size = new System.Drawing.Size(77, 39);
            this.numStart.TabIndex = 1;
            // 
            // bSave
            // 
            this.bSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSave.Location = new System.Drawing.Point(89, 306);
            this.bSave.Margin = new System.Windows.Forms.Padding(6);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(179, 57);
            this.bSave.TabIndex = 3;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // numFinish
            // 
            this.numFinish.Location = new System.Drawing.Point(207, 195);
            this.numFinish.Margin = new System.Windows.Forms.Padding(6);
            this.numFinish.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numFinish.Minimum = new decimal(new int[] {
            70,
            0,
            0,
            -2147483648});
            this.numFinish.Name = "numFinish";
            this.numFinish.Size = new System.Drawing.Size(73, 39);
            this.numFinish.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "Image Fusion Mode:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "Temperature Between";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 33);
            this.label3.TabIndex = 7;
            this.label3.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 33);
            this.label4.TabIndex = 8;
            this.label4.Text = "°C";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 398);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numFinish);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.numStart);
            this.Controls.Add(this.cmbMode);
            this.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(390, 445);
            this.MinimumSize = new System.Drawing.Size(390, 445);
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFinish)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.NumericUpDown numStart;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.NumericUpDown numFinish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}