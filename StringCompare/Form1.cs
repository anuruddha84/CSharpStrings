using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Method 1



        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = Method1(textBox1.Text, textBox2.Text).ToString();
        }

        public bool Method1(string s1, string s2)
        {
            if (s1.Length < 3 || s2.Length < 3)
                return false;

            string input1 = Reverse(s1);
            string input2 = Reverse(s2);
            int count = 0;

            for (int i = 0; i < input1.Length; i++)
            {
                char char1 = input1[i];
                char char2 = input2[i];

                if (char1 == char2)
                {
                    count++;
                }
                if (count >= 2)
                {
                    return true;
                }
            }
            return false;
        }

        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = Check(textBox3.Text, textBox4.Text).ToString();
        }

        private bool Check(string original, string match)
        {
            var matches = new List<int>();

            var length = match.Length - 1;
            foreach (var s in original.Reverse().Where(s => length > 0))
            {
                if (s == match[length])
                {
                    matches.Add(1);
                }
                --length;
            }

            return matches.Count >= 3;
        }

    }
}
