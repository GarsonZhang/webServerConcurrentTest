using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webServerConcurrentTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int MaxNum = 50;
        private void btn_Test_Click(object sender, EventArgs e)
        {
            MaxNum = int.Parse(txt_UnitNum.Text);
            int threadNum = int.Parse(txt_ThreadNum.Text);
            for (int i = 0; i < threadNum; i++)
            {
                Thread t1 = new Thread(new ParameterizedThreadStart(doTest));
                t1.Start(i + 1);
            }
        }

        void doTest(object flag)
        {
            int index = (int)flag;
            string url = txt_URL.Text;
            string parms = txt_Parms.Text;
            for (int i = 0; i < MaxNum; i++)
            {
                HttpRequest.CallMsg msg = HttpRequest.SysnPostEx(url, parms).Result;


                //return msg;
                addLog(index, i + 1, msg);
                //txt_Result.AppendText(String.Format("{0}\t{1}\t{2}\r\n", cm.Status ? "success" : "fail", cm.ResponseData, cm.ResponseTime));
            }
        }

        void addLog(int flag, int index, HttpRequest.CallMsg cm)
        {

            //lock (txt_Result)
            //{
            txt_Result.Invoke(new Action(delegate
            {
                txt_Result.AppendText(String.Format("{0}\t{1}\t{2}\r\n", formatInt(flag) + "_" + formatInt(index) + (cm.Status ? "success" : "fail"), cm.ResponseData, cm.ResponseTime));
            }));
            //}
        }  

        string formatInt(int i)
        {
            return i.ToString().PadLeft(3, '0');
        }
    }
}
