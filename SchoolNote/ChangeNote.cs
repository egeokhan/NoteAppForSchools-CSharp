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
    public partial class ChangeNote : Form
    {
        string[,] data;
        string[,] newdata;
        int meter = 0;
        public ChangeNote()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = txtNumber.Text;
            string newnote = textBox1.Text;
            GetData();
            GetMeter(number,newnote);
            ChangeData(number,newnote);
            this.Close();
        }

        private void ChangeData(string number,string newnote)
        {
            newdata = new string[data.GetLength(0),3];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (i == meter)
                {
                    newdata[i, 0] = data[i, 0];
                    newdata[i, 1] = newnote;
                    newdata[i, 2] = number;
                    continue;
                }
                newdata[i, 0] = data[i, 0];
                newdata[i, 1] = data[i, 1];
                newdata[i, 2] = data[i, 2];
            }
            string path = Path.Combine(Application.StartupPath, "Datas.txt");
            StreamWriter sw = new StreamWriter(path);
            sw.Write("");
            sw.Close();
            StreamWriter changedatas = new StreamWriter(path, true);
            for (int i = 0; i < newdata.GetLength(0); i++)
            {
                string line = $"{newdata[i,0]};{newdata[i,1]};{newdata[i,2]}";
                changedatas.WriteLine(line);
            }
            changedatas.Close();
        }

        private void GetMeter(string number,string newnote)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i,2] == number)
                {
                    meter = i;
                }
            }
        }

        private void GetData()
        {
            string path = Path.Combine(Application.StartupPath, "Datas.txt");
            string[] lines = File.ReadAllLines(path);
            data = new string[lines.Length, 3];
            for (int i = 0; i < lines.Length; i++)
            {

                string[] split = lines[i].Split(';');
                data[i, 0] = split[0]; // Name
                data[i, 1] = split[1]; // Note
                data[i, 2] = split[2]; // Number
            }
        }
    }
}
