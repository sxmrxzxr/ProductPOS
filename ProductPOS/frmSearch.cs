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
    public partial class frmSearch : Form
    {
        private Product[] p = (Product[])null;

        public frmSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Search" && txtSearch.Text != "")
            {
                lstResults.Items.Clear();
                p = ProductDB.SelectLikeDesc(txtSearch.Text);
                //MessageBox.Show(p[0].ToString());
                if (p != null)
                {
                    foreach (Product prod in p)
                    {
                        if (prod != null)
                        {
                            lstResults.Items.Add(prod.ToString());
                            btnSearch.Text = "Copy ID to POS";
                        }
                    }
                }                
            }
            else
            {
                if (!(btnSearch.Text == "Copy ID to POS"))
                    return;
                if (lstResults.SelectedIndex >= 0)
                {
                    Tag = p[lstResults.SelectedIndex];
                    Close();
                }
                else
                {
                    MessageBox.Show("No item selected.");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            p = (Product[])null;
            Tag = (object)p;
            Close();
        }
    }
}
