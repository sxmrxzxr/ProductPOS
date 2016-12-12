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
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            if (Tag == null)
                return;
            drawProduct((Product)Tag);
        }

        private void showClear()
        {
            drawSet(false, false, false, false, false, false, false, false);
            txtType.Text = "";
            txtID.Text = "";
            txtDesc.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            lblVar1.Text = "";
            lblVar2.Text = "";
            lblVar3.Text = "";
            lblVar4.Text = "";
            lblVar5.Text = "";
            lblVar6.Text = "";
            lblVar7.Text = "";
            lblVar8.Text = "";
        }

        private void drawSet(bool b1, bool b2, bool b3, bool b4, bool b5, bool b6, bool b7, bool b8)
        {
            lblVar1.Visible = b1;
            txtVar1.Visible = b1;
            lblVar2.Visible = b2;
            txtVar2.Visible = b2;
            lblVar3.Visible = b3;
            txtVar3.Visible = b3;
            lblVar4.Visible = b4;
            txtVar4.Visible = b4;
            lblVar5.Visible = b5;
            txtVar5.Visible = b5;
            lblVar6.Visible = b6;
            txtVar6.Visible = b6;
            lblVar7.Visible = b7;
            txtVar7.Visible = b7;
            lblVar8.Visible = b8;
            txtVar8.Visible = b8;
        }

        private void drawProduct(Product p)
        {
            txtType.Text = p.Type;
            txtID.Text = p.ID;
            txtDesc.Text = p.Desc;
            txtPrice.Text = p.Price.ToString("C");
            txtQuantity.Text = p.Quantity.ToString();
            if (p.Type == "Book")
                drawBook(p);
            else if (p.Type == "Software")
                drawSoftware(p);
            else if (p.Type == "Music")
                drawMusic(p);
            else if (p.Type == "Movie")
                drawMovie(p);
            else if (p.Type == "Pants")
                drawPants(p);
            else if (p.Type == "TShirt")
                drawTShirt(p);
            else if (p.Type == "DressShirt")
            {
                drawDressShirt(p);
            }
            else
            {
                int num = (int)MessageBox.Show("Not found.");
            }
        }

        private void drawMedia(Product p)
        {
            Media media = (Media)p;
            lblVar1.Text = "Release Date";
            txtVar1.Text = Convert.ToString(media.ReleaseDate);
        }

        private void drawApparel(Product p)
        {
            Apparel apparel = (Apparel)p;
            lblVar1.Text = "Color";
            txtVar1.Text = apparel.Color;
            lblVar2.Text = "Manufacturer";
            txtVar2.Text = apparel.Manufacturer;
            lblVar3.Text = "Material";
            txtVar3.Text = apparel.Material;
        }

        private void drawDisk(Product p)
        {
            Disk disk = (Disk)p;
            drawMedia(p);
            lblVar2.Text = "Number of Disks";
            txtVar2.Text = disk.NumDisks.ToString();
            lblVar3.Text = "Data Size";
            txtVar3.Text = disk.Size.ToString();
            lblVar4.Text = "Type Disk";
            txtVar4.Text = disk.TypeDisk;
        }

        private void drawEntertainment(Product p)
        {
            Entertainment entertainment = (Entertainment)p;
            drawDisk(p);
            lblVar5.Text = "Runtime";
            txtVar5.Text = Convert.ToString(entertainment.RunTime);
        }

        private void drawBook(Product p)
        {
            Book book = (Book)p;
            drawSet(true, true, true, true, false, false, false, false);
            drawMedia(p);
            lblVar2.Text = "Pages";
            txtVar2.Text = book.NumPages.ToString();
            lblVar3.Text = "Author";
            txtVar3.Text = book.Author;
            lblVar4.Text = "Publisher";
            txtVar4.Text = book.Publisher;
        }

        private void drawSoftware(Product p)
        {
            Software software = (Software)p;
            drawSet(true, true, true, true, true, false, false, false);
            drawDisk(p);
            lblVar5.Text = "Type Software";
            txtVar5.Text = software.TypeSoft;
        }

        private void drawMusic(Product p)
        {
            Music music = (Music)p;
            drawSet(true, true, true, true, true, true, true, true);
            drawEntertainment(p);
            lblVar6.Text = "Artist";
            txtVar6.Text = music.Artist;
            lblVar7.Text = "Label";
            txtVar7.Text = music.Label;
            lblVar8.Text = "Genre";
            txtVar8.Text = music.Genre;
        }

        private void drawMovie(Product p)
        {
            Movie movie = (Movie)p;
            drawSet(true, true, true, true, true, true, true, false);
            drawEntertainment(p);
            lblVar6.Text = "Director";
            txtVar6.Text = movie.Director;
            lblVar7.Text = "Producer";
            txtVar7.Text = movie.Producer;
        }

        private void drawPants(Product p)
        {
            Pants pants = (Pants)p;
            drawSet(true, true, true, true, true, false, false, false);
            drawApparel(p);
            lblVar4.Text = "Waist";
            txtVar4.Text = pants.Waist.ToString();
            lblVar5.Text = "Inseam";
            txtVar5.Text = pants.Inseam.ToString();
        }

        private void drawDressShirt(Product p)
        {
            DressShirt dressShirt = (DressShirt)p;
            drawSet(true, true, true, true, true, false, false, false);
            drawApparel(p);
            lblVar4.Text = "Neck";
            txtVar4.Text = dressShirt.Neck.ToString();
            lblVar5.Text = "Sleeve";
            txtVar5.Text = dressShirt.Sleeve.ToString();
        }

        private void drawTShirt(Product p)
        {
            TShirt tshirt = (TShirt)p;
            drawSet(true, true, true, true, false, false, false, false);
            drawApparel(p);
            lblVar4.Text = "Size";
            txtVar4.Text = tshirt.Size.ToString();
        }
    }
}
