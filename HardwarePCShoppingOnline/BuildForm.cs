using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwarePCShoppingOnline
{
    public partial class BuildForm : Form
    {
        int intNetPrice = MainForm.intNetPrice;
        public BuildForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            labelTimeNow.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            foreach (ListViewItem item in MainForm.listViewCopy.Items)
            {
                listViewBill.Items.Add((ListViewItem)item.Clone());
            }
            textBoxNetPrice.Text = intNetPrice.ToString("0,0" + " ฿");
        }

        private void CopySelectedItems(ListView listViewSource, ListView listViewTarget)
        {
            foreach (ListViewItem item in listViewSource.SelectedItems)
            {
                listViewTarget.Items.Add((ListViewItem)item.Clone());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm Form1 = new MainForm();
            Form1.Show();
            Hide();
        }

        public int counttext1 = 0, counttext2 = 0, counttext3 = 0, numbertext3 = 0;
 
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            counttext1 = textBox2.TextLength;
            counttext2 = textBox3.TextLength;
            counttext3 = textBox4.TextLength;

            numbertext3 = Int32.Parse(textBox4.Text);

            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please enter your name ,lastname and telephone number", "Alert");
            }
            else 
            {
               
            }
        }

        private void check_int(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar));
        }
    }
}
