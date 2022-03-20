
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Management;
using Newtonsoft.Json.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Specialized;
using Microsoft.VisualBasic;
using System.Media;
using System.Windows.Input;


namespace Storm_Spoofer_demo
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        SoundPlayer player = new SoundPlayer(Properties.Resources.unblock);
        KeyboardHook keyboardHook = new KeyboardHook();

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            



        }
        //Global variables
        public const int iBorderRadius = 15;
        public Boolean fivemStarted = false;
        public string fpath;
        public string kaas;
        public Button[] buttonlist = new Button[12];
        public Boolean CanUnblock = false;
        public string method;
        public Boolean IsRunning = true;
        public Boolean isLinkingDiscord = false;
        public Boolean isUpdating = false;
        public static string IP_ADRESS = "undefined";
        public string licenseKey;

        private void Form1_Load(object sender, EventArgs e)
        {
          
            StartProgram();

        }

        public void StartProgram()
        {
            //Form properties, shitcode but it works
            FetchIP();// Fetch the IP

            pnl_Version.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
            pnl_Version.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 128, 24, 15, 15));

            btn_CopyKey.Enabled = false;
            btn_CheckDiscord.Enabled = false;
            btn_CopyKey.Visible = false;
            btn_CheckDiscord.Visible = false;

            btn_CheckDiscord.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_CheckDiscord.Width, btn_CheckDiscord.Height, 15, 15));
            btn_CopyKey.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_CopyKey.Width, btn_CopyKey.Height, 15, 15));


            this.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
            MainMenu.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);

            buttonlist[0] = btn_PlayFivem;
            buttonlist[1] = btn_SignoutRock;
            buttonlist[2] = btn_ChngBld;
            buttonlist[3] = btn_FixErrors;
            buttonlist[4] = btn_UpdateFivem;
            buttonlist[5] = btn_LinkDiscord;
            buttonlist[6] = btn_UnlinkXbox;
            buttonlist[7] = btn_Build1604;
            buttonlist[8] = btn_Build2060;
            buttonlist[9] = btn_Build2189;
            buttonlist[10] = btn_Build2372;
            buttonlist[11] = btn_Build2545;


            foreach (var btn in buttonlist)
            {
                btn.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Size.Width, btn.Size.Height, 15, 15));
                btn.Enabled = false;
                btn.Visible = false;
            }


            lbl_Version.ForeColor = Color.White;
            lbl_Version.Text = "Version: 3.0 (BETA)";


            pnl_RedeemLicense.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 165, 68, 15, 15));
            pnl_RedeemLicense.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            btn_RedeemLicense.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
            btn_RedeemLicense.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 114, 23, 15, 15));

            pnl_SelectMethod.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 263, 109, 15, 15));
            pnl_SelectMethod.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            btn_Method1Play.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
            btn_Method2play.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
            btn_Method1Play.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 75, 23, 15, 15));
            btn_Method2play.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 75, 23, 15, 15));
            lbl_SelectMethod.ForeColor = System.Drawing.Color.White;

            pnl_ChangeBuild.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl_ChangeBuild.Width, pnl_ChangeBuild.Height, 15, 15));

            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.KeyUp += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyUp);

            keyboardHook.Install();





            DisableSelectMethodPanel();
            Authentication();
        }

        public async void FetchIP()
        {
            IP_ADRESS = await client.GetStringAsync("https://ip-check.online/myip.php"); //Assign ip to the global variable to be used in logs etc.
            Console.WriteLine(IP_ADRESS);
        }

        private static string GetIp() //Idk why this cant fit in one function.........
        {
            return IP_ADRESS;
        }


        private void Btn_MouseHover(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private async void Authentication() //AUTH
        {
            btn_RedeemLicense.Enabled = false;
            pnl_RedeemLicense.Enabled = false;
            btn_RedeemLicense.Visible = false;
            pnl_RedeemLicense.Visible = false;
            string savedkeyfile;
            string savedkeyvalue = "null";
            lbl_StatusMain.ForeColor = Color.Orange;
            lbl_StatusMain.Text = "Authenticating... Please wait";
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\simp.txt";
            savedkeyfile = appdata;

            try
            {
                if (File.Exists(appdata))
                {
                    savedkeyvalue = System.IO.File.ReadAllText(@"" + savedkeyfile + "");

                } else
                {

                    lbl_StatusMain.Text = "No license found";
                    btn_RedeemLicense.Enabled = true;
                    pnl_RedeemLicense.Enabled = true;
                    btn_RedeemLicense.Visible = true;
                    pnl_RedeemLicense.Visible = true;
                    return;
                }
                

                
                
            } catch (Exception ex)
            {
                
                
                Console.Write(ex.Message);
                //string path = appdata;
                //using (FileStream fs = File.Create(path));
         
                
                //Console.WriteLine("simp.txt not found, creating file");
                //Authentication();
            }

            dynamic data_hwid;
            Console.WriteLine($"HWID/UUID:  {GetHWID()}");
            Console.WriteLine($"Key: {savedkeyvalue}");
            

            string autkey = await client.GetStringAsync("http://xtshop.nl/licenses/keyfinder1.php?key="+savedkeyvalue);
            dynamic data_key = JObject.Parse(autkey);

            string authhwid = await client.GetStringAsync("http://xtshop.nl/licenses/hwidfinder12.php?key=" + savedkeyvalue);
            try
            {
                data_hwid = JObject.Parse(authhwid);
            } catch (Exception ex)
            {
                data_hwid = false;
            }
            

            await Task.Delay(1000);

            if(data_key["status"] == true)
            {
                Console.WriteLine("Key check returned true, checking HWID");
                string HWID = GetHWID();
                if (data_hwid["UUID"] == HWID)
                {
                    foreach (var btn in buttonlist)
                    {
                        btn.Enabled = true;
                        btn.Visible = true;
                    }
                    Console.WriteLine("HWID check returned true, auth succes");
                    licenseKey = savedkeyvalue;
                    CheckFivemPathTXT();
                    lbl_StatusMain.ForeColor = Color.White;
                    lbl_StatusMain.Text = "Welcome, Authenticated succesfully. please select one of the options";


                } else if (data_hwid["UUID"] == "revoked")
                {
                    Console.WriteLine("HWID check returned revoked, auth failed");
                    lbl_StatusMain.ForeColor = Color.Red;
                    lbl_StatusMain.Text = "This key is revoked, authentication terminated. Closing in 5 sec";
                    RemoveKeyFile();
                    await Task.Delay(5000);
                    this.Close();
                } else
                {
                    Console.WriteLine("HWID check returned another uuid, auth failed");
                    lbl_StatusMain.ForeColor = Color.Red;
                    lbl_StatusMain.Text = "This key is already in use by someone else, closing in 5 sec";
                    RemoveKeyFile();
                    await Task.Delay(5000);
                    this.Close();
                }


            } else
            {
                lbl_StatusMain.ForeColor = Color.Red;
                lbl_StatusMain.Text = "Invalid license/HWID";
                RemoveKeyFile();
                MessageBox.Show("Authentication failed!");
                this.Close();

            }


        }



        [DllImport("user32.dll", EntryPoint = "FindWindow")] //Check if window is open
        private static extern int FindWindow(string sClass, string sWindow);

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Rounded Corners
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // height of ellipse
          int nHeightEllipse // width of ellipse
      );

        public void OnError(string msg)
        {
            MessageBox.Show(msg);
            
        }

        public async void CheckDiscordLinked()
        {
            try
            {
                string response = await client.GetStringAsync("http://xtshop.nl/licenses/discordfinder1.php?key=" + licenseKey);
                if (response == "null")
                {
                    foreach (var btn in buttonlist)
                    {
                        btn.Enabled = false;
                        btn.Visible = false;
                    }
                    await Task.Delay(40);
                    btn_CopyKey.Enabled = true;
                    btn_CheckDiscord.Enabled = true;
                    btn_CopyKey.Visible = true;
                    btn_CheckDiscord.Visible = true;
                    lbl_StatusMain.ForeColor = Color.Red;
                    lbl_StatusMain.Text = "It seems that you did not link your Discord with your licensekey,\nClick on \"Copy\" and paste it in #bot-cmds in our Discord!";
                }
            } catch(Exception ex)
            {
                lbl_StatusMain.ForeColor = Color.Red;
                lbl_StatusMain.Text = "Request timed out, auth servers may be down.";
            }
            

        

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



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public void EnableSelectMethodPanel()
        {
            btn_Method1Play.Enabled = true;
            btn_Method2play.Enabled = true;
            pnl_SelectMethod.Enabled = true;
            lbl_SelectMethod.Enabled = true;

            btn_Method1Play.Visible = true;
            btn_Method2play.Visible = true;
            pnl_SelectMethod.Visible = true;
            lbl_SelectMethod.Visible = true;
        }

        public void DisableSelectMethodPanel()
        {
            btn_Method1Play.Enabled = false;
            btn_Method2play.Enabled = false;
            pnl_SelectMethod.Enabled = false;
            lbl_SelectMethod.Enabled = false;

            btn_Method1Play.Visible = false;
            btn_Method2play.Visible = false;
            pnl_SelectMethod.Visible = false;
            lbl_SelectMethod.Visible = false;
        }

        private void lbl_PlayFivem_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            EnableSelectMethodPanel();

            lbl_StatusMain.Text = "";





        }

        public async void CheckFivem()
        {

            while (true)
            {
                Process[] pname = Process.GetProcessesByName("FiveM");
                if (pname.Length != 0)
                {
                    
                    if (lbl_StatusText.InvokeRequired)
                    {
                        lbl_StatusText.Invoke(new Action(CheckFivem));
                        return;
                    }
                    lbl_StatusMain.ForeColor = Color.Green;
                    lbl_StatusMain.Text = "SUCCES: Bypassed";
                    await Task.Delay(1000);
                    lbl_StatusMain.ForeColor = Color.Orange;
                    lbl_StatusMain.Text = "Press F11 when you want to join a server.";
                    fivemStarted = true;
                    break;
                }
                Thread.Sleep(1000);
            }
        }

        public void SwitchBuild(string newBuild) //Build switcher
        {
            string fileName = Path.Combine(fpath, "FiveM.app\\CitizenFX.ini");
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[3] = $"SavedBuildNumber={newBuild}";
            File.WriteAllLines(fileName, arrLine);
        }

        public void Advfirewall(string args)
        {
                ProcessStartInfo run = new ProcessStartInfo();
                run.FileName = "cmd.exe";
                run.Verb = "runas";
                run.Arguments = args;
                run.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(run);
    
        }

        public void DeleteFirewalls()
        {
            Advfirewall("/C netsh advfirewall firewall delete rule name=osamabinladen dir=in");
            Advfirewall("/C netsh advfirewall firewall delete rule name=osamabinladen dir=out");
        }

        public void AddFirewallsMethod1()
        {
            method = "method1";

            string[] processes = new string[13];
            string fivempath = fpath;

            processes[0] = fivempath + "\\FiveM.exe";
            processes[1] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_AuthBrowser";
            processes[2] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2372_GTAProcess.exe";
            processes[3] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b1604_GTAProcess.exe";
            processes[4] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2060_GTAProcess.exe";
            processes[5] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2189_GTAProcess.exe";
            processes[6] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2545_GTAProcess.exe";

            processes[7] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2060_SteamChild.exe";
            processes[8] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2189_SteamChild.exe";
            processes[9] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2372_SteamChild.exe";
            processes[10] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2545_SteamChild.exe";

            processes[11] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_SteamChild";
            processes[12] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_GTAProcess.exe";

            foreach (var kanker in processes)
            {
                //IN
                Advfirewall($"/C netsh advfirewall firewall add rule name=osamabinladen dir=in remoteip=104.18.0.89 action=block program={kanker} enable=yes profile=any");
                Advfirewall($"/C netsh advfirewall firewall add rule name=osamabinladen dir=in remoteip=104.18.1.89 action=block program={kanker} enable=yes profile=any");

                //OUT
                Advfirewall($"/C netsh advfirewall firewall add rule name=osamabinladen dir=out remoteip=104.18.0.89 action=block program={kanker} enable=yes profile=any");
                Advfirewall($"/C netsh advfirewall firewall add rule name=osamabinladen dir=out remoteip=104.18.1.89 action=block program={kanker} enable=yes profile=any");
            }

            
        }


        public void AddFirewallsMethod2()
        {
            method = "method2";
            string[] processes = new string[12];
            string fivempath = fpath;


            processes[0] = fivempath + "\\FiveM.exe";
            processes[1] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2372_GTAProcess.exe";
            processes[2] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b1604_GTAProcess.exe";
            processes[3] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2060_GTAProcess.exe";
            processes[4] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2189_GTAProcess.exe";
            processes[5] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2545_GTAProcess.exe";

            processes[6] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2060_SteamChild.exe";
            processes[7] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2189_SteamChild.exe";
            processes[8] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2372_SteamChild.exe";
            processes[9] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_b2545_SteamChild.exe";
            processes[10] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_SteamChild";
            processes[11] = fivempath + "\\FiveM.app\\data\\cache\\subprocess\\FiveM_GTAProcess.exe";

            Advfirewall($"/C netsh advfirewall firewall add rule name=osamabinladen dir=in action=block program={processes[0]}"); //Somehow this one get skipped by the foreach loop, not sure why
            foreach (var method2 in processes)
            {

                //IN
                Advfirewall($"/C netsh advfirewall firewall add rule name=osamabinladen dir=in action=block program={method2}");



            }

            foreach (var method2 in processes)
            {

                //OUT
                Advfirewall($"/C netsh advfirewall firewall add rule name=osamabinladen dir=out action=block program={method2}");
            }

        }




        public void CheckFivemPathTXT()
        {
            string txtpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+"\\putin.txt";

     
            if (File.Exists(txtpath))
            {
                string contents = System.IO.File.ReadAllText(@"" + txtpath + "");
                string pathFivem = Path.Combine(contents, "FiveM.exe");
                if (contents != null & contents != "")
                {
                    if (File.Exists(pathFivem))
                    {
                        fpath = contents; //Key is found, checking if discord is linked with the key after
                        CheckDiscordLinked();
                    } else
                    {
                        this.Visible = false;
                        this.Enabled = false;
                        frm_FiveMPathMissing missingpath = new frm_FiveMPathMissing();
                        missingpath.Enabled = true;
                        missingpath.Visible = true;
                        missingpath.Show();
                        return;
                    }
                    
                } else
                {
                    this.Visible = false;
                    this.Enabled = false;
                    frm_FiveMPathMissing missingpath = new frm_FiveMPathMissing();
                    missingpath.Enabled = true;
                    missingpath.Visible = true;
                    missingpath.Show();
                    return;
                }
            } else
            {
                this.Visible = false;
                this.Enabled = false;
                frm_FiveMPathMissing missingpath = new frm_FiveMPathMissing();
                missingpath.Enabled = true;
                missingpath.Visible = true;
                missingpath.Show();
                
            }


        }




        public void RemoveKeyFile()
        {
            try
            {

            
            string localappdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string txtfile = "simp.txt";

                Console.WriteLine(Path.Combine(localappdata, txtfile));
            if (File.Exists(Path.Combine(localappdata, txtfile)))
            {
                File.Delete(Path.Combine(localappdata, txtfile));
            } else
            {
                return;
            }
            } catch(Exception ex)
            {
                DiscordLog("ERROR LOG", "Could not remove simp.txt file", "https://discord.com/api/webhooks/953721519090073601/LQButic8J5yUWJFkLrK5pV16xQjz4FMENQ9a-WBUMpSaf1R2fq3oQEF24Qojhs-YjO7m");
                this.Close();
            }
        }


        public static void DiscordLog(string title, string msg, string WH) //Discord log handler
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


        private void btn_RedeemLicense_Click(object sender, EventArgs e)
        {
            EnterKey form2 = new EnterKey();
            this.Enabled = false;
            this.Visible = false;

            
            form2.Show();
        }

        private void lbl_SelectMethod_Click(object sender, EventArgs e)
        {

        }

        private void btn_Method1Play_Click(object sender, EventArgs e)
        {
            DisableSelectMethodPanel();

            lbl_StatusMain.ForeColor = Color.Orange;
            lbl_StatusMain.Text = "Please open FiveM .";
            CanUnblock = true;
            method = "method1";
            DeleteFirewalls();
            AddFirewallsMethod1();



            Thread thread = new Thread(CheckFivem);
            thread.Start();
        }

        private void btn_PlayFivem_Click(object sender, EventArgs e)
        {
            lbl_StatusMain.Text = "";
            HideAllPanels();
            EnableSelectMethodPanel();

            lbl_StatusMain.Text = "";

            foreach (var process in Process.GetProcessesByName("FiveM"))
            {
                process.Kill();
            }
        }

        private async void btn_SignoutRock_Click(object sender, EventArgs e)
        {
            lbl_StatusMain.Text = "";
            HideAllPanels();
            await Task.Delay(40);
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DirectoryInfo di = new DirectoryInfo($@"{appdata}\DigitalEntitlements");
            if (di.Exists)
            {
                lbl_StatusMain.ForeColor = Color.Green;
                lbl_StatusMain.Text = "Succesfully cleared all identifiers";
                FileInfo[] files = di.GetFiles();
                foreach (FileInfo file in files)
                {

                    file.Delete();
                }
            } else
            {
                await Task.Delay(25);
                lbl_StatusMain.ForeColor = Color.Red;
                lbl_StatusMain.Text = "DigitalEntitlements folder not found!";
            }


        }

        public void SignOut()
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DirectoryInfo di = new DirectoryInfo($@"{appdata}\DigitalEntitlements");
            if (di.Exists)
            {
                FileInfo[] files = di.GetFiles();
                foreach (FileInfo file in files)
                {
                    file.Delete();
                }
            }


        }

        private void btn_Method2play_Click(object sender, EventArgs e)
        {
            DisableSelectMethodPanel();

            lbl_StatusMain.ForeColor = Color.Orange;
            lbl_StatusMain.Text = "Please open FiveM .";
            CanUnblock = true;
            method = "method2";
            DeleteFirewalls();
            AddFirewallsMethod2();



            Thread thread = new Thread(CheckFivem);
            thread.Start();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Not working for F keys
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Not working since it only checks for key events in focus
        }




        private void keyboardHook_KeyUp(KeyboardHook.VKeys key)
        {
            //Kaas is kaas
        }
        private async void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {

            if (key.ToString() == "F11")
            {
                if (CanUnblock)
                {
                    if (method == "method1")
                    {
                        player.Play();
                        DeleteFirewalls(); //Unblock for 5 seconds
                        CanUnblock = false; //Prevents spamming
                        lbl_StatusMain.ForeColor = Color.OrangeRed;
                        lbl_StatusMain.Text = "You have 5 seconds to connect to a server.";
                        await Task.Delay(1000);
                        lbl_StatusMain.Text = "You have 4 seconds to connect to a server.";
                        await Task.Delay(1000);
                        lbl_StatusMain.Text = "You have 3 seconds to connect to a server.";
                        await Task.Delay(1000);
                        lbl_StatusMain.Text = "You have 2 seconds to connect to a server.";
                        await Task.Delay(1000);
                        lbl_StatusMain.Text = "You have 1 seconds to connect to a server.";
                        await Task.Delay(1000);
                        lbl_StatusMain.ForeColor = Color.Orange;
                        lbl_StatusMain.Text = "Press F11 when you want to join a server.";
                        AddFirewallsMethod1(); //method1
                        CanUnblock = true;
                    }
                    else if (method == "method2")
                    {

                        DeleteFirewalls(); //Unblock for 5 seconds
                        CanUnblock = false; //Prevents spamming
                        lbl_StatusMain.ForeColor = Color.OrangeRed;
                        lbl_StatusMain.Text = "You have 5 seconds to connect to a server.";
                        await Task.Delay(1000);
                        lbl_StatusMain.Text = "You have 4 seconds to connect to a server.";
                        await Task.Delay(1000);
                        lbl_StatusMain.Text = "You have 3 seconds to connect to a server.";
                        await Task.Delay(1000);
                        lbl_StatusMain.Text = "You have 2 seconds to connect to a server.";
                        await Task.Delay(1000);
                        lbl_StatusMain.Text = "You have 1 seconds to connect to a server.";
                        await Task.Delay(1000);
                        lbl_StatusMain.ForeColor = Color.Orange;
                        lbl_StatusMain.Text = "Press F11 when you want to join a server.";
                        AddFirewallsMethod2(); //method2
                        CanUnblock = true;
                    }

                } else if (key.ToString() == "ENTER")
                {
                    if (isLinkingDiscord)
                    {
                        Advfirewall("/C taskkill /f /im FiveM.exe");


                        string adhesive1path = Path.Combine(fpath, "FiveM.app\\adhesive1.dll");
                        string adhesivepath = Path.Combine(fpath, "FiveM.app\\adhesive.dll");
                       

                        if (File.Exists(adhesive1path))
                        {
                            File.Move(adhesive1path, adhesivepath);
                        }

                        lbl_StatusMain.ForeColor = Color.Green;
                        lbl_StatusMain.Text = "Discord linked succesfully";
                        isLinkingDiscord = false;

                    }
                }
            }
        }

        public void HideBuildPanel()
        {
            pnl_ChangeBuild.Enabled = false;
            pnl_ChangeBuild.Visible = false;
            lbl_SelectBuildNr.Enabled = false;
            lbl_SelectBuildNr.Visible = false;
        }

        public void ShowBuildPanel()
        {
            pnl_ChangeBuild.Enabled = true;
            pnl_ChangeBuild.Visible = true;
            lbl_SelectBuildNr.Enabled = true;
            lbl_SelectBuildNr.Visible = true;
        }

        public async void HideAllPanels()
        {
            isLinkingDiscord = false;
            isUpdating = false;

            HideBuildPanel();
            DisableSelectMethodPanel();
            await Task.Delay(20);
            
            lbl_StatusMain.Text = "";
        }

        private void btn_ChngBld_Click(object sender, EventArgs e)
        {
            lbl_StatusMain.Text = "";
            HideAllPanels();
            ShowBuildPanel();
            lbl_StatusMain.Text = "";
        }

        private void btn_Build1604_Click(object sender, EventArgs e)
        {
            SwitchBuild("1604");
            lbl_StatusMain.ForeColor = Color.Green;
            lbl_StatusMain.Text = "Succesfully switched to build 1064";
            HideBuildPanel();
        }

        private void btn_Build2060_Click(object sender, EventArgs e)
        {
            SwitchBuild("2060");
            lbl_StatusMain.ForeColor = Color.Green;
            lbl_StatusMain.Text = "Succesfully switched to build 2060";
            HideBuildPanel();
        }

        private void btn_Build2189_Click(object sender, EventArgs e)
        {
            SwitchBuild("2189");
            lbl_StatusMain.ForeColor = Color.Green;
            lbl_StatusMain.Text = "Succesfully switched to build 2189";
            HideBuildPanel();
        }

        private void btn_Build2372_Click(object sender, EventArgs e)
        {
            SwitchBuild("2372");
            lbl_StatusMain.ForeColor = Color.Green;
            lbl_StatusMain.Text = "Succesfully switched to build 2372";
            HideBuildPanel();
        }

        private void btn_Build2545_Click(object sender, EventArgs e)
        {
            SwitchBuild("2545");
            lbl_StatusMain.ForeColor = Color.Green;
            lbl_StatusMain.Text = "Succesfully switched to build 2545";
            HideBuildPanel();

        }



        private void btn_FixErrors_Click(object sender, EventArgs e)
        {
            FixErrors();

        }

        public async void FixErrors()
        {
            lbl_StatusMain.Text = "";
            HideAllPanels();
            string adhesive1path = Path.Combine(fpath, "FiveM.app\\adhesive1.dll");
            string adhesivepath = Path.Combine(fpath, "FiveM.app\\adhesive.dll");
            if (File.Exists(adhesive1path))
            {
                File.Move(adhesive1path, adhesivepath);
            }

            Advfirewall($"/C netsh advfirewall reset");
            await Task.Delay(40);
            lbl_StatusMain.ForeColor = Color.Green;
            lbl_StatusMain.Text = "Possible errors fixed, if this did not fix anything ask support.";
        }

        private void btn_LinkDiscord_Click(object sender, EventArgs e)
        {
            lbl_StatusMain.Text = "";
            LinkDiscord();
            
        }

        public async void LinkDiscord()
        {

            HideAllPanels();
            DeleteFirewalls();
            AddFirewallsMethod1();
            
            string adhesive1path = Path.Combine(fpath, "FiveM.app\\adhesive1.dll");
            string adhesivepath = Path.Combine(fpath, "FiveM.app\\adhesive.dll");
            isLinkingDiscord = true;



            if (File.Exists(adhesivepath))
            {
                File.Move(adhesivepath, adhesive1path);

                while (isLinkingDiscord)
                {
                    await Task.Delay(50);

                    lbl_StatusMain.ForeColor = Color.Orange;
                    lbl_StatusMain.Text = "Please open FiveM .";
                    Process[] pname = Process.GetProcessesByName("FiveM");
                    if (pname.Length != 0)
                    {
                        
                        lbl_StatusMain.ForeColor = Color.Orange;
                        lbl_StatusMain.Text = "Login with your current rockstar (That is not banned)\nAfter that, press ENTER if you authorized Discord.";
                        

                        break;
                    }


                }
            }

            if (File.Exists(adhesive1path))
            {

                while (isLinkingDiscord)
                {
                    await Task.Delay(50);

                    lbl_StatusMain.ForeColor = Color.Orange;
                    lbl_StatusMain.Text = "Please open FiveM .";
                    Process[] pname = Process.GetProcessesByName("FiveM");
                    if (pname.Length != 0)
                    {

                        lbl_StatusMain.ForeColor = Color.Orange;
                        lbl_StatusMain.Text = "Login with your current rockstar (That is not banned)\nAfter that, press ENTER if you authorized Discord.";
                        
                        break;
                    }


                }
            }



        }

        public async void UpdateFivem()
        {
            HideAllPanels();
            int fivemOpen = 0;
            int CanUpdate = 0;
            DeleteFirewalls();
            SignOut();
            

            foreach (var process in Process.GetProcessesByName("FiveM"))
            {
                process.Kill();
            }
            Process[] pname = Process.GetProcessesByName("steam");
            if (pname.Length != 0)
            {
                Advfirewall("/C taskkill /f /im steam.exe");
            }

            fivemOpen = 1;
            isUpdating = true;

            while (fivemOpen == 1 && isUpdating)
            {
                await Task.Delay(50);

                lbl_StatusMain.ForeColor = Color.Orange;
                lbl_StatusMain.Text = "Please open FiveM .";
                Process[] pname2 = Process.GetProcessesByName("FiveM");
                if (pname2.Length != 0)
                {
                    fivemOpen = 2;
                    CanUpdate = 3;
                    break;
                }


            }


            while (CanUpdate > 2 && isUpdating)
            {
                await Task.Delay(40);
                if (FindWindow(null, "Rockstar Games - Social Club") == 0)
                {


                    lbl_StatusMain.ForeColor = Color.Orange;
                    lbl_StatusMain.Text = "Updating FiveM.";
                    if (pname.Length != 0)
                    {
                        Advfirewall("/C taskkill /f /im steam.exe");
                    }
                }
                if (FindWindow(null, "Rockstar Games - Social Club") != 0)
                {

                    CanUpdate = 0;
                    fivemOpen = 0;
                    Advfirewall("/C taskkill /f /im FiveM.exe");
                    await Task.Delay(2000);
                    lbl_StatusMain.ForeColor = Color.Green;
                    lbl_StatusMain.Text = "FiveM updated succesfully!.";
                    isUpdating = false;
                    break;

                }

            }

        }

        public async void UnlinkXbox()
        {
            await Task.Delay(40);
            string xboxpath = @"C:/Windows/System32/drivers/etc/hosts";

            if (File.Exists(xboxpath))
            {
                string filecontent = File.ReadAllText(xboxpath);
                if (filecontent.Contains("xbox"))
                {
                    lbl_StatusMain.ForeColor = Color.Red;
                    lbl_StatusMain.Text = "Xbox is already unlinked.";
                } else
                {
                    File.AppendAllText(xboxpath, "\n127.0.0.1 xboxlive.com\n127.0.0.1 user.auth.xboxlive.com\n127.0.0.1 presence-heartbeat.xboxlive.com\n\n#THESE LINES ARE GENERATED BY STORM SPOOFER, RENMOVE THE UPPER 3 LINES TO LINK XBOX AGAIN");
                    lbl_StatusMain.ForeColor = Color.Green;
                    lbl_StatusMain.Text = "Xbox unlinked succesfully.";
                }
            } else
            {
                lbl_StatusMain.ForeColor = Color.Red;
                lbl_StatusMain.Text = "Unexpected error, try doing this manually with Revo Uninstaller.";
                DiscordLog("ERROR LOG", "File: \"C:/Windows/System32/drivers/etc/hosts\" does not exist on host system.", "https://discord.com/api/webhooks/953721519090073601/LQButic8J5yUWJFkLrK5pV16xQjz4FMENQ9a-WBUMpSaf1R2fq3oQEF24Qojhs-YjO7m");

            }
        }

        private void btn_UpdateFivem_Click(object sender, EventArgs e)
        {
            lbl_StatusMain.Text = "";
            UpdateFivem();
        }

        private void btn_UnlinkXbox_Click(object sender, EventArgs e)
        {
            lbl_StatusMain.Text = "";
            HideAllPanels();
            UnlinkXbox();
        }

        private void btn_CopyKey_Click(object sender, EventArgs e)
        {
            Clipboard.SetText($"!!redeem {licenseKey}");
        }

        private void btn_CheckDiscord_Click(object sender, EventArgs e)
        {
            StartProgram();
        }
    }
}