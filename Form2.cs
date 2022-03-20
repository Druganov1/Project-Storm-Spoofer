using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Storm_Spoofer_demo
{
    public partial class frm_FiveMPathMissing : Form
    {
        public frm_FiveMPathMissing()
        {
            InitializeComponent();
        }
        public static class GlobalFivemPath
        {
            public static string MaybePath;
        }

        private void txt_InputFivemPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_FivemPathCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void btn_FivemPathOK_Click(object sender, EventArgs e)
        {
            try
               
            {
                if (txt_InputFivemPath.Text != "")
                {
                    Form1 main = new Form1();
                    string pathFivem = Path.Combine(txt_InputFivemPath.Text, "FiveM.exe");

                    Console.WriteLine(pathFivem);
                    Console.WriteLine(File.Exists(pathFivem));

                    if (File.Exists(pathFivem))
                    {
                        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                        string textFile = Path.Combine(appdata, "putin.txt");
                        using (FileStream fs = File.Create(textFile));
                        await File.WriteAllTextAsync(textFile, txt_InputFivemPath.Text);
                        MessageBox.Show("Path set succesfully, restart the application please");

                        Environment.Exit(0);
                    } else
                    {
                        MessageBox.Show("Please put in a valid FiveM path!");
                        return;
                    }
                } else
                {
                    MessageBox.Show("Please put in a valid FiveM path!");
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error");
                txt_InputFivemPath.Text = "";
            }

        }

        private void frm_FiveMPathMissing_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
