using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Plan;

namespace Owner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //GetData();
        }

        private void GetData()
        {
            var res = new ZhaoShangRate().GetHtml();
            this.lasttime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.dataGridView1.DataSource = res;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetData(); 
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            var txtlen = this.label1.Text.Length;
            txtlen = txtlen >= 11 ? 4 : txtlen;
            string lis = "。。。。。。。。。";
            string li = lis.Substring(0, txtlen-4);

            this.label1.Text = "程序运行中" + li;
        }
    }
}
