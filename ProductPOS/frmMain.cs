using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductPOS
{
    public partial class frmMain : Form
    {
        private Transaction t;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSearchProducts_Click(object sender, EventArgs e)
        {
            Form frm = new frmSearch();
            frm.Text = "Search";
            int num = (int)frm.ShowDialog();
            if (frm.Tag == null)
                return;
            this.txtProductID.Text = ((Product)frm.Tag).ID;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.t = new Transaction();
        }

        private void btnGetDescription_Click(object sender, EventArgs e)
        {
            if (!(txtProductID.Text != ""))
                return;
            Product p1 = (Product)null;
            Product p2 = ProductDB.SelectProduct(txtProductID.Text);

            if (p2 != null)
            {
                int n = (int)MessageBox.Show("Product: " + p2.ToString());

                if (p2.Type == "Movie")
                    p1 = (Product)ProductDB.SelectMovie(p2.ID);
                if (p2.Type == "Music")
                    p1 = (Product)ProductDB.SelectMusic(p2.ID);
                if (p2.Type == "Software")
                    p1 = (Product)ProductDB.SelectSoftware(p2.ID);
                if (p2.Type == "Pants")
                    p1 = (Product)ProductDB.SelectPants(p2.ID);
                if (p2.Type == "DressShirt")
                    p1 = (Product)ProductDB.SelectDressShirt(p2.ID);
                if (p2.Type == "TShirt")
                    p1 = (Product)ProductDB.SelectTShirt(p2.ID);
                if (p2.Type == "Book")
                    p1 = (Product)ProductDB.SelectBook(p2.ID);
            }
            if (p1 != null)
            {
                Form frm = new frmProduct();
                frm.Tag = p1;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Product: " + txtProductID.Text + " not found.");
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (!(txtProductID.Text != ""))
                return;
            int i;

            try
            {
                i = Convert.ToInt32(txtQuantity.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            Product p = ProductDB.SelectProduct(txtProductID.Text);

            if (p != null)
            {
                double num = p.Price * (double)i;
                lstScreen.Items.Add((object)(p.ID + " " + p.Desc + " " + i + " @ " + p.Price.ToString("C") + " -> " + num.ToString("C")));
                t.Add(p, i);
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (lstScreen.SelectedIndex < 0)
                return;
            t.RemoveAt(lstScreen.SelectedIndex);
            lstScreen.Items.RemoveAt(lstScreen.SelectedIndex);
        }

        private void btnCancelSale_Click(object sender, EventArgs e)
        {
            t.Clear();
            lstScreen.Items.Clear();
        }

        private void btnEnterSale_Click(object sender, EventArgs e)
        {
            double subtotal = 0.0;

            if (lstScreen.Items.Count <= 0)
                return;

            for (int i = 0; i < lstScreen.Items.Count; i++)
                subtotal += t.ProductAt(i).Price * (double)t.QtyOfProductsAt(i);

            double tax = 0.06 * subtotal;
            double total = tax + subtotal;

            ProductDB.InsertTrans(subtotal, tax, total);
            int tid = ProductDB.SelectMaxTrans();
            txtReceipt.Text = "Receipt\r\n\r\n";
            TextBox txtReceipt1 = txtReceipt;
            string s1 = txtReceipt1.Text + DateTime.Now.ToLongDateString() + " at ";
            txtReceipt1.Text = s1;
            TextBox txtReceipt2 = txtReceipt;
            string s2 = txtReceipt2.Text + DateTime.Now.ToLongTimeString() + "\r\n\r\n";
            txtReceipt2.Text = s2;

            for (int i = 0; i < lstScreen.Items.Count; i++)
            {
                int qty = t.ProductAt(i).Quantity - t.QtyOfProductsAt(i);
                ProductDB.InsertLineItem(tid, t.ProductAt(i).ID, t.QtyOfProductsAt(i), t.ProductAt(i).Price);
                ProductDB.UpdateProduct(t.ProductAt(i).ID, qty);
                string s3 = t.ProductAt(i).ID + "  " + t.ProductAt(i).Desc + "  " + t.QtyOfProductsAt(i) + " @ " + t.ProductAt(i).Price.ToString("C") + " -> " + (t.ProductAt(i).Price * t.QtyOfProductsAt(i)).ToString("C");
                TextBox txtReceipt3 = txtReceipt;
                string s4 = txtReceipt3.Text + s3 + "\r\n";
                txtReceipt3.Text = s4;
            }

            TextBox txtReceipt4 = txtReceipt;
            string s5 = txtReceipt4.Text + "\r\nSubtotal\t\t\t\t\t" + subtotal.ToString("C");
            txtReceipt4.Text = s5;
            TextBox txtReceipt5 = txtReceipt;
            string s6 = txtReceipt5.Text + "\r\nTax\t\t\t\t\t" + tax.ToString("C");
            txtReceipt5.Text = s6;
            TextBox txtReceipt6 = txtReceipt;
            string s7 = txtReceipt6.Text + "\r\nTotal\t\t\t\t\t" + total.ToString("C");
            txtReceipt6.Text = s7;
            t.Clear();
            lstScreen.Items.Clear();
        }
    }
}
