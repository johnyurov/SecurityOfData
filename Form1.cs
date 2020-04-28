using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityOfData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(OpenDlg.FileName, Encoding.Default);
                richTextBox1.Text = Reader.ReadToEnd();
                Reader.Close();
            }
            OpenDlg.Dispose();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ushort Encode = 0x0010;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        Encode = 0x0015;
                        break;
                    }
                case 1:
                    {

                        Encode = 0x0088;
                        break;
                    }
                case 2:
                    {
                        Encode = 0x3264;
                        break;
                    }
            }
            listBox1.Items.Clear();
            listBox1.BeginUpdate();
            string[] @strings = richTextBox1.Text.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in @strings)
            {
                string Str = s.Trim();
                var ch = Str.ToCharArray();
                for (int i = 0; i < ch.Length; i++)
                {
                    ch[i] = (char)(ch[i] ^ Encode);
                }
                Str = new string(ch);
                if (Str == String.Empty) continue;
                listBox1.Items.Add(Str);
            }
            listBox1.EndUpdate();
        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            if (SaveDlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Writer = new StreamWriter(SaveDlg.FileName);
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    Writer.WriteLine((string)listBox1.Items[i]);
                }
                Writer.Close();
            }
            SaveDlg.Dispose();
        }

        private void X0015ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
