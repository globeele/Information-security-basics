using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_Lab_2;

namespace App_Lab2
{
    public partial class Form1 : Form
    {
        ExsponentialCipher exsponentialCipher = new ExsponentialCipher();
        GammaОverlay gammaОverlay = new GammaОverlay();
        Transposition transposition = new Transposition();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                int[] Encode = exsponentialCipher.encode(textBox1.Text, textBox2.Text);

                label4.Text = "";

                for (int i = 0; i < Encode.Length; i++)
                {
                    label4.Text += Encode[i].ToString() + " ";
                }

                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                string[] Encode = textBox1.Text.Split(' ');
                List<int> EncodeArray = new List<int>();

                foreach(string str in Encode)
                {
                    if(int.TryParse(str, out _))
                    {
                        EncodeArray.Add(int.Parse(str));
                    }
                }

                string decript = exsponentialCipher.decode(EncodeArray.ToArray(), textBox2.Text);

                label4.Text = decript;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {
                byte[] Encode = gammaОverlay.encode(textBox3.Text, textBox4.Text);

                label4.Text = "";

                for (int i = 0; i < Encode.Length; i++)
                {
                    label5.Text += Encode[i].ToString() + " ";
                }

                textBox3.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {
                string[] Encode = textBox3.Text.Split(' ');
                List<byte> EncodeArray = new List<byte>();

                foreach (string str in Encode)
                {
                    if (byte.TryParse(str, out _))
                    {
                        EncodeArray.Add(byte.Parse(str));
                    }
                }

                string decript = gammaОverlay.decode(EncodeArray.ToArray(), textBox4.Text);

                label5.Text = decript;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            transposition = new Transposition();

            if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text))
            {
                transposition.SetKey(textBox6.Text);

                string Encode = transposition.Encrypt(textBox5.Text);

                label9.Text = Encode;

                textBox5.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            transposition = new Transposition();

            if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text))
            {
                transposition.SetKey(textBox6.Text);

                string Decode = transposition.Decrypt(textBox5.Text);

                label9.Text = Decode;
                textBox5.Text = "";
            }
        }
    }
}

