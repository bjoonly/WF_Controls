using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls
{
    public partial class Form1 : Form
    {
        static int count = 1;
        public Form1()
        {
            InitializeComponent();
        }


        private void CalculateButton_Click(object sender, EventArgs e)
        {

            decimal totalPrice = 0;
            foreach (RadioButton rb in mainDishGroupBox.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    totalPrice += Convert.ToDecimal(rb.Tag);
                    break;

                }
            }

            foreach (RadioButton rb in drinksGroupBox.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    totalPrice += Convert.ToDecimal(rb.Tag);
                    break;
                }
            }
            foreach (RadioButton rb in dessertsGroupBox.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    totalPrice += Convert.ToDecimal(rb.Tag);
                    break;
                }
            }
            DateTime dt = DateTime.Now;
            ResultTextBox.Text += String.Format("{0,3}.Total price: {1} | Order date: {2}", count, totalPrice, dt);
            ResultTextBox.Text += (Environment.NewLine);
            MessageBox.Show($"Total Price: {totalPrice}", $"{count}.Order date: {dt}", MessageBoxButtons.OKCancel);
            count++;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            calculateButton.Enabled = IsAllSelected();
        }
        private bool IsAllSelected()
        {
            bool isSelectMainDish = false, isSelectDrinks = false, isSelectDesert = false;
            foreach (RadioButton rb in mainDishGroupBox.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    isSelectMainDish = true;
                    break;

                }
            }

            foreach (RadioButton rb in drinksGroupBox.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    isSelectDrinks = true;
                    break;
                }
            }
            foreach (RadioButton rb in dessertsGroupBox.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    isSelectDesert = true;
                    break;
                }
            }
            return isSelectDesert && isSelectDrinks && isSelectMainDish;
        }

    }
}
