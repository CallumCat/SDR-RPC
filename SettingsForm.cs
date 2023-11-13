using SDRSharp.Radio;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EnderIce2.SDRSharpPlugin
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            textBox1.Text = Utils.GetStringSetting("ClientID");
            checkBox1.Checked = Utils.GetBooleanSetting("LogRPC", false);
        }

        private void Button1_Click(object sender, EventArgs e) => Close();

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e) => Utils.SaveSetting("LogRPC", checkBox1.Checked);

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox1.Text.Replace(" ", "").Replace("\n", "").Replace("\r", "");
            if (!int.TryParse(textBox1.Text, out _) || textBox1.Text.Length != 18)
            {
                MessageBox.Show("Invalid Client ID!");
            }
            Utils.SaveSetting("ClientID", textBox1.Text);
            label1.Text = $"Configuration Updated.\nNew ID: {Utils.GetStringSetting("ClientID")}";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Utils.SaveSetting("ClientID", "765213507321856078");
            textBox1.Text = "765213507321856078";
        }
    }
}
