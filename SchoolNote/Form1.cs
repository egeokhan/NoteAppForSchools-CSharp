using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolNote
{
    public partial class Form1 : Form
    {
        string[,] datas;
        int meter = 0;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            GetDatas();
            PrintDatas();
        }

        private void PrintDatas()
        {
            for (int i = 0; i < datas.GetLength(0); i++)
            {
                string listline = $"Name: {datas[i, 0]} // Number: {datas[i, 2]} // Note:{datas[i, 1]}";
                listBox1.Items.Add(listline);
            }
        }

        private void GetDatas()
        {
            string path = Path.Combine(Application.StartupPath, "Datas.txt");
            string[] lines = File.ReadAllLines(path);
            datas = new string[lines.Length, 3];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(';');
                datas[i, 0] = split[0]; // Name
                datas[i, 1] = split[1]; // Note
                datas[i, 2] = split[2]; // Number
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudent frm = new AddStudent();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            meter++;
            if (meter % 15 == 0)
            {
                meter = 0;
                listBox1.Items.Clear();
                GetDatas();
                PrintDatas();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new DeleteStudent();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var frm = new ChangeNote();
            frm.Show();
        }
    }
}
