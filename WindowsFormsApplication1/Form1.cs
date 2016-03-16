using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

         String adres;
         String tresc;

        static string result1;
        static string result2;

        public Form1()
        {
            InitializeComponent();
        }

        public static String madres
        {
            get
            {
                return result1;
            }
            set
            {
                result1 = value;
            }
        }

        public static String mtresc
        {
            get
            {
                return result2;
            }
            set
            {
                result2 = value;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

       private void textBox1_TextChanged(object sender, EventArgs e)
        {
            adres = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            textBox1.Text = result1;
            textBox2.Text = result2;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            tresc = textBox2.Text;
        }


    }
}
