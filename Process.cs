using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using View;

namespace ProcessManager
{
    public static class Openssl
    {
        public static void Create(string Args, GroupBox vGP)
        {
            Common.ValidateControls(vGP);

            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "openssl";
                process.StartInfo.Arguments = Args;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string Errors = process.StandardError.ReadToEnd();
                process.WaitForExit();

                MessageBox.Show($"--------------- Out ---------------\n\n{(string.IsNullOrEmpty(output) ? (string.IsNullOrEmpty(Errors) ? "Operation Success" : Errors) : output)}", "MSG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void InstallationCheckup(Label Status, TableLayoutPanel Body)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "openssl";
                process.StartInfo.Arguments = "version";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrEmpty(output))
                {
                    Status.Text = $"Openssl is installed => Version : {output}";
                    Status.ForeColor = Color.Green;
                    Body.Enabled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Status.Text = $"Openssl is not installed or not accessible";
            Status.ForeColor = Color.Red;
        }
    }
}
