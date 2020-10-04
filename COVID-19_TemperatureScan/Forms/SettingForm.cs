using System;
using System.Configuration;
using System.Windows.Forms;

namespace COVID_19_TemperatureScan
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            var mode = cmbMode.Text;
            var tempStart = numStart.Value;
            var tempFinish = numFinish.Value;

            if (string.IsNullOrEmpty(mode))
            {
                MessageBox.Show("Mode shouldn't be Null", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var confCollection = configManager.AppSettings.Settings;
            confCollection["Mode"].Value = mode;

            this.DialogResult = DialogResult.Abort;

            if (tempStart >= tempFinish)
            {
                MessageBox.Show("The end temperature cannot be greater than or equal to the start temperature.", "Error", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            confCollection["TempStart"].Value = ((int)tempStart).ToString();
            confCollection["TempFinish"].Value = ((int)tempFinish).ToString();
            configManager.Save();
            ConfigurationManager.RefreshSection("appSettings");
            this.DialogResult = DialogResult.OK;
        }
    }
}
