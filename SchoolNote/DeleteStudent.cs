using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SchoolNote
{
    public partial class DeleteStudent : Form
    {
        string[,] datas;
        string[,] newdata;
        string deletename;
        string deletenumber;
        string deletenote;
        public DeleteStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = txtNumber.Text;
            GetDatas();
            for (int i = 0; i < datas.GetLength(0); i++)
            {
                if (datas[i,2] == number)
                {
                    deletename = datas[i, 0];
                    deletenote = datas[i, 1];
                    deletenumber = datas[i, 2];
                }
            }
            DeletedDatas();
            this.Close();
        }

        private void DeletedDatas()
        {
            string path = Path.Combine(Application.StartupPath, "Datas.txt");
            string[] lines = File.ReadAllLines(path);
            newdata = new string[lines.Length, 3];
            for (int i = 0; i < lines.Length; i++)
            {

                string[] split = lines[i].Split(';');
                newdata[i, 0] = split[0]; // Name
                newdata[i, 1] = split[1]; // Note
                newdata[i, 2] = split[2]; // Number
            }
            StreamWriter clean = new StreamWriter(path);
            clean.Write("");
            clean.Close();
            for (int i = 0; i < datas.GetLength(0); i++)
            {
                if (datas[i, 0] == deletename && datas[i, 1] == deletenote && datas[i, 2] == deletenumber)
                {
                    continue;
                }
                StreamWriter sw = new StreamWriter(path, true);
                string line = $"{newdata[i,0]};{newdata[i,1]};{newdata[i,2]}";
                sw.WriteLine($"{line}");
                sw.Close();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
