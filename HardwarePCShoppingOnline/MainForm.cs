using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwarePCShoppingOnline
{
    public partial class MainForm : Form
    {
        int intFade = 1;
        public static int intNetPrice = 0;
        ListView listViewLastestSelected = new ListView();
        public static ListView listViewCopy = new ListView();

        public MainForm()
        {
            InitializeComponent();
            buttonClose.Focus();
            Opacity = 0.00;
        }

        private void OperationVisible()
        {
            buttonBasket.Visible = true;
            buttonDelete.Visible = true;
            listViewCart.Visible = true;
            panel5.Visible = true;
            panel8.Visible = true;
        }

        private void CopySelectedItems(ListView listViewSource, ListView listViewTarget)
        {
            foreach (ListViewItem item in listViewSource.SelectedItems)
            {
                listViewTarget.Items.Add((ListViewItem)item.Clone());
            }
        }

        private void DeleteSelectedItems(ListView cart)
        {
            foreach (ListViewItem eachItem in cart.SelectedItems)
            {
                cart.Items.Remove(eachItem);
            }
        }

    private void buttonClose_Click(object sender, EventArgs e)
        {
            intFade = 0;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close this program ???", "Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                timerFade.Start();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

            //timerFade.Start();
        }

        private void timerFade_Tick(object sender, EventArgs e)
        {
            if (intFade != 0)
            {
                if (Opacity < 1.0)
                {
                    Opacity += 0.07;
                }
                else
                {
                    timerFade.Stop();
                }
            }
            else
            {
                if (Opacity > 0.0)
                {
                    Opacity -= 0.07;
                }
                else
                {
                    timerFade.Stop();
                    Application.Exit();
                    //Close();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timerFade.Interval = 1;
            timerFade.Start();

            foreach (ListViewItem item in MainForm.listViewCopy.Items)
            {
                listViewCart.Items.Add((ListViewItem)item.Clone());
            }

            textBoxNetPrice.Text = intNetPrice.ToString("0,0") + " ฿";

            if (intNetPrice != 0)
            {
                listViewCPU.Visible = true;
                OperationVisible();
            }
        }

        private void buttonCPU_Click(object sender, EventArgs e)
        {
            listViewLastestSelected.Visible = false;
            listViewLastestSelected = listViewCPU;
            listViewCPU.Visible = true;
            OperationVisible();
        }

        private void buttonMotherboard_Click(object sender, EventArgs e)
        {
            listViewLastestSelected.Visible = false;
            listViewLastestSelected = listViewMotherboard;
            listViewMotherboard.Visible = true;
            OperationVisible();
        }

        private void buttonVGA_Click(object sender, EventArgs e)
        {
            listViewLastestSelected.Visible = false;
            listViewLastestSelected = listViewVGA;
            listViewVGA.Visible = true;
            OperationVisible();
        }

        private void buttonRAM_Click(object sender, EventArgs e)
        {
            listViewLastestSelected.Visible = false;
            listViewLastestSelected = listViewRAM;
            listViewRAM.Visible = true;
            OperationVisible();
        }

        private void buttonHDD_Click(object sender, EventArgs e)
        {
            listViewLastestSelected.Visible = false;
            listViewLastestSelected = listViewHDD;
            listViewHDD.Visible = true;
            OperationVisible();
        }

        private void buttonSSD_Click(object sender, EventArgs e)
        {
            listViewLastestSelected.Visible = false;
            listViewLastestSelected = listViewSSD;
            listViewSSD.Visible = true;
            OperationVisible();
        }

        private void buttonPSU_Click(object sender, EventArgs e)
        {
            listViewLastestSelected.Visible = false;
            listViewLastestSelected = listViewPSU;
            listViewPSU.Visible = true;
            OperationVisible();
        }

        private void buttonCase_Click(object sender, EventArgs e)
        {
            listViewLastestSelected.Visible = false;
            listViewLastestSelected = listViewCase;
            listViewCase.Visible = true;
            OperationVisible();
        }

        private void buttonCPUCooler_Click(object sender, EventArgs e)
        {
            listViewLastestSelected.Visible = false;
            listViewLastestSelected = listViewCooler;
            listViewCooler.Visible = true;
            OperationVisible();
        }

        private void buttonMonitor_Click(object sender, EventArgs e)
        {
            listViewLastestSelected.Visible = false;
            listViewLastestSelected = listViewMonitor;
            listViewMonitor.Visible = true;
            OperationVisible();
        }

        private void buttonBasket_Click(object sender, EventArgs e)
        {
            // Add items to cart
            CopySelectedItems(listViewLastestSelected, listViewCart);
            CopySelectedItems(listViewLastestSelected, listViewCopy);

            // Get price from selected items and converse to data type "int"
            try
            {
                intNetPrice += int.Parse(listViewLastestSelected.SelectedItems[0].SubItems[1].Text, CultureInfo.InvariantCulture);
            }
            catch (Exception exceptionDoNothing)
            {
                // Do nothing
            }

            // Show net price
            textBoxNetPrice.Text = intNetPrice.ToString("0,0") + " ฿";
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (listViewCart.Items.Count <1)
                MessageBox.Show("Please add any item to cart atleast one. ", "Alert");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to build now ???", "Build Now", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    BuildForm Form2 = new BuildForm();
                    Form2.Show();
                    Hide();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            // Get price from selected items and converse to data type "int"
            try
            {
                intNetPrice -= int.Parse(listViewCart.SelectedItems[0].SubItems[1].Text, CultureInfo.InvariantCulture);
            }
            catch (Exception exceptionDoNothing)
            {
                // Do nothing
            }

            // Delete items from cart
            DeleteSelectedItems(listViewCart);

            // Show net price
            textBoxNetPrice.Text = intNetPrice.ToString("0,0") + " ฿";
        }
    }
}
