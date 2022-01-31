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
    public partial class AddStudent : Form
    {
        string[,] datas;
        bool result = false;
        public AddStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string number = textBox2.Text;
            string note = textBox3.Text;
            string path = Path.Combine(Application.StartupPath, "Datas.txt");
            CheckDatas(path,number);
            WriteDatas(path,name,number,note);
            this.Close();
        }

        private void CheckDatas(string path,string number)
        {
            string[] lines = File.ReadAllLines(path);
            datas = new string[lines.Length, 3];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(';');
                datas[i, 0] = split[0]; // Name
                datas[i, 1] = split[1]; // Note
                datas[i, 2] = split[2]; // Number
                if (datas[i,2] == number)
                {
                    result = true;
                }
            }
        }

        private void WriteDatas(string path,string name,string number, string note)
        {
            if(result == false)
            {
                StreamWriter sw = new StreamWriter(path, true);
                string line = $"{name};{note};{number}";
                sw.WriteLine($"{line}");
                sw.Close();
            }
            else
            {
                MessageBox.Show("This student already exists");
            }
        }
    }
}
