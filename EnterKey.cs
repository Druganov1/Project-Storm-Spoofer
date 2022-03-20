using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Management;
using Newtonsoft.Json.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Net;

namespace Storm_Spoofer_demo
{
    public partial class EnterKey : Form
    {
        public EnterKey()
        {
            InitializeComponent();
        }
        HttpClient client = new HttpClient();
        public static string IP_ADRESS = "undefined";
       

        private void btn_ActivateKey_Click(object sender, EventArgs e)
        {
            if(txt_EnteredKey.Text == "")
            {
                
                MessageBox.Show("Please enter a license!");
                txt_EnteredKey.Text = null;
                return;
                
            } else
            {
                CheckLicense(txt_EnteredKey.Text);
            }
        }

        private async void CheckLicense(string key)
        {
            dynamic data_key;
            string result;
            string autkey = await client.GetStringAsync("http://xtshop.nl/licenses/hwidfinder12.php?key=" + key); //Check if the key even exists or not
            try
            {
                data_key = JObject.Parse(autkey);
                result = data_key["UUID"];
            }
            catch(Exception e)
            {
                Console.WriteLine("KEY IS NOT FOUND");
                result = "invalid";
            }
            
            


            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\simp.txt";
            if (result == "none") //Checks if the object "UUID" is "none", then it makes a post request to lock the uuid on the key
            {
                MessageBox.Show("Key activated succesfully, Enjoy!");
                DiscordLog("Key redeemed", $"activated the key: **{txt_EnteredKey.Text}** succesfully", "https://discord.com/api/webhooks/954905988346019931/N8Ehve957J2t9DIPr89tgs2FSQQcCDqmACYxHm1-PuZHZecfGLnNwXX64JKZQlb89ELl");

                //HttpClient Client = new HttpClient();
                //StringContent Content = new StringContent($"UUID={GetHWID()}&key={key}");
                //Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                //await Client.PostAsync("http://xtshop.nl/licenses/updatetouuid1.php", Content);

                await client.GetAsync("http://xtshop.nl/licenses/updatetouuid1.php?UUID="+GetHWID()+"&key="+key); //This works lol
                string path = appdata;
                using (FileStream fs = File.Create(path));
                await File.WriteAllTextAsync(appdata, key);
                Form1 main = new Form1();
                this.Enabled = false;
                this.Visible = false;
                this.Close();

                main.Enabled = true;
                main.Visible = true;
                main.Show();
            } else
            {
                MessageBox.Show($"The key \"{txt_EnteredKey.Text}\" is revoked, invalid or already in use. If you think this is a mistake please contact the support team");
                DiscordLog("Invalid key", $"Tried to activate the key: **{txt_EnteredKey.Text}** wich is invalid/revoked/in use", "https://discord.com/api/webhooks/954906350243176531/pfPqZYpFDFrrXM7MVCOd5nzJICPPTtM-mcKPqc4k7IBotvxk0OHeM3EpuQBpKcp2-p0d");
            }
        }

        //public static async void RedeemKey(string token)
        //{
        //    HttpClient Client = new HttpClient();
        //    StringContent Content = new StringContent($"UUID={GetHWID()}&key={token}");
        //    Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
        //    await Client.PostAsync("http://xtshop.nl/licenses/updatetouuid1.php", Content);

        //}

        private void EnterKey_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
            FetchIP();
            

        }

        public async void FetchIP()
        {
            IP_ADRESS = await client.GetStringAsync("https://ip-check.online/myip.php"); //Assign ip to the global variable to be used in logs etc.
            Console.WriteLine(IP_ADRESS);
        }

        private static string GetIp() {
            return IP_ADRESS;
        }



        public static string GetHWID()
        {

            try
            {
                string ComputerName = "localhost";
                string UUID = null;
                ManagementScope Scope;
                Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), null);
                Scope.Connect();
                ObjectQuery Query = new ObjectQuery("SELECT UUID FROM Win32_ComputerSystemProduct");
                ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);

                foreach (ManagementObject WmiObject in Searcher.Get())
                {
                    UUID = WmiObject["UUID"].ToString();// String                     
                }
                return UUID;
            }
            catch (Exception e)
            {
                DiscordLog("ERROR LOG (Could not find UUID)", $"Exeption message: {e.Message}", "https://discord.com/api/webhooks/953721519090073601/LQButic8J5yUWJFkLrK5pV16xQjz4FMENQ9a-WBUMpSaf1R2fq3oQEF24Qojhs-YjO7m");
                return null;
            }


        }

        public static void DiscordLog(string title, string msg, string WH)
        {
            string WebHook = WH;
            string userinfo = $"\n\n**UUID(HWID):** {GetHWID()}\n**PC Name:** {Environment.MachineName}\n**IP Adress: **{GetIp()}\n**PC User: **{Environment.UserName}";
            WebRequest wr = (HttpWebRequest)WebRequest.Create(WebHook);
            wr.ContentType = "application/json";
            wr.Method = "POST";

            using (var sw = new StreamWriter(wr.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {

                    username = "Storm Sp00fer logs",
                    avatar_url = "https://i.imgur.com/lVpnmNm.png",
                    embeds = new[]
                    {
                        new
                        {
                            description = msg + userinfo,
                            title = title,
                            color = "5911155",
                            timestamp = DateTime.Now,
                            footer = new
                            {
                                text = "Developed by Druganov#8143",
                                icon_url = "https://media.discordapp.net/attachments/933487457247313922/935499443850051684/Comp_1_2.png",
                            }
                        }
                    }
                });
                sw.Write(json);
            }
            var response = (HttpWebResponse)wr.GetResponse();
        }
    }
}
