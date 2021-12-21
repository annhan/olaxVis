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
using System.Windows;
namespace OlaxU60
{
    public partial class Form1 : Form
    {
        string[] listIP = { "", "", "", "", "", "", "", "", "", "" };
        int numberIP = 0;
        string typeapn = "";
        int dem = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private static void Initialize()
        {
        }
        private void getmyIp()
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
                MessageBox.Show("Done - Check IP Again");
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
                text= "Dont -OK";
                resultCheckIP.Text = "OK";
            }
            else
            {
                text = "Dont - Trung IP";
                resultCheckIP.Text = "Trung IP";
                resultCheckIP.BackColor = Color.Red;
            }
            MessageBox.Show(text);

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

        private void getIp_Click(object sender, EventArgs e)
        {
            getmyIp();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void resultCheckIP_TextChanged(object sender, EventArgs e)
        {

        }

        static void Enable(string interfaceName)
        {
            System.Diagnostics.ProcessStartInfo psi =
                   new System.Diagnostics.ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" enable");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();
        }

        static void Disable(string interfaceName)
        {
            System.Diagnostics.ProcessStartInfo psi =
                new System.Diagnostics.ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //TextBox t = (TextBox)namecard;

            string namecard1 = namecard.Text;
            Disable(namecard1);
            //System.Threading.Thread.Sleep(5000);
            Enable(namecard1);
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

            var apn2 = new Dictionary<string, string>
            {
                { "isTest", "false" },
                { "goformId", "APN_PROC_EX" },
                { "apn_mode", "manual" },
                { "apn_action", "set_default" },
                { "set_default_flag", "1" },
                { "pdp_type", "IP" },
                 { "index", "1" }
            };
            //textBox1.Text = "Disconnect";
            //textBox1.BackColor = Color.Red;
            var client = new HttpClient();
            dem++;
            var data = new FormUrlEncodedContent(disconect);
            var url = "http://192.168.8.1/reqproc/proc_post";
            var response = client.PostAsync(url, data);
            //textBox1.Text = "Change";
            //textBox1.BackColor = Color.Red;
            if (dem % 2 == 0)
            {
                data = new FormUrlEncodedContent(apn1);
            }
            else
            {
                data = new FormUrlEncodedContent(apn2);
            }
            response = client.PostAsync(url, data);
            System.Threading.Thread.Sleep(200);
            //textBox1.Text = "Connect";
            //textBox1.BackColor = Color.Red;
            data = new FormUrlEncodedContent(connect);
            response = client.PostAsync(url, data);
            System.Threading.Thread.Sleep(2200);
            getmyIp();
            //textBox1.Text = typeapn;
            //textBox1.BackColor = Color.LightGreen;

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
