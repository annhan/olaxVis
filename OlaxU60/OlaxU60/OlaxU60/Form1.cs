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
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Management;

namespace OlaxU60
{
    public partial class Form1 : Form
    {
        string[] listIP = { "", "", "", "", "", "", "", "", "", "" };
        int numberIP = 0;
        string typeapn = "";
        int dem = 0;
        int nhamang = 0; // 0 -mobi , 1- viettel, 2 vina
        public Form1()
        {
            InitializeComponent();
            getlistcard();
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("Mobifone");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private static void Initialize()
        {
        }
        private async Task getmyIp()
        {
            Initialize();
            int kq = 0;
            var url = "https://api.myip.com";

            var request = WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 1000;
            string data = "";
            try
            {
                var webResponse = request.GetResponse();
                var webStream = webResponse.GetResponseStream();
                var reader = new StreamReader(webStream);
                data = reader.ReadToEnd();
            }
            catch (Exception e)
            {

                resultCheckIP.Text = "Khong Connect";
                resultCheckIP.BackColor = Color.Red;
                //MessageBox.Show("Done - Check IP Again");
                return;
            }
            
            dynamic json = JsonConvert.DeserializeObject(data);
            //dataGet.ResetText();
            listIP[numberIP] = json["ip"].ToString();
            dataGet.ResetText();
            dataGet.AppendText("IP Hien Tai: ");
            dataGet.AppendText(json["ip"].ToString());
            dataGet.AppendText("\r\n");
            dataGet.AppendText("\r\n");
            for (int i = 0; i < 10; i++)
            {
                dataGet.AppendText(i.ToString());
                dataGet.AppendText(" : ");
                if (i == numberIP)
                {
                    dataGet.AppendText("vi tri IP hien Tai");
                }
                else
                {
                    dataGet.AppendText(listIP[i]);
                    if (String.Equals(listIP[i], listIP[numberIP]))
                    {
                        kq = 1;
                    }

                }
                dataGet.AppendText("\r\n");
            }
            numberIP++;
            if (numberIP > 9)
            {
                numberIP = 0;
            }
            resultCheckIP.ResetText();
            string text = "";
            if (kq == 0)
            {
                resultCheckIP.BackColor = Color.LightGreen;
                text= "Done -OK";
                resultCheckIP.Text = "OK";
            }
            else
            {
                text = "Done - Trung IP";
                resultCheckIP.Text = "Trung IP";
                resultCheckIP.BackColor = Color.Red;
            }
            //MessageBox.Show(text);

        }
        private void resetOlaxData()
        {
            

            //string result = response.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(result);
        }
        private void resetOlax_Click(object sender, EventArgs e)
        {
            var values = new Dictionary<string, string>
            {
                { "goformId", "REBOOT_DEVICE" }
            };

            var data = new FormUrlEncodedContent(values);

            var url = "http://192.168.0.1/goform/goform_set_cmd_process";
            var client = new HttpClient();

            var response = client.PostAsync(url, data);
        }

    

        static void Enable(string interfaceName)
        {
            System.Diagnostics.ProcessStartInfo psi =
                   new System.Diagnostics.ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" enable");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();
            /*
            Process cmd = new Process();
            string cmdline = String.Format("netsh interface set interface \" {0} \" enable", interfaceName);
            MessageBox.Show(cmdline);
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.Arguments = cmdline;
            cmd.Start();
            cmd.WaitForExit();
            */
        }

        static void Disable(string interfaceName)
        {
            System.Diagnostics.ProcessStartInfo psi =
                new System.Diagnostics.ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();
        }
        static void restartnetwork(string nameintefaces)
        {

        }
        private void getlistcard()
        {
            namenetwork.Items.Clear();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up)
                {             
                    if (ni.Name.Contains("Ethernet"))
                    {namenetwork.Items.Add(ni.Name);}
                }
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            getlistcard();
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            //TextBox t = (TextBox)namecard;
            string namecard1 = this.namenetwork.Text;// namecard.Text;
            if(namecard1 == "")
            {
                statusreset.Text = "Chua Chon card mạng";
            }
            else
            {
                Disable(namecard1);
                //System.Threading.Thread.Sleep(5000);
                Enable(namecard1);
                await sleepT(1000);
                await getmyIp();
            }

        }

        public async Task sleepT(int timems)
        {
            System.Threading.Thread.Sleep(timems);
        }
        public async Task<string> checkmode()
        {
            string URL = "http://192.168.8.1/reqproc/proc_get?cmd=apn_mode";
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
            /*
                HttpResponseMessage response1 = await client.GetAsync("http://192.168.8.1/reqproc/proc_get?cmd=apn_mode");
                if (response1.IsSuccessStatusCode)
                {
                    //var result = response1.Content.ReadAsStringAsync().Result;
                   // dynamic json = JsonConvert.DeserializeObject(result);
                    typeapn = "fdfd";
                    // typeapn = json["apn_mode"].ToString();
                    // var s = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                }
                else
                {
                    typeapn = "fail";
                }*/
            
            /*
            var client = new HttpClient();
            Debug.WriteLine("result:: ");
            var response1 = await client.GetAsync("http://192.168.8.1/reqproc/proc_get?cmd=apn_mode");
            //typeapn = response1;
            
            if (response1.IsSuccessStatusCode)
            {
                var result = response1.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(result);
                typeapn = "fdfd";
               // typeapn = json["apn_mode"].ToString();
                // var s = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            }
            else
            {
                typeapn = "fail";
            }*/
        }


        public Boolean CheckCurrentIP()
        {

            // Get all network interfaces addresses
            IPAddress[] localIPAddress = Dns.GetHostAddresses(Dns.GetHostName());
            myLocalIP.ResetText();
            myLocalIP.AppendText("My Local IP ");
            myLocalIP.AppendText("\r\n");
            // Change the current using address <Code>localIPAddress[0]</Code> to IPV4 string format
            foreach (IPAddress temIP in localIPAddress)
            {
                if (temIP.AddressFamily == AddressFamily.InterNetwork)
                {
                    string LocalIP = temIP.ToString();
                    //break;
                    myLocalIP.AppendText(LocalIP);
                    if (LocalIP.Contains("192.168.8"))
                    {
                        myLocalIP.AppendText(" My Dcom ");
                        return true;
                    }
                    myLocalIP.AppendText("\r\n");
                    Console.WriteLine(temIP);
                }
                
            }
            return false;
        }
        private async void ChangeNetwork_Click(object sender, EventArgs e)
        {

            //http://192.168.8.1/reqproc/proc_get?cmd=apn_mode
            var disconect = new Dictionary<string, string>
            {
                { "isTest", "false" },
                { "notCallback", "true" },
                { "goformId", "DISCONNECT_NETWORK" },
            };
            var connect = new Dictionary<string, string>
            {
                { "isTest", "false" },
                { "notCallback", "true" },
                { "goformId", "CONNECT_NETWORK" },
            };
//isTest=false&goformId=APN_PROC_EX&apn_mode=auto
            var apn1 = new Dictionary<string, string>
            {
                { "isTest", "false" },
                { "goformId", "APN_PROC_EX" },
                { "apn_mode", "auto" },
            };
//isTest=false&goformId=APN_PROC_EX&apn_mode=manual&apn_action=set_default&set_default_flag=1&pdp_type=IP&index=1

            var apnmenu = new Dictionary<string, string>
            {
                { "isTest", "false" },
                { "goformId", "APN_PROC_EX" },
                { "apn_mode", "manual" },
                { "apn_action", "set_default" },
                { "set_default_flag", "1" },
                { "pdp_type", "IP" },
                 { "index", "1" }
            };
            var settingMobi = new Dictionary<string, string>
            {
                { "isTest", "false" },
                { "goformId", "APN_PROC_EX" },
                { "apn_action", "save" },
                { "apn_mode", "manual" },
                { "profile_name", "Tesst" },
                { "wan_dial", "*99 % 23" },
                { "apn_select", "manual" },
                { "pdp_type", "IP" },
                { "pdp_select", "auto" },
                { "pdp_addr", "" },
                { "index", "1" },
                { "wan_apn", "internet" },
                { "ppp_auth_mode", "none" },
                { "ppp_username", "mms" },
                { "ppp_passwd", "mms" }
            };
            var settingVt = new Dictionary<string, string>
            {
                { "isTest", "false" },
                { "goformId", "APN_PROC_EX" },
                { "apn_action", "save" },
                { "apn_mode", "manual" },
                { "profile_name", "v-internet" },
                { "wan_dial", "*99 % 23" },
                { "apn_select", "manual" },
                { "pdp_type", "IP" },
                { "pdp_select", "auto" },
                { "pdp_addr", "" },
                { "index", "1" },
                { "wan_apn", "v-internet" },
                { "ppp_auth_mode", "none" },
                { "ppp_username", "" },
                { "ppp_passwd", "" }
            };
            var settingVina = new Dictionary<string, string>
            {
                { "isTest", "false" },
                { "goformId", "APN_PROC_EX" },
                { "apn_action", "save" },
                { "apn_mode", "manual" },
                { "profile_name", "Tesst" },
                { "wan_dial", "*99 % 23" },
                { "apn_select", "manual" },
                { "pdp_type", "IP" },
                { "pdp_select", "auto" },
                { "pdp_addr", "" },
                { "index", "1" },
                { "wan_apn", "m3-world" },
                { "ppp_auth_mode", "none" },
                { "ppp_username", "mms" },
                { "ppp_passwd", "mms" }
            };
            dem++;
            try
            {

                if (CheckCurrentIP()) { 
                var client = new HttpClient();
                var settingapn = settingMobi;
                if (nhamang == 1)
                {
                    settingapn = settingVt;
                }
                else if (nhamang == 1)
                {
                    settingapn = settingVina;
                }
                var data = new FormUrlEncodedContent(settingapn);
                var url = "http://192.168.8.1/reqproc/proc_post";
                if (dem % 2 == 0)
                {
                }
                else
                {
                    await client.PostAsync(url, data);
                }
                await sleepT(50);
                textBox1.Text = "Disconnect";
                textBox1.BackColor = Color.Red;
                data = new FormUrlEncodedContent(disconect);
                var response = await client.PostAsync(url, data);
                await sleepT(50);
                textBox1.BackColor = Color.Red;

                if (dem % 2 == 0)
                {
                    data = new FormUrlEncodedContent(apn1);
                    textBox1.Text = "Auto Mode";
                }
                else
                {
                    data = new FormUrlEncodedContent(apnmenu);
                    textBox1.Text = "Menu Mode";
                }
                response = await client.PostAsync(url, data);
                await sleepT(200);
                data = new FormUrlEncodedContent(connect);
                textBox1.Text = "Connect";
                textBox1.BackColor = Color.Red;

                response = await client.PostAsync(url, data);
                await sleepT(2200);
                textBox1.Text = "get IP";
                textBox1.BackColor = Color.Red;
                await getmyIp();
                textBox1.Text = "Done";
                textBox1.BackColor = Color.LightGreen;
                }
            else
            {
                textBox1.Text = "Don't have\r\nDCOM\r\n192.168.8.x";
                textBox1.BackColor = Color.LightGreen;
            }
        }
            catch
            {
                textBox1.Text = "Fail";
                textBox1.BackColor = Color.LightGreen;
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = comboBox1.SelectedIndex;
            string selectedText = this.comboBox1.Text;
            if (selectedText == "Mobifone")
            {
                nhamang = 0;
            }
            else if (selectedText == "Viettel")
            {
                nhamang = 1;
            }
            else
            {
                nhamang = 2;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(lblmyaddress.Text);
            MessageBox.Show("Copy done");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void getIp_Click(object sender, EventArgs e)
        {
            getmyIp();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
