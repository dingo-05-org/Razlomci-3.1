using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Razlomci_3._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Razlomci uBroj (ref int i, string s)
        {
            int p = i;
            while (i < s.Length && ((s[i] >= '0' && s[i] <= '9') || s[i] == '/'))
                i++;
            Razlomci rez= new Razlomci(s.Substring(p, i - p));
            listBox1.Items.Add(rez.ispis());
            return rez;
        }
        private bool Provera(string s)
        {
            int i = 0;
            while (i < s.Length)
                if (!((s[i] >= '0' && s[i] <= '9') || s[i] == '/'||s[i] != '+' || s[i] != '-'))
                {
                    return true;
                }
                else i++;
            if (s[i - 1] == '+' || s[i-1]=='-')
                return true;
            return false;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string s=textBox1.Text;
            if (s.Length != 0)
            {
                if (Provera(s))
                {
                    MessageBox.Show($"Uneli ste neodgovarajuci oblik, molim vas probajte ponovo, dozvoljeni su sledece:{Environment.NewLine}0123456789+-/{Environment.NewLine}Isto tako ne smes da zavrsis program sa + ili -. ");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Niste uneli nista");
                return;
            }
            listBox1.Items.Clear();
            int i = 0;
            Razlomci rez= uBroj(ref i, s);
            while(i<s.Length)
            {
                char c = s[i];
                i++;
                if (c == '+')
                    rez = rez.saberi(uBroj(ref i, s));
                else
                    rez = rez.oduzmi(uBroj(ref i, s));

            }
            label1.Text = rez.ispis();
        }
    }
}
