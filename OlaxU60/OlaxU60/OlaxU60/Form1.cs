using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;

namespace OlaxU60
{
    public partial class Form1 : Form
    {
        string[] listIP = { "", "", "", "", "", "", "", "", "", "" };
        int numberIP = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void getmyIp()
        {
            int kq = 0;
            var url = "https://api.myip.com";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
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
            if (kq == 0)
                resultCheckIP.Text = "OK";
            else
                resultCheckIP.Text = "Trung IP";
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
    }
}
